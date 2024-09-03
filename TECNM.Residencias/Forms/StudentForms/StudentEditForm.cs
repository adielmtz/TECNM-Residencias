using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Controls;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;
using TECNM.Residencias.Forms.CompanyForms;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Forms.StudentForms
{
    public sealed partial class StudentEditForm : Form
    {
        private readonly AbstractValidator<Student> _validator = new StudentValidator();
        private Student _student = new Student();
        private Company _company = new Company();

        public StudentEditForm()
        {
            InitializeComponent();
        }

        public StudentEditForm(Student? entity) : this()
        {
            if (entity != null)
            {
                _student = entity;

                /// INFORMACIÓN GENERAL
                tb_StudentId.Text = entity.Id.ToString();
                tb_StudentFirstName.Text = entity.FirstName;
                tb_StudentLastName.Text = entity.LastName;
                cb_StudentGender.SelectedIndex = (int) entity.Gender;
                tb_StudentEmail.Text = entity.Email;
                tb_StudentPhone.Text = entity.Phone;

                /// PROYECTO
                tb_StudentProjectName.Text = entity.Project;
                tb_StudentDepartment.Text = entity.Department;
                tb_StudentSchedule.Text = entity.Schedule;
                cb_StudentSemester.SelectedIndex = entity.Semester == "ENE-JUN" ? 0 : 1;
                dtp_StudentStartDate.Value = entity.StartDate;
                dtp_StudentEndDate.Value = entity.EndDate;
                chk_StudentEnabled.Checked = entity.Enabled;
                tb_StudentNotes.Text = entity.Notes;
            }
        }

        private void StudentEditForm_Load(object sender, EventArgs e)
        {
            using var context = new AppDbContext();
            IEnumerable<Career> careers = context.Careers.EnumerateCareers(enabled: true);

            foreach (Career career in careers)
            {
                cb_StudentCareer.Items.Add(career);
            }

            cb_StudentSpecialty.Enabled = false;

            IEnumerable<Advisor> advisors = context.Advisors.EnumerateAdvisorsByType(AdvisorType.Internal);

            foreach (Advisor advisor in advisors)
            {
                cb_StudentInternalAdvisor.Items.Add(advisor);
                cb_StudentReviewerAdvisor.Items.Add(advisor);
            }

            if (_student.Id > 0)
            {
                LoadStudentData(context);
            }

            cb_StudentCareer.SelectedIndexChanged += StudentCareer_SelectedIndexChanged;
        }

        private void StudentCareer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Career? career = (Career?) cb_StudentCareer.SelectedItem;
            if (career == null)
            {
                return;
            }

            cb_StudentSpecialty.Enabled = false;
            cb_StudentSpecialty.Items.Clear();
            cb_StudentSpecialty.SelectedIndex = -1;

            using var context = new AppDbContext();
            IEnumerable<Specialty> specialties = context.Specialties.EnumerateSpecialtiesByCareer(career.Id, enabled: true);

            foreach (Specialty specialty in specialties)
            {
                cb_StudentSpecialty.Items.Add(specialty);
            }

            cb_StudentSpecialty.Enabled = cb_StudentSpecialty.Items.Count > 0;
        }

        private void ChoseCompany_Click(object sender, EventArgs e)
        {
            while (true)
            {
                using var dialog = new CompanyQuickSearchForm();
                dialog.ShowDialog();

                Company? selected = dialog.SelectedCompany;
                if (selected != null)
                {
                    SetCompany(selected);
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

        private void AddStudentDocument_Click(object sender, EventArgs e)
        {
            var control = new StudentDocumentFieldControl();
            control.Removed += RemoveDocument_Handler;
            flp_Documents.Controls.Add(control);
        }

        private void RemoveDocument_Handler(object? sender, EventArgs e)
        {
            Debug.Assert(sender != null);
            var control = (StudentDocumentFieldControl) sender;
            flp_Documents.Controls.Remove(control);

            using var context = new AppDbContext();
            context.Documents.Delete(control.Document);
            context.Commit();
        }

        private void SaveEdit_Click(object sender, EventArgs e)
        {
            Student _student = this._student;
            Specialty? specialty = (Specialty?) cb_StudentSpecialty.SelectedItem;
            Advisor? internalAdvisor = (Advisor?) cb_StudentInternalAdvisor.SelectedItem;
            Advisor? externalAdvisor = (Advisor?) cb_StudentExternalAdvisor.SelectedItem;
            Advisor? reviewerAdvisor = (Advisor?) cb_StudentReviewerAdvisor.SelectedItem;
            string? semester = (string?) cb_StudentSemester.SelectedItem;

            _student.Id = TryConvertLong(tb_StudentId.Text.Trim());
            _student.SpecialtyId = specialty == null ? 0 : specialty.Id;
            _student.FirstName = tb_StudentFirstName.Text.Trim();
            _student.LastName = tb_StudentLastName.Text.Trim();
            _student.Email = tb_StudentEmail.Text.Trim();
            _student.Phone = tb_StudentPhone.Text.Trim();
            _student.Gender = (Gender) cb_StudentGender.SelectedIndex;
            _student.Semester = semester ?? "";
            _student.StartDate = dtp_StudentStartDate.Value.ToUniversalTime();
            _student.EndDate = dtp_StudentEndDate.Value.ToUniversalTime();
            _student.Project = tb_StudentProjectName.Text.Trim();
            _student.InternalAdvisorId = internalAdvisor?.Id;
            _student.ExternalAdvisorId = externalAdvisor?.Id;
            _student.ReviewerAdvisorId = reviewerAdvisor?.Id;
            _student.CompanyId = _company.Id;
            _student.Department = tb_StudentDepartment.Text.Trim();
            _student.Schedule = tb_StudentSchedule.Text.Trim();
            _student.Notes = tb_StudentNotes.Text.Trim();
            _student.Enabled = chk_StudentEnabled.Checked;

            ValidationResult result = _validator.Validate(_student);

            if (!result.IsValid)
            {
                Debug.Assert(result.Errors.Count == 1);
                MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var context = new AppDbContext();
            context.Students.InsertOrUpdate(_student);

            foreach (StudentDocumentFieldControl control in flp_Documents.Controls)
            {
                Document document = control.Document;

                if (control.IsNewFile)
                {
                    DocumentStorageService.SaveFile(_student, document, control.SelectedFile);
                }

                context.Documents.InsertOrUpdate(document);
            }

            context.Commit();
            Close();
        }

        private void LoadStudentData(AppDbContext context)
        {
            long careerId = context.Specialties.GetSpecialtyById(_student.SpecialtyId)!.CareerId;
            IEnumerable<Specialty> specialties = context.Specialties.EnumerateSpecialtiesByCareer(careerId);

            for (int i = 0; i < cb_StudentCareer.Items.Count; i++)
            {
                Career career = (Career) cb_StudentCareer.Items[i]!;
                if (career.Id == careerId)
                {
                    cb_StudentCareer.SelectedIndex = i;
                    break;
                }
            }

            foreach (Specialty specialty in specialties)
            {
                int index = cb_StudentSpecialty.Items.Add(specialty);
                if (specialty.Id == _student.SpecialtyId)
                {
                    cb_StudentSpecialty.SelectedIndex = index;
                }
            }

            cb_StudentSpecialty.Enabled = cb_StudentSpecialty.Items.Count > 0;

            Company? company = context.Companies.GetCompanyById(_student.CompanyId);
            if (company != null)
            {
                SetCompany(company, context);
            }

            if (_student.InternalAdvisorId != null)
            {
                for (int i = 0; i < cb_StudentInternalAdvisor.Items.Count; i++)
                {
                    Advisor advisor = (Advisor) cb_StudentInternalAdvisor.Items[i]!;
                    if (advisor.Id == _student.InternalAdvisorId)
                    {
                        cb_StudentInternalAdvisor.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (_student.ReviewerAdvisorId != null)
            {
                for (int i = 0; i < cb_StudentReviewerAdvisor.Items.Count; i++)
                {
                    Advisor advisor = (Advisor) cb_StudentReviewerAdvisor.Items[i]!;
                    if (advisor.Id == _student.ReviewerAdvisorId)
                    {
                        cb_StudentReviewerAdvisor.SelectedIndex = i;
                        break;
                    }
                }
            }

            /// Load documents
            IEnumerable<Document> documents = context.Documents.EnumerateDocumentsByStudent(_student.Id);
            foreach (Document document in documents)
            {
                var control = new StudentDocumentFieldControl(document);
                control.Removed += RemoveDocument_Handler;
                flp_Documents.Controls.Add(control);
            }
        }

        private void SetCompany(Company company)
        {
            using var context = new AppDbContext();
            SetCompany(company, context);
        }

        private void SetCompany(Company company, AppDbContext context)
        {
            _company = company;
            tb_StudentCompany.Text = company.Name;

            IEnumerable<Advisor> advisors = context.Advisors.EnumerateAdvisorsByCompany(company.Id);

            cb_StudentExternalAdvisor.Enabled = false;
            cb_StudentExternalAdvisor.Items.Clear();
            cb_StudentExternalAdvisor.SelectedIndex = -1;
            cb_StudentExternalAdvisor.ResetText();

            foreach (Advisor advisor in advisors)
            {
                int index = cb_StudentExternalAdvisor.Items.Add(advisor);
                if (advisor.Id == _student.ExternalAdvisorId)
                {
                    cb_StudentExternalAdvisor.SelectedIndex = index;
                }
            }

            cb_StudentExternalAdvisor.Enabled = true;
        }

        private long TryConvertLong(string input)
        {
            if (long.TryParse(input, out long result))
            {
                return result;
            }

            return 0;
        }
    }
}
