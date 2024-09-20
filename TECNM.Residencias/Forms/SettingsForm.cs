using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Forms
{
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
            lbl_AppVersion.Text = "Versión " + App.Version;
            LoadSavedSettings();
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
        }

        private void DatabaseBackup_Click(object sender, EventArgs e)
        {
            //using var dialog = new FolderBrowserDialog();
            //DialogResult result = dialog.ShowDialog();
            MessageBox.Show("¡Módulo en construcción!");
        }

        private void SourceCodeGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var info = new ProcessStartInfo
            {
                FileName = App.SourceCodeUrl,
                UseShellExecute = true,
            };

            Process.Start(info);
        }

        private void SaveAppSettings_Click(object sender, EventArgs e)
        {
            AppSettings.Default.DefaultAdvisorType = cb_AdvisorType.SelectedIndex - 1;
            AppSettings.Default.DefaultCompanyType = cb_CompanyType.SelectedIndex - 1;
            AppSettings.Default.DefaultStudentCareer = ((Career) cb_StudentCareer.SelectedItem!).Id;
            AppSettings.Default.Save();
            Close();
        }

        private void LoadSavedSettings()
        {
            cb_AdvisorType.SelectedIndex = AppSettings.Default.DefaultAdvisorType + 1;
            cb_CompanyType.SelectedIndex = AppSettings.Default.DefaultCompanyType + 1;

            using var context = new AppDbContext();
            IEnumerable<Career> careers = context.Careers.EnumerateCareers();

            cb_StudentCareer.Items.Add(new Career { Id = -1, Name = "Ninguno" });
            cb_StudentCareer.SelectedIndex = 0;

            foreach (Career career in careers)
            {
                int index = cb_StudentCareer.Items.Add(career);
                if (AppSettings.Default.DefaultStudentCareer == career.Id)
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
}
