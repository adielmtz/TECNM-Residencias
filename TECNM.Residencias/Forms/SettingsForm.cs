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

        private string GetSqliteVersion()
        {
            using var context = new AppDbContext();
            using var command = context.Database.CreateCommand();
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
