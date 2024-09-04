using System;
using System.Windows.Forms;

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
        }

        private void DatabaseOptimize_Click(object sender, EventArgs e)
        {
            Enabled = false;

            using var sqlite = App.Database.Open();
            using var command = sqlite.CreateCommand();

            command.CommandText = "VACUUM";
            command.ExecuteNonQuery();

            command.CommandText = "ANALYZE";
            command.ExecuteNonQuery();

            command.CommandText = "PRAGMA wal_checkpoint(FULL)";
            command.ExecuteNonQuery();

            Enabled = true;
        }

        private void DatabaseCheckIntegrity_Click(object sender, EventArgs e)
        {
            Enabled = false;

            using var sqlite = App.Database.Open();
            using var command = sqlite.CreateCommand();
            command.CommandText = "PRAGMA integrity_check";
            object? result = command.ExecuteScalar();

            if (result is string state)
            {
                if (state.Equals("ok", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "No se encontraron problemas de integridad en la base de datos.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                /// TODO: Handle corrupted DB case.
            }

            Enabled = true;
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
