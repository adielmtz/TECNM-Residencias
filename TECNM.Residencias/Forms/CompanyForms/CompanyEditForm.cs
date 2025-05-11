namespace TECNM.Residencias.Forms.CompanyForms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Validators;

public sealed partial class CompanyEditForm : EditForm
{
    private readonly AbstractValidator<Company> _validator = new CompanyValidator();
    private Company _company = new Company();

    public CompanyEditForm()
    {
        InitializeComponent();
    }

    public CompanyEditForm(Company? entity) : this()
    {
        if (entity != null)
        {
            _company = entity;
            tb_CompanyRfc.Text = entity.Rfc;
            tb_CompanyName.Text = entity.Name;
            tb_CompanyEmail.Text = entity.Email;
            mtb_CompanyPhone.Text = entity.Phone;
            tb_CompanyExtension.Text = entity.Extension;
            tb_CompanyAddress.Text = entity.Address;
            tb_CompanyLocality.Text = entity.Locality;
            mtb_CompanyPostalCode.Text = entity.PostalCode;
            chk_CompanyEnabled.Checked = entity.Enabled;
        }
    }

    public Company Company => _company;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        CompanyType[] companyTypes = Enum.GetValues<CompanyType>().OrderBy(it => (int) it).ToArray();
        bool companySelected = false;

        cb_CompanyType.Items.Add("Seleccionar");
        cb_CompanyType.SelectedIndex = 0;

        foreach (CompanyType type in companyTypes)
        {
            int index = cb_CompanyType.Items.Add(type.GetLocalizedName());
            if (!companySelected)
            {
                if (_company.Id > 0 && _company.Type == type)
                {
                    cb_CompanyType.SelectedIndex = index;
                    companySelected = true;
                    continue;
                }

                if (AppSettings.Default.DefaultCompanyType == type)
                {
                    cb_CompanyType.SelectedIndex = index;
                }
            }
        }

        using var context = new AppDbContext();
        IEnumerable<Country> countries = context.Countries.EnumerateAll();

        foreach (Country country in countries)
        {
            cb_CompanyCountry.Items.Add(country);
        }

        if (_company.Id > 0)
        {
            LoadLocationData(context);
        }

        cb_CompanyCountry.SelectedIndexChanged += CompanyCountry_SelectedIndexChanged;
        cb_CompanyState.SelectedIndexChanged += CompanyState_SelectedIndexChanged;

        if (cb_CompanyCountry.Items.Count == 1)
        {
            cb_CompanyCountry.SelectedIndex = 0;
        }
    }

    private void CompanyCountry_SelectedIndexChanged(object? sender, EventArgs e)
    {
        Country? country = (Country?) cb_CompanyCountry.SelectedItem;
        if (country == null)
        {
            return;
        }

        cb_CompanyState.SelectedIndex = -1;
        cb_CompanyState.ResetText();
        cb_CompanyState.Items.Clear();

        cb_CompanyCity.SelectedIndex = -1;
        cb_CompanyCity.ResetText();
        cb_CompanyCity.Items.Clear();

        using var context = new AppDbContext();
        IEnumerable<State> states = context.States.EnumerateAll(country!);

        foreach (State state in states)
        {
            cb_CompanyState.Items.Add(state);
        }
    }

    private void CompanyState_SelectedIndexChanged(object? sender, EventArgs e)
    {
        State? state = (State?) cb_CompanyState.SelectedItem;
        if (state == null)
        {
            return;
        }

        cb_CompanyCity.SelectedIndex = -1;
        cb_CompanyCity.ResetText();
        cb_CompanyCity.Items.Clear();

        using var context = new AppDbContext();
        IEnumerable<City> cities = context.Cities.EnumerateAll(state!);

        foreach (City city in cities)
        {
            cb_CompanyCity.Items.Add(city);
        }
    }

    private void SaveEdit_Click(object sender, EventArgs e)
    {
        Save();
    }

    private void LoadLocationData(AppDbContext context)
    {
        long stateId = context.Cities.GetCity(_company.CityId)!.StateId;
        IEnumerable<City> cities = context.Cities.EnumerateAll(stateId);

        long countryId = context.States.GetState(stateId)!.CountryId;
        IEnumerable<State> states = context.States.EnumerateAll(countryId);

        foreach (State state in states)
        {
            int index = cb_CompanyState.Items.Add(state);
            if (state.Id == stateId)
            {
                cb_CompanyState.SelectedIndex = index;
            }
        }

        foreach (City city in cities)
        {
            int index = cb_CompanyCity.Items.Add(city);
            if (city.Id == _company.CityId)
            {
                cb_CompanyCity.SelectedIndex = index;
            }
        }

        cb_CompanyCountry.SelectedIndex = (int) countryId - 1;
    }

    private void Save()
    {
        _company.Type = (CompanyType) cb_CompanyType.SelectedIndex - 1;
        _company.Rfc = tb_CompanyRfc.Text.Trim().ToUpper();
        _company.Name = tb_CompanyName.Text.Trim();
        _company.Email = tb_CompanyEmail.Text.Trim();
        _company.Phone = mtb_CompanyPhone.Text.Trim();
        _company.Extension = tb_CompanyExtension.Text.Trim();
        _company.Address = tb_CompanyAddress.Text.Trim();
        _company.Locality = tb_CompanyLocality.Text.Trim();
        _company.PostalCode = mtb_CompanyPostalCode.Text.Trim();
        _company.Enabled = chk_CompanyEnabled.Checked;

        if (string.IsNullOrEmpty(_company.Rfc))
        {
            _company.Rfc = null;
        }

        City? city = (City?) cb_CompanyCity.SelectedItem;
        _company.CityId = city == null ? 0 : city.Id;

        ValidationResult result = _validator.Validate(_company);

        if (!result.IsValid)
        {
            Debug.Assert(result.Errors.Count > 0);
            MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var context = new AppDbContext();

        try
        {
            context.Companies.AddOrUpdate(_company);
        }
        catch (SqliteException e) when (e.SqliteErrorCode == SQLitePCL.raw.SQLITE_CONSTRAINT)
        {
            MessageBox.Show(
                "Ya existe un registro con el mismo RFC.",
                "Error al guardar la información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            context.RejectChanges();
            return;
        }

        context.SaveChanges();
        Close();
    }
}
