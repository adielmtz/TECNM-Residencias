namespace TECNM.Residencias.Forms.AdvisorForms;

using FluentValidation;
using FluentValidation.Results;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;
using TECNM.Residencias.Forms.CompanyForms;
using TECNM.Residencias.Services;

public sealed partial class AdvisorEditForm : Form
{
    private readonly AbstractValidator<Advisor> _validator = new AdvisorValidator();
    private readonly FormConfirmClosingService closeConfirmService;
    private Company _company = new Company();
    private Advisor _advisor = new Advisor();

    public AdvisorEditForm()
    {
        InitializeComponent();
        closeConfirmService = new FormConfirmClosingService(this);
    }

    public AdvisorEditForm(Company company, Advisor? entity) : this()
    {
        _company = company;
        tb_AdvisorCompany.Text = company.Name;
        btn_ChooseCompany.Enabled = false;

        if (entity != null)
        {
            _advisor = entity;
            chk_AdvisorInternal.Checked = entity.Internal;
            tb_AdvisorFirstName.Text = entity.FirstName;
            tb_AdvisorLastName.Text = entity.LastName;
            tb_AdvisorSection.Text = entity.Section;
            tb_AdvisorRole.Text = entity.Role;
            tb_AdvisorEmail.Text = entity.Email;
            mtb_AdvisorPhone.Text = entity.Phone;
            tb_AdvisorExtension.Text = entity.Extension;
            chk_AdvisorEnabled.Checked = entity.Enabled;
        }
    }

    public Advisor Advisor => _advisor;

    private void ChooseCompany_Click(object sender, EventArgs e)
    {
        while (true)
        {
            using var dialog = new CompanyQuickSearchForm();
            dialog.ShowDialog();

            Company? selected = dialog.SelectedCompany;
            if (selected != null)
            {
                _company = selected;
                tb_AdvisorCompany.Text = selected.Name;
                break;
            }

            DialogResult result = MessageBox.Show(
                "No se seleccionó empresa.",
                "Información",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Cancel)
            {
                break;
            }
        }
    }

    private void QuickSave_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char) Keys.Enter)
        {
            Save();
            e.Handled = true;
        }
    }

    private void SaveEdit_Click(object sender, EventArgs e)
    {
        Save();
    }

    private void Save()
    {
        _advisor.CompanyId = _company.Id;
        _advisor.Internal = chk_AdvisorInternal.Checked;
        _advisor.FirstName = tb_AdvisorFirstName.Text.Trim();
        _advisor.LastName = tb_AdvisorLastName.Text.Trim();
        _advisor.Section = tb_AdvisorSection.Text.Trim();
        _advisor.Role = tb_AdvisorRole.Text.Trim();
        _advisor.Email = tb_AdvisorEmail.Text.Trim();
        _advisor.Phone = mtb_AdvisorPhone.Text.Trim();
        _advisor.Extension = tb_AdvisorExtension.Text.Trim();
        _advisor.Enabled = chk_AdvisorEnabled.Checked;

        ValidationResult result = _validator.Validate(_advisor);

        if (!result.IsValid)
        {
            Debug.Assert(result.Errors.Count > 0);
            MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var context = new AppDbContext();
        context.Advisors.InsertOrUpdate(_advisor);
        context.Commit();
        Close();
    }
}
