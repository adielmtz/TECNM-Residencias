namespace TECNM.Residencias.Forms.StudentForms;

using FluentValidation;
using FluentValidation.Results;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;
using TECNM.Residencias.Forms.AdvisorForms;
using TECNM.Residencias.Forms.CompanyForms;
using TECNM.Residencias.Services;

public sealed partial class StudentEditForm : Form
{
    private readonly AbstractValidator<Student> _validator = new StudentValidator();
    private readonly FormConfirmClosingService closeConfirmService;
    private Student _student = new Student();
    private Company _company = new Company();
    private Advisor? _internalAdvisor;
    private Advisor? _externalAdvisor;
    private Advisor? _reviewerAdvisor;
    private IList<Extra>? extras;
    private bool _isNewRecord = true;

    public StudentEditForm()
    {
        InitializeComponent();
        closeConfirmService = new FormConfirmClosingService(this);

        DateTime now = DateTime.Now;
        cb_StudentSemester.SelectedIndex = now.Month >= 1 && now.Month < 7 ? 0 : 1;
    }

    public StudentEditForm(Student? entity) : this()
    {
        if (entity != null)
        {
            _student = entity;
            _isNewRecord = false;
            btn_DeleteStudent.Enabled = _student.Id > 0;

            /// INFORMACIÓN GENERAL
            mtb_StudentId.Text = entity.Id.ToString();
            mtb_StudentId.Enabled = false;

            tb_StudentFirstName.Text = entity.FirstName;
            tb_StudentLastName.Text = entity.LastName;
            cb_StudentGender.SelectedIndex = (int) entity.Gender;
            tb_StudentEmail.Text = entity.Email;
            mtb_StudentPhone.Text = entity.Phone;

            /// PROYECTO
            tb_StudentProjectName.Text = entity.Project;
            tb_StudentDepartment.Text = entity.Department;
            tb_StudentSchedule.Text = entity.Schedule;
            cb_StudentSemester.SelectedIndex = entity.Semester == "ENE-JUN" ? 0 : 1;
            dtp_StudentStartDate.Value = entity.StartDate;
            dtp_StudentEndDate.Value = entity.EndDate;
            chk_StudentClosed.Checked = entity.IsClosed;
            tb_StudentNotes.Text = entity.Notes;

            cb_StudentSemester.Enabled = false;
            dtp_StudentStartDate.Enabled = false;
        }
    }

