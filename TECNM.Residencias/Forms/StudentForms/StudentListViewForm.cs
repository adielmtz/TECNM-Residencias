namespace TECNM.Residencias.Forms.StudentForms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DTO;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Extensions;

public sealed partial class StudentListViewForm : Form
{
    private bool _refreshFromSearch = false;

    public StudentListViewForm()
    {
        InitializeComponent();
        Text = $"Listado de residentes | {App.Name}";
        dgv_ListView.DoubleBuffered(true);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        using var context = new AppDbContext();
        long? minYear = context.Students.GetMinimumYear();
        var today = DateTime.Today;

        if (!minYear.HasValue)
        {
            minYear = today.Year;
        }

        for (int i = today.Year; i >= minYear; i--)
        {
            cb_FilterYear.Items.Add(i);
        }

        cb_FilterYear.SelectedIndex = 0;
        cb_FilterSemester.SelectedIndex = today.Month >= 1 && today.Month < 7 ? 1 : 2;

        if (AppSettings.Default.DefaultSemesterFilter >= 0)
        {
            cb_FilterSemester.SelectedIndex = AppSettings.Default.DefaultSemesterFilter;
        }

        RefreshList();
    }

    private void ListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        var grid = (DataGridView) sender;
        if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
        {
            var student = (Student) grid.Rows[e.RowIndex].Tag!;
            ShowStudentEditDialog(student);
        }
    }

    private void ListView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        var grid = (DataGridView) sender;
        if (e.RowIndex >= 0)
        {
            var student = (Student) grid.Rows[e.RowIndex].Tag!;
            ShowStudentEditDialog(student);
        }
    }

    private void AddNewStudent_Click(object sender, EventArgs e)
    {
        ShowStudentEditDialog();
    }

    private void SearchQuery_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char) Keys.Enter)
        {
            SearchStudents();
            e.Handled = true;
        }
    }

    private void RunQuerySearch_Click(object sender, EventArgs e)
    {
        SearchStudents();
    }

    private void ApplyFilters_Click(object sender, EventArgs e)
    {
        _refreshFromSearch = false;
        tb_SearchQuery.ResetText();
        RefreshList();
    }

    private void ShowStudentEditDialog(Student? student = null)
    {
        using var dialog = new StudentEditForm(student);
        dialog.ShowDialog();
        RefreshList();
    }

    private void RefreshList()
    {
        if (_refreshFromSearch)
        {
            SearchStudents();
            return;
        }

        int year = (int) cb_FilterYear.SelectedItem!;
        string? semester = (string?) cb_FilterSemester.SelectedItem;

        if (cb_FilterSemester.SelectedIndex == 0)
        {
            semester = null;
        }

        using var context = new AppDbContext();
        IEnumerable<Student> students = context.Students.EnumerateAll(year, semester);
        PopulateTable(context, students);
    }

    private void SearchStudents()
    {
        string query = tb_SearchQuery.Text.Trim();
        dgv_ListView.Rows.Clear();

        if (query.Length == 0)
        {
            return;
        }

        _refreshFromSearch = true;
        using var context = new AppDbContext();
        IEnumerable<StudentSearchResultDto> searchResults = context.Students.Search(query, 100, 1);
        List<Student> students = [];

        foreach (StudentSearchResultDto result in searchResults)
        {
            Student student = context.Students.GetStudent(result.Id)!;
            students.Add(student);
        }

        PopulateTable(context, students);
    }

    private void PopulateTable(AppDbContext context, IEnumerable<Student> students)
    {
        dgv_ListView.Rows.Clear();
        int count = 0;

        foreach (Student student in students)
        {
            int index = dgv_ListView.Rows.Add();
            DataGridViewRow row = dgv_ListView.Rows[index];

            Specialty specialty = context.Specialties.GetSpecialty(student.SpecialtyId)!;
            Advisor? internAdvisor = context.Advisors.GetAdvisor(student.InternalAdvisorId ?? 0);
            Advisor? externAdvisor = context.Advisors.GetAdvisor(student.ExternalAdvisorId ?? 0);
            Advisor? reviewer = context.Advisors.GetAdvisor(student.ReviewerAdvisorId ?? 0);
            Company company = context.Companies.GetCompany(student.CompanyId)!;

            row.Tag = student;
            row.Cells[0].Value = student.Id;
            row.Cells[1].Value = $"{student.FirstName} {student.LastName}";
            row.Cells[2].Value = student.Gender.GetLocalizedName();
            row.Cells[3].Value = student.Email;
            row.Cells[4].Value = specialty.Name;
            row.Cells[5].Value = student.Semester;
            row.Cells[6].Value = student.StartDate.ToShortDateString();
            row.Cells[7].Value = student.EndDate.ToShortDateString();
            row.Cells[8].Value = internAdvisor?.ToString() ?? "SIN ASIGNAR";
            row.Cells[9].Value = externAdvisor?.ToString() ?? "SIN ASIGNAR";
            row.Cells[10].Value = reviewer?.ToString() ?? "SIN ASIGNAR";
            row.Cells[11].Value = company.Name;
            row.Cells[12].Value = student.Section;
            row.Cells[13].Value = student.Schedule;
            row.Cells[14].Value = student.Closed;
            row.Cells[15].Value = student.Notes;
            row.Cells[16].Value = student.UpdatedOn.ToString("g");
            row.Cells[17].Value = student.CreatedOn.ToString("g");
            count++;
        }

        dgv_ListView.ClearSelection();
        UpdateStatusLabel();
    }

    private void UpdateStatusLabel()
    {
        lbl_StatusLabel.Text = $"Número de registros: {dgv_ListView.RowCount}";
    }
}
