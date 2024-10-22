namespace TECNM.Residencias.Forms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

public sealed partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
        Text = $"Configuración | {App.Name}";
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
        lbl_SqliteVersion.Text = "SQLite " + GetSqliteVersion();
        lbl_AppVersion.Text = "Versión " + App.Version.ToString(fieldCount: 3);
        LoadComboBoxItems();
    }

    private void DatabaseOptimize_Click(object sender, EventArgs e)
    {
        Enabled = false;

        using var sqlite = App.Database.Open();
        using var command = sqlite.CreateCommand();

        command.CommandText = "ANALYZE";
        command.ExecuteNonQuery();

        command.CommandText = "PRAGMA wal_checkpoint(FULL)";
        command.ExecuteNonQuery();

        Enabled = true;

        MessageBox.Show("Base de datos optimizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void DatabaseBackup_Click(object sender, EventArgs e)
    {
        using var dialog = new DialogBackupForm();
        dialog.ShowDialog();
    }

    private void SourceCodeGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var info = new ProcessStartInfo
        {
            FileName = "https://github.com/adielmtz/TECNM-Residencias",
            UseShellExecute = true,
        };

        Process.Start(info);
    }

    private void ResetDefaults_Click(object sender, EventArgs e)
    {
        AppSettings.Default.Clear();
        AppSettings.Default.Save();
        LoadComboBoxItems();
    }

    private void SaveAppSettings_Click(object sender, EventArgs e)
    {
        AppSettings.Default.CompanyType = ((CompanyType) cb_CompanyType.SelectedItem!).Id;
        AppSettings.Default.StudentCareer = ((Career) cb_StudentCareer.SelectedItem!).Id;
        AppSettings.Default.Save();
        Close();
    }

    private void LoadComboBoxItems()
    {
        using var context = new AppDbContext();

        cb_CompanyType.Items.Clear();
        cb_CompanyType.Items.Add(new CompanyType { Id = 0, Label = "Ninguno" });
        cb_CompanyType.SelectedIndex = 0;

        foreach (CompanyType type in context.CompanyTypes.EnumerateAll())
        {
            int index = cb_CompanyType.Items.Add(type);
            if (AppSettings.Default.CompanyType == type.Id)
            {
                cb_CompanyType.SelectedIndex = index;
            }
        }

        cb_StudentCareer.Items.Clear();
        cb_StudentCareer.Items.Add(new Career { Id = 0, Name = "Ninguno" });
        cb_StudentCareer.SelectedIndex = 0;

        foreach (Career career in context.Careers.EnumerateCareers(enabled: true))
        {
            int index = cb_StudentCareer.Items.Add(career);
            if (AppSettings.Default.StudentCareer == career.Id)
            {
                cb_StudentCareer.SelectedIndex = index;
            }
        }
    }

    private string GetSqliteVersion()
    {
        using var sqlite = App.Database.Open();
        using var command = sqlite.CreateCommand();
        command.CommandText = "SELECT sqlite_version()";
        object? result = command.ExecuteScalar();

        if (result is string s)
        {
            return $"v{s}";
        }

        return "unknown version";
    }
}
