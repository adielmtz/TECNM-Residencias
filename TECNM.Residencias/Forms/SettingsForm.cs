namespace TECNM.Residencias.Forms;

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

public sealed partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
        Text = $"Configuración | {App.Name}";
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        lbl_SqliteVersion.Text = "SQLite " + GetSqliteVersion();
        lbl_AppVersion.Text = "Versión " + App.Version.ToString(fieldCount: 3);

#if DEBUG
        lbl_AppVersion.Text += "-dev";
#endif

        LoadSettings();
    }

    private void DatabaseOptimize_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "¿Desea ejecutar la optimización de la base de datos? " +
            "Tenga en cuenta que el proceso puede llegar a tardar " +
            "varios minutos dependiendo del tamaño y la cantidad " +
            "de información almacenada.",
            "Confirmar acción",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Cancel)
        {
            return;
        }

        Enabled = false;

        using var sqlite = App.Database.CreateConnection();

        sqlite.Execute("VACUUM");
        sqlite.Execute("ANALYZE");
        sqlite.Execute("PRAGMA wal_checkpoint(FULL)");

        Enabled = true;

        MessageBox.Show("Base de datos optimizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void DatabaseBackup_Click(object sender, EventArgs e)
    {
        using var dialog = new DialogBackupForm();
        dialog.ShowDialog();
    }

    private void OpenIntegrityCheckDialog_Click(object sender, EventArgs e)
    {
        using var dialog = new IntegrityCheckForm();
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
        LoadSettings();
    }

    private void SaveAppSettings_Click(object sender, EventArgs e)
    {
        AppSettings.Default.DefaultCompanyType = (CompanyType) cb_CompanyType.SelectedIndex - 1;
        AppSettings.Default.DefaultStudentCareer = ((Career) cb_StudentCareer.SelectedItem!).Id;
        AppSettings.Default.DefaultSemesterFilter = cb_DefaultSemesterFilter.SelectedIndex - 1;
        AppSettings.Default.EnableStudentEmailAutocomplete = chk_EnableEmailAutocomplete.Checked;
        AppSettings.Default.Save();
        Close();
    }

    private void LoadSettings()
    {
        cb_CompanyType.Items.Clear();
        cb_CompanyType.Items.Add("Ninguno");
        cb_CompanyType.SelectedIndex = 0;

        CompanyType[] companyTypes = Enum.GetValues<CompanyType>().OrderBy(it => (int) it).ToArray();
        foreach (CompanyType type in companyTypes)
        {
            int index = cb_CompanyType.Items.Add(type.GetLocalizedName());
            if (AppSettings.Default.DefaultCompanyType == type)
            {
                cb_CompanyType.SelectedIndex = index;
            }
        }

        cb_StudentCareer.Items.Clear();
        cb_StudentCareer.Items.Add(new Career { Id = 0, Name = "Ninguno" });
        cb_StudentCareer.SelectedIndex = 0;

        using var context = new AppDbContext();
        foreach (Career career in context.Careers.EnumerateAll(enabled: true))
        {
            int index = cb_StudentCareer.Items.Add(career);
            if (AppSettings.Default.DefaultStudentCareer == career.Id)
            {
                cb_StudentCareer.SelectedIndex = index;
            }
        }

        cb_DefaultSemesterFilter.SelectedIndex = AppSettings.Default.DefaultSemesterFilter + 1;
        chk_EnableEmailAutocomplete.Checked = AppSettings.Default.EnableStudentEmailAutocomplete;
    }

    private string GetSqliteVersion()
    {
        using var sqlite = App.Database.CreateConnection();
        return sqlite.ServerVersion;
    }
}
