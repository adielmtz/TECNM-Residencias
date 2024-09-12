using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Properties;

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

        private void DatabaseCheckIntegrity_Click(object sender, EventArgs e)
        {
            Enabled = false;

            bool mustRepairDb = false;

            using (var sqlite = App.Database.Open())
            {
                using (var command = sqlite.CreateCommand())
                {
                    command.CommandText = "PRAGMA integrity_check";
                    object? result = command.ExecuteScalar();

                    if (result is string state && state.Equals("ok", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(
                            "No se encontraron problemas de integridad en la base de datos.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show(
                            "Se encontraron errores en la base de datos. ¿Desea reparar la base de datos?"
                            + "Se creará una nueva base de datos vacía.",
                            "Confirmar reparacón",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Error
                        );

                        if (dr == DialogResult.Yes)
                        {
                            mustRepairDb = true;
                        }
                    }
                }
            }

            if (mustRepairDb)
            {
                RepairDatabase();
            }

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
                FileName = "https://github.com/adielmtz/TECNM-Residencias",
                UseShellExecute = true,
            };

            Process.Start(info);
        }

        private void SaveAppSettings_Click(object sender, EventArgs e)
        {
            AppSettings.Default.AdvisorDefaultType = cb_AdvisorType.SelectedIndex - 1;
            AppSettings.Default.CompanyDefaultType = cb_CompanyType.SelectedIndex - 1;
            AppSettings.Default.StudentDefaultCareer = ((Career) cb_StudentCareer.SelectedItem!).Id;
            AppSettings.Default.Save();
            Close();
        }

        private void LoadSavedSettings()
        {
            cb_AdvisorType.SelectedIndex = AppSettings.Default.AdvisorDefaultType + 1;
            cb_CompanyType.SelectedIndex = AppSettings.Default.CompanyDefaultType + 1;

            using var context = new AppDbContext();
            IEnumerable<Career> careers = context.Careers.EnumerateCareers();

            cb_StudentCareer.Items.Add(new Career { Id = -1, Name = "Ninguno" });
            cb_StudentCareer.SelectedIndex = 0;

            foreach (Career career in careers)
            {
                int index = cb_StudentCareer.Items.Add(career);
                if (AppSettings.Default.StudentDefaultCareer == career.Id)
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

        private void RepairDatabase()
        {
            // Keep the original db but rename it
            File.Move(App.DatabaseFile, App.DatabaseFile + ".corrupt");

            // Create a brand new db
            App.Initialize();
        }
    }
}
