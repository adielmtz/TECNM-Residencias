using FluentValidation;
using FluentValidation.Results;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;

namespace TECNM.Residencias.Forms.CompanyForms
{
    public sealed partial class CompanyEditForm : Form
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
                cb_CompanyType.SelectedIndex = (int) entity.Type;
                tb_CompanyRfc.Text = entity.Rfc;
                tb_CompanyName.Text = entity.Name;
                tb_CompanyAddress.Text = entity.Address;
                tb_CompanyLocality.Text = entity.Locality;
                tb_CompanyPostalCode.Text = entity.PostalCode;
                chk_CompanyEnabled.Checked = entity.Enabled;
            }
        }

        private void CompanyEditForm_Load(object sender, EventArgs e)
        {
            using var context = new AppDbContext();
            IReadOnlyList<Country> countries = context.Countries.GetCountries();

            foreach (Country country in countries)
            {
                cb_CompanyCountry.Items.Add(country);
            }

            cb_CompanyCountry.Enabled = true;

            if (_company.Id > 0)
            {
                LoadLocationData(context);
            }

            cb_CompanyCountry.SelectedIndexChanged += CompanyCountry_SelectedIndexChanged;
            cb_CompanyState.SelectedIndexChanged += CompanyState_SelectedIndexChanged;
        }

        private void CompanyCountry_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Country? country = (Country?) cb_CompanyCountry.SelectedItem;
            if (country == null)
            {
                return;
            }

            cb_CompanyState.Enabled = false;
            cb_CompanyState.Items.Clear();
            cb_CompanyState.SelectedIndex = -1;
            cb_CompanyState.ResetText();

            cb_CompanyCity.Enabled = false;
            cb_CompanyCity.Items.Clear();
            cb_CompanyCity.SelectedIndex = -1;
            cb_CompanyCity.ResetText();

            using var context = new AppDbContext();
            IReadOnlyList<State> states = context.States.GetStatesByCountry(country!);

            foreach (State state in states)
            {
                cb_CompanyState.Items.Add(state);
            }

            cb_CompanyState.Enabled = true;
        }

        private void CompanyState_SelectedIndexChanged(object? sender, EventArgs e)
        {
            State? state = (State?) cb_CompanyState.SelectedItem;
            if (state == null)
            {
                return;
            }

            cb_CompanyCity.Enabled = false;
            cb_CompanyCity.Items.Clear();
            cb_CompanyCity.SelectedIndex = -1;
            cb_CompanyCity.ResetText();

            using var context = new AppDbContext();
            IReadOnlyList<City> cities = context.Cities.GetCitiesByState(state!);

            foreach (City city in cities)
            {
                cb_CompanyCity.Items.Add(city);
            }

            cb_CompanyCity.Enabled = true;
        }

        private void SaveEdit_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void LoadLocationData(AppDbContext context)
        {
            long stateId = context.Cities.GetCityById(_company.CityId).StateId;
            IReadOnlyList<City> cities = context.Cities.GetCitiesByState(stateId);

            long countryId = context.States.GetStateById(stateId).CountryId;
            IReadOnlyList<State> states = context.States.GetStatesByCountry(countryId);

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
            cb_CompanyState.Enabled = true;
            cb_CompanyCity.Enabled = true;
        }

        private void Save()
        {
            _company.Type = (CompanyType) cb_CompanyType.SelectedIndex;
            _company.Rfc = tb_CompanyRfc.Text;
            _company.Name = tb_CompanyName.Text;
            _company.Address = tb_CompanyAddress.Text;
            _company.Locality = tb_CompanyLocality.Text;
            _company.PostalCode = tb_CompanyPostalCode.Text;
            _company.Enabled = chk_CompanyEnabled.Checked;

            City? city = (City?) cb_CompanyCity.SelectedItem;
            _company.CityId = city == null ? 0 : city.Id;

            ValidationResult result = _validator.Validate(_company);

            if (!result.IsValid)
            {
                Debug.Assert(result.Errors.Count == 1);
                MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var context = new AppDbContext();
            if (_company.Id > 0)
            {
                context.Companies.Update(_company);
            }
            else
            {
                try
                {
                    context.Companies.Insert(_company);
                }
                catch (SqliteException)
                {
                    MessageBox.Show(
                        "Ya existe un registro con el mismo RFC.",
                        "Error al guardar la información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    context.Rollback();
                    return;
                }
            }

            context.Commit();
            Close();
        }
    }
}