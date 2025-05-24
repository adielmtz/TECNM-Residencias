namespace TECNM.Residencias.Forms;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TECNM.Residencias.Controls;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities.DTO;
using TECNM.Residencias.Forms.CareerForms;
using TECNM.Residencias.Forms.CompanyForms;
using TECNM.Residencias.Forms.ReportForms;
using TECNM.Residencias.Forms.StudentForms;
using TECNM.Residencias.Services;

public sealed partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
        Text = $"Panel de administración | {App.Name}";
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        App.Initialize();

        if (AppSettings.Default.IsStorageBackupRequired)
        {
            MessageBox.Show(
                "Es necesario realizar una copia de seguridad.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            FormManagerService.OpenDialog<DialogBackupForm>();
        }

        if (AppSettings.Default.IsDatabaseBackupRequired)
        {
            MakeDatabaseBackup();
        }

        LoadLastModifiedStudents();

        if (AppSettings.Default.ShouldCheckForAppUpdates)
        {
            await AppUpdateService.CheckForUpdatesAsync();
        }
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
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

    private void ShowReportsPanel_Click(object sender, EventArgs e)
    {
        FormManagerService.OpenForm<ReportMainPanelForm>();
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

    private void MakeDatabaseBackup()
    {
        using var sqlite = App.Database.CreateConnection();
        using var backup = new DbBackup(sqlite, App.DatabaseBackupDirectory);
        backup.Execute();

        AppSettings.Default.LastDatabaseBackupDate = DateTime.Now;
        AppSettings.Default.Save();

        DirectoryCleanupService.DeleteOldFiles(App.DatabaseBackupDirectory, 20);
    }

    private void LoadLastModifiedStudents()
    {
        if (App.Initialized)
        {
            using var context = new AppDbContext();
            IEnumerable<StudentLastModifiedDto> recentlyModifiedStudent = context.Students.EnumerateRecentlyModified(20);
            flp_LastModifiedStudents.Controls.Clear();

            foreach (StudentLastModifiedDto student in recentlyModifiedStudent)
            {
                var control = new StudentListItemViewControl(student.Id, student.ToString());
                flp_LastModifiedStudents.Controls.Add(control);
            }
        }
    }

    private void RunQuickSearch()
    {
        string query = tb_QuickSearchQuery.Text.Trim();
        flp_QuickSearchResults.Controls.Clear();

        if (query.Length == 0)
        {
            return;
        }

        using var context = new AppDbContext();
        IEnumerable<StudentSearchResultDto> searchResults = context.Students.Search(query, 20, 1);

        foreach (StudentSearchResultDto student in searchResults)
        {
            var control = new StudentListItemViewControl(student.Id, student.ToString());
            flp_QuickSearchResults.Controls.Add(control);
        }
    }
}