    private void StudentEditForm_Load(object sender, EventArgs e)
    {
        using var context = new AppDbContext();
        IEnumerable<Career> careers = context.Careers.EnumerateCareers(enabled: true);

        Career? prefetchCareer = null;

        foreach (Career career in careers)
        {
            int index = cb_StudentCareer.Items.Add(career);
            if (AppSettings.Default.StudentCareer == career.Id)
            {
                cb_StudentCareer.SelectedIndex = index;
                prefetchCareer = career;
            }
        }

        cb_StudentSpecialty.Enabled = false;

        if (prefetchCareer != null)
        {
            IEnumerable<Specialty> specialties = context.Specialties.EnumerateSpecialtiesByCareer(prefetchCareer);
            PopulateSpecialtyCombobox(specialties);
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

        using var context = new AppDbContext();
        IEnumerable<Specialty> specialties = context.Specialties.EnumerateSpecialtiesByCareer(career.Id, enabled: true);
        PopulateSpecialtyCombobox(specialties);
    }

    private void PopulateSpecialtyCombobox(IEnumerable<Specialty> specialties)
    {
        cb_StudentSpecialty.Enabled = false;
        cb_StudentSpecialty.Items.Clear();
        cb_StudentSpecialty.SelectedIndex = -1;

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

    private void ChoseInternalAdvisor_Click(object sender, EventArgs e)
    {
        while (true)
        {
            using var dialog = new AdvisorQuickSearchForm();
            dialog.FilterType = AdvisorType.Internal;
            dialog.ShowDialog();

            Advisor? selected = dialog.SelectedAdvisor;
            if (selected != null)
            {
                SetInternalAdvisor(selected);
                break;
            }

            DialogResult result = MessageBox.Show(
                "No se seleccionó ningún asesor.",
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

    private void ChoseExternalAdvisor_Click(object sender, EventArgs e)
    {
        while (true)
        {
            using var dialog = new AdvisorQuickSearchForm();
            dialog.FilterCompany = _company;
            dialog.ShowDialog();

            Advisor? selected = dialog.SelectedAdvisor;
            if (selected != null)
            {
                SetExternalAdvisor(selected);
                break;
            }

            DialogResult result = MessageBox.Show(
                "No se seleccionó ningún asesor.",
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

    private void ChoseReviewerAdvisor_Click(object sender, EventArgs e)
    {
        while (true)
        {
            using var dialog = new AdvisorQuickSearchForm();
            dialog.FilterType = AdvisorType.Internal;
            dialog.ShowDialog();

            Advisor? selected = dialog.SelectedAdvisor;
            if (selected != null)
            {
                SetReviewerAdvisor(selected);
                break;
            }

            DialogResult result = MessageBox.Show(
                "No se seleccionó ningún asesor.",
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

    private void RemoveInternalAdvisor_Click(object sender, EventArgs e)
    {
        if (ConfirmAdvisorRemovalDialog() == DialogResult.OK)
        {
            SetInternalAdvisor(null);
            btn_RemoveInternalAdvisor.Enabled = false;
        }
    }

    private void RemoveExternalAdvisor_Click(object sender, EventArgs e)
    {
        if (ConfirmAdvisorRemovalDialog() == DialogResult.OK)
        {
            SetExternalAdvisor(null);
            btn_RemoveExternalAdvisor.Enabled = false;
        }
    }

    private void RemoveReviewerAdvisor_Click(object sender, EventArgs e)
    {
        if (ConfirmAdvisorRemovalDialog() == DialogResult.OK)
        {
            SetReviewerAdvisor(null);
            btn_RemoveReviewerAdvisor.Enabled = false;
        }
    }

    private DialogResult ConfirmAdvisorRemovalDialog()
    {
        return MessageBox.Show(
            "¿Eliminar este asesor?",
            "Confirmar acción",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning
        );
    }

    private void AddStudentDocument_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        dialog.Multiselect = true;
        dialog.RestoreDirectory = true;
        DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            foreach (string filename in dialog.FileNames)
            {
                dcc_Documents.Add(filename);
            }
        }
    }

    private void StudentEnabled_Click(object sender, EventArgs e)
    {
        bool enabled = chk_StudentClosed.Checked;
        if (enabled)
        {
            DialogResult result = MessageBox.Show(
                "Se va a cerrar el expediente. Al cerrarlo ya no podrá editarse.",
                "Confirmar acción",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
            {
                chk_StudentClosed.Checked = false;
                return;
            }
        }

        gb_GeneralInfo.Enabled = !enabled;
        gb_ProjectInfo.Enabled = !enabled;
        gb_Documents.Enabled = !enabled;
        gb_Notes.Enabled = !enabled;
        btn_AddExtras.Enabled = !enabled;
        btn_DeleteStudent.Enabled = !enabled;
    }

    private void OpenExtrasDialog_Click(object sender, EventArgs e)
    {
        using var dialog = new StudentExtrasPickerDialogForm(_student);
        dialog.ShowDialog();
        extras = dialog.SelectedExtras;
    }

    private void DeleteStudent_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            """
            ¿Está seguro de que desea eliminar expediente? Esta acción no es revesible.
            Los documentos del residente también serán eliminados permanentemente.
            """,
            "Confirmar acción",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Cancel)
        {
            return;
        }

        using var context = new AppDbContext();
        dcc_Documents.RemoveAll(context.Documents);
        context.Students.Delete(_student);
        context.Commit();
        Close();
    }

    private async void SaveEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Enabled = false;

            Student _student = this._student;
            Specialty? specialty = (Specialty?) cb_StudentSpecialty.SelectedItem;
            string? semester = (string?) cb_StudentSemester.SelectedItem;

            _student.Id = TryConvertLong(mtb_StudentId.Text.Trim());
            _student.SpecialtyId = specialty == null ? 0 : specialty.Id;
            _student.FirstName = tb_StudentFirstName.Text.Trim();
            _student.LastName = tb_StudentLastName.Text.Trim();
            _student.Email = tb_StudentEmail.Text.Trim();
            _student.Phone = mtb_StudentPhone.Text.Trim();
            _student.Gender = (Gender) cb_StudentGender.SelectedIndex;
            _student.Semester = semester ?? "";
            _student.StartDate = dtp_StudentStartDate.Value;
            _student.EndDate = dtp_StudentEndDate.Value;
            _student.Project = tb_StudentProjectName.Text.Trim();
            _student.InternalAdvisorId = _internalAdvisor?.Id;
            _student.ExternalAdvisorId = _externalAdvisor?.Id;
            _student.ReviewerAdvisorId = _reviewerAdvisor?.Id;
            _student.CompanyId = _company.Id;
            _student.Department = tb_StudentDepartment.Text.Trim();
            _student.Schedule = tb_StudentSchedule.Text.Trim();
            _student.Notes = tb_StudentNotes.Text.Trim();
            _student.IsClosed = chk_StudentClosed.Checked;

            ValidationResult result = _validator.Validate(_student);

            if (!result.IsValid)
            {
                Debug.Assert(result.Errors.Count > 0);
                MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Enabled = true;
                return;
            }

            using var context = new AppDbContext();

            if (_isNewRecord)
            {
                context.Students.Insert(_student);
            }
            else
            {
                context.Students.Update(_student);
            }

            if (extras != null)
            {
                context.Extras.DeleteExtrasForStudent(_student);
                context.Extras.InsertExtrasForStudent(_student, extras);
            }

            await dcc_Documents.SaveAsync(context.Documents, _student);
            context.Commit();
            Close();
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == SQLitePCL.raw.SQLITE_CONSTRAINT)
        {
            string message = ex.SqliteExtendedErrorCode switch
            {
                SQLitePCL.raw.SQLITE_CONSTRAINT_PRIMARYKEY => $"Ya existe un expediente con este número de control: {_student.Id}",
                SQLitePCL.raw.SQLITE_CONSTRAINT_UNIQUE => $"Ya existe un expediente con esta dirección de correo: {_student.Email}",
                _ => $"SQLite error: {ex.SqliteExtendedErrorCode}.",
            };

            MessageBox.Show(
                message,
                "Conflicto de expedientes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Enabled = true;
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show(
                $"No se encontró el archivo {ex.FileName}.",
                "Error al guardar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation
            );

            Enabled = true;
        }
        catch (IOException)
        {
            MessageBox.Show(
                $"Ocurrió un error al intentar cargar los archivos. Vuelva a intentarlo.",
                "IO Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            Enabled = true;
        }
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

        Company company = context.Companies.GetCompanyById(_student.CompanyId)!;
        SetCompany(company);

        if (_student.InternalAdvisorId != null)
        {
            Advisor? internalAdvisor = context.Advisors.GetAdvisorById((long) _student.InternalAdvisorId);
            SetInternalAdvisor(internalAdvisor);
        }

        if (_student.ExternalAdvisorId != null)
        {
            Advisor? externalAdvisor = context.Advisors.GetAdvisorById((long) _student.ExternalAdvisorId);
            SetExternalAdvisor(externalAdvisor);
        }

        if (_student.ReviewerAdvisorId != null)
        {
            Advisor? reviewAdvisor = context.Advisors.GetAdvisorById((long) _student.ReviewerAdvisorId);
            SetReviewerAdvisor(reviewAdvisor);
        }

        // Load documents
        IEnumerable<Document> documents = context.Documents.EnumerateDocumentsByStudent(_student.Id);
        foreach (Document document in documents)
        {
            dcc_Documents.Add(document);
        }

        chk_StudentClosed.Checked = _student.IsClosed;
        if (chk_StudentClosed.Checked)
        {
            gb_GeneralInfo.Enabled = false;
            gb_ProjectInfo.Enabled = false;
            gb_Documents.Enabled = false;
            gb_Notes.Enabled = false;
            btn_AddExtras.Enabled = false;
            btn_DeleteStudent.Enabled = false;
        }
    }

    private void SetCompany(Company company)
    {
        _company = company;
        tb_StudentCompany.Text = company.Name;
        btn_ChoseExternalAdvisor.Enabled = true;
    }

    private void SetInternalAdvisor(Advisor? advisor)
    {
        _internalAdvisor = advisor;
        tb_StudentInternalAdvisor.Text = advisor != null ? advisor.ToString() : "SIN ASIGNAR";
        btn_RemoveInternalAdvisor.Enabled = advisor != null;
    }

    private void SetExternalAdvisor(Advisor? advisor)
    {
        _externalAdvisor = advisor;
        tb_StudentExternalAdvisor.Text = advisor != null ? advisor.ToString() : "SIN ASIGNAR";
        btn_RemoveExternalAdvisor.Enabled = advisor != null;
    }

    private void SetReviewerAdvisor(Advisor? advisor)
    {
        _reviewerAdvisor = advisor;
        tb_StudentReviewerAdvisor.Text = advisor != null ? advisor.ToString() : "SIN ASIGNAR";
        btn_RemoveReviewerAdvisor.Enabled = advisor != null;
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
