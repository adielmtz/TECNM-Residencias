using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Extensions;

namespace TECNM.Residencias.Forms.StudentForms
{
    public sealed partial class StudentListViewForm : Form
    {
        private readonly int _rowsPerPage = App.DefaultRowsPerPage;
        private int _currentPage = App.DefaultInitialPage;
        private bool _refreshFromSearch = false;

        public StudentListViewForm()
        {
            InitializeComponent();
            Text = $"Listado de residentes | {App.Name}";
            dgv_ListView.DoubleBuffered(true);
        }

        private void StudentListViewForm_Load(object sender, EventArgs e)
        {
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

        private void AddNewCompany_Click(object sender, EventArgs e)
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

        private void ResetSearch_Click(object sender, EventArgs e)
        {
            _currentPage = App.DefaultInitialPage;
            _refreshFromSearch = false;
            RefreshList();
        }

        private void PagePrev_Click(object sender, EventArgs e)
        {
            _currentPage = Math.Max(0, _currentPage - 1);
            RefreshList();
        }

        private void PageNext_Click(object sender, EventArgs e)
        {
            _currentPage++;
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

            using var context = new AppDbContext();
            IEnumerable<Student> students = context.Students.EnumerateStudents(_rowsPerPage, _currentPage);
            PopulateTable(context, students);
        }

        private void SearchStudents()
        {
            string query = tb_SearchQuery.Text.Trim();
            if (query.Length == 0)
            {
                return;
            }

            _refreshFromSearch = true;
            using var context = new AppDbContext();
            IEnumerable<Student> students = context.Students.Search(query, _rowsPerPage, _currentPage);
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

                Specialty specialty = context.Specialties.GetSpecialtyById(student.SpecialtyId)!;
                Advisor? internAdvisor = context.Advisors.GetAdvisorById(student.InternalAdvisorId ?? 0);
                Advisor? externAdvisor = context.Advisors.GetAdvisorById(student.ExternalAdvisorId ?? 0);
                Advisor? reviewer = context.Advisors.GetAdvisorById(student.ReviewerAdvisorId ?? 0);
                Company company = context.Companies.GetCompanyById(student.CompanyId)!;

                row.Tag = student;
                row.Cells[0].Value = student.Id;
                row.Cells[1].Value = $"{student.FirstName} {student.LastName}";
                row.Cells[2].Value = TranslateGenderEnum(student.Gender);
                row.Cells[3].Value = student.Email;
                row.Cells[4].Value = specialty.Name;
                row.Cells[5].Value = student.Semester;
                row.Cells[6].Value = student.StartDate.ToShortDateString();
                row.Cells[7].Value = student.EndDate.ToShortDateString();
                row.Cells[8].Value = internAdvisor?.ToString() ?? "SIN ASIGNAR";
                row.Cells[9].Value = externAdvisor?.ToString() ?? "SIN ASIGNAR";
                row.Cells[10].Value = reviewer?.ToString() ?? "SIN ASIGNAR";
                row.Cells[11].Value = company.Name;
                row.Cells[12].Value = student.Department;
                row.Cells[13].Value = student.Schedule;
                row.Cells[14].Value = !student.Enabled;
                row.Cells[15].Value = student.Notes;
                row.Cells[16].Value = student.UpdatedOn;
                row.Cells[17].Value = student.CreatedOn;
                count++;
            }

            dgv_ListView.ClearSelection();
            btn_PagePrev.Enabled = _currentPage > 1;
            btn_PageNext.Enabled = count == _rowsPerPage;
            UpdateStatusLabel();
        }

        private string TranslateGenderEnum(Gender gender)
        {
            return gender switch
            {
                Gender.Male => "Hombre",
                Gender.Female => "Mujer",
                Gender.Other => "Otro",
                _ => throw new UnreachableException(),
            };
        }

        private void UpdateStatusLabel()
        {
            lbl_StatusLabel.Text = $"Página {_currentPage}    Número de registros: {dgv_ListView.RowCount}";
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
    }
}
