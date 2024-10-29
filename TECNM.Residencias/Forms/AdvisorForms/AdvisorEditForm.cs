namespace TECNM.Residencias.Forms.AdvisorForms;

using FluentValidation;
using FluentValidation.Results;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DTO;
using TECNM.Residencias.Data.Validators;
using TECNM.Residencias.Forms.CompanyForms;

public sealed partial class AdvisorEditForm : EditForm
{
    private readonly AbstractValidator<Advisor> _validator = new AdvisorValidator();
    private Company _company = new Company();
    private Advisor _advisor = new Advisor();

    public AdvisorEditForm()
    {
        InitializeComponent();
    }

    public AdvisorEditForm(Company company, Advisor? entity) : this()
    {
        _company = company;
        tb_AdvisorCompany.Text = company.Name;
        btn_ChooseCompany.Enabled = false;

        if (entity is not null)
        {
            _advisor = entity;
            chk_AdvisorInternal.Checked = entity.Internal;
            tb_AdvisorFirstName.Text    = entity.FirstName;
            tb_AdvisorLastName.Text     = entity.LastName;
            tb_AdvisorSection.Text      = entity.Section;
            tb_AdvisorRole.Text         = entity.Role;
            tb_AdvisorEmail.Text        = entity.Email;
            mtb_AdvisorPhone.Text       = entity.Phone;
            tb_AdvisorExtension.Text    = entity.Extension;
            chk_AdvisorEnabled.Checked  = entity.Enabled;
        }
    }

    public Advisor Advisor => _advisor;

    private void ChooseCompany_Click(object sender, EventArgs e)
    {
        while (true)
        {
            using var dialog = new CompanyQuickSearchForm();
            dialog.ShowDialog();

            CompanySearchResultDto? selected = dialog.SelectedCompany;
            if (selected is not null)
            {
                _company = new Company
                {
                    Id   = selected.Id,
                    Rfc  = selected.Rfc,
                    Name = selected.Name,
                };

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
        Advisor advisor = _advisor;
        Company company = _company;

        advisor.CompanyId = company.Id;
        advisor.Internal  = chk_AdvisorInternal.Checked;
        advisor.FirstName = tb_AdvisorFirstName.Text.Trim();
        advisor.LastName  = tb_AdvisorLastName.Text.Trim();
        advisor.Section   = tb_AdvisorSection.Text.Trim();
        advisor.Role      = tb_AdvisorRole.Text.Trim();
        advisor.Email     = tb_AdvisorEmail.Text.Trim();
        advisor.Phone     = mtb_AdvisorPhone.Text.Trim();
        advisor.Extension = tb_AdvisorExtension.Text.Trim();
        advisor.Enabled   = chk_AdvisorEnabled.Checked;

        ValidationResult result = _validator.Validate(advisor);

        if (!result.IsValid)
        {
            Debug.Assert(result.Errors.Count > 0);
            MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var context = new AppDbContext();
        context.Advisors.AddOrUpdate(advisor);
        context.SaveChanges();
        Close();
    }
}
