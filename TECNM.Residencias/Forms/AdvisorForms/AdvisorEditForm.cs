using FluentValidation;
using FluentValidation.Results;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Forms.AdvisorForms
{
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
            cb_AdvisorType.SelectedIndex = AppSettings.Default.DefaultAdvisorType;
        }

        public AdvisorEditForm(Company company, Advisor? entity) : this()
        {
            _company = company;

            if (entity != null)
            {
                _advisor = entity;
                cb_AdvisorType.SelectedIndex = (int) entity.Type;
                tb_AdvisorFirstName.Text = entity.FirstName;
                tb_AdvisorLastName.Text = entity.LastName;
                tb_AdvisorSection.Text = entity.Section;
                tb_AdvisorRole.Text = entity.Role;
                tb_AdvisorEmail.Text = entity.Email;
                mtb_AdvisorPhone.Text = entity.Phone;
                chk_AdvisorEnabled.Checked = entity.Enabled;
            }
        }

        private void AdvisorEditForm_Load(object sender, EventArgs e)
        {
            cb_AdvisorCompany.Items.Add(_company);
            cb_AdvisorCompany.SelectedIndex = 0;
            cb_AdvisorCompany.Enabled = false;
        }

        private void SaveEdit_Click(object sender, EventArgs e)
        {
            _advisor.CompanyId = _company.Id;
            _advisor.Type = (AdvisorType) cb_AdvisorType.SelectedIndex;
            _advisor.FirstName = tb_AdvisorFirstName.Text.Trim();
            _advisor.LastName = tb_AdvisorLastName.Text.Trim();
            _advisor.Section = tb_AdvisorSection.Text.Trim();
            _advisor.Role = tb_AdvisorRole.Text.Trim();
            _advisor.Email = tb_AdvisorEmail.Text.Trim();
            _advisor.Phone = mtb_AdvisorPhone.Text.Trim();
            _advisor.Enabled = chk_AdvisorEnabled.Checked;

            ValidationResult result = _validator.Validate(_advisor);

            if (!result.IsValid)
            {
                Debug.Assert(result.Errors.Count > 0);
                MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var context = new AppDbContext();
            if (_advisor.Id > 0)
            {
                context.Advisors.Update(_advisor);
            }
            else
            {
                context.Advisors.Insert(_advisor);
            }

            context.Commit();
            Close();
        }
    }
}
