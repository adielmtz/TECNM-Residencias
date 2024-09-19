using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Controls;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Forms.CareerForms;
using TECNM.Residencias.Forms.CompanyForms;
using TECNM.Residencias.Forms.StudentForms;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Forms
{
    public sealed partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Text = $"Panel de administración | {App.Name}";
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            App.Initialize();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            LoadLastModifiedStudents();
        }

        private void ShowStudents_Click(object sender, EventArgs e)
        {
            FormManagerService.OpenForm<StudentListViewForm>();
        }

        private void AddNewStudent_Click(object sender, EventArgs e)
        {
            FormManagerService.OpenDialog<StudentEditForm>();
        }

        private void ShowCareers_Click(object sender, EventArgs e)
        {
            FormManagerService.OpenForm<CareerListViewForm>();
        }

        private void ShowCompanies_Click(object sender, EventArgs e)
        {
            FormManagerService.OpenForm<CompanyListViewForm>();
        }

        private void AddNewCompany_Click(object sender, EventArgs e)
        {
            FormManagerService.OpenDialog<CompanyEditForm>();
        }

        private void ShowSettings_Click(object sender, EventArgs e)
        {
            FormManagerService.OpenForm<SettingsForm>();
        }

        private void DoSearch_Click(object sender, EventArgs e)
        {
            RunQuickSearch();
        }

        private void QuickSearchQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                RunQuickSearch();
                e.Handled = true;
            }
        }

        private void LoadLastModifiedStudents()
        {
            using var context = new AppDbContext();
            IEnumerable<Student> students = context.Students.EnumerateStudents(count: 30);
            flp_LastModifiedStudents.Controls.Clear();

            foreach (Student student in students)
            {
                var control = new StudentListItemViewControl(student);
                flp_LastModifiedStudents.Controls.Add(control);
            }
        }

        private void RunQuickSearch()
        {
            string query = tb_QuickSearchQuery.Text.Trim();
            if (query.Length == 0)
            {
                return;
            }

            using var context = new AppDbContext();
            IEnumerable<Student> students = context.Students.Search(query, 30, 1);
            flp_QuickSearchResults.Controls.Clear();

            foreach (Student student in students)
            {
                var control = new StudentListItemViewControl(student);
                flp_QuickSearchResults.Controls.Add(control);
            }
        }
    }
}
