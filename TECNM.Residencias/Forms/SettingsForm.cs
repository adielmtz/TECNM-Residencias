namespace TECNM.Residencias.Forms;

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Services;

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
        sqlite.Execute("VACUUM;");
        sqlite.Execute("PRAGMA optimize;");
        sqlite.Execute("PRAGMA wal_checkpoint(FULL);");

        Enabled = true;

        MessageBox.Show("Base de datos optimizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void CreateBackup_Click(object sender, EventArgs e)
    {
        using var dialog = new DialogBackupForm();
        dialog.ShowDialog();
    }

    private void RestoreBackup_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            """
            Se iniciará el proceso de restauración de respaldo.
            La aplicación se cerrará y se volverá a iniciar en
            modo de recuperación.
            """,
            "Iniciar proceso de restauración",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
        );

        if (result != DialogResult.OK)
        {
            return;
        }

        var info = new ProcessStartInfo();
        info.FileName = Application.ExecutablePath;
        info.Arguments = "--recovery-mode";

        Process.Start(info);
        Environment.Exit(0);
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

        AppSettings.Default.DatabaseBackupFrequency = cb_DbBackup.SelectedIndex switch
        {
            0 => TimeSpan.FromDays(1), // Diario
            1 => TimeSpan.FromDays(3), // Cada 3 días (default)
            2 => TimeSpan.FromDays(7), // Semanal
            _ => throw new UnreachableException(),
        };

        AppSettings.Default.StorageBackupFrequency = cb_FullBackup.SelectedIndex switch
        {
            0 => TimeSpan.FromDays(7),  // Semanal,
            1 => TimeSpan.FromDays(15), // Quincenal
            2 => TimeSpan.FromDays(30), // Mensual
            _ => throw new UnreachableException(),
        };

        AppSettings.Default.Save();
        Close();
    }

    private void LoadSettings()
    {
        cb_CompanyType.Items.Clear();
        cb_CompanyType.Items.Add("Ninguno");
        cb_CompanyType.SelectedIndex = 0;

        cb_DbBackup.Items.Clear();
        cb_DbBackup.Items.AddRange(["Todos los días", "Cada 3 días", "Semanalmente"]);
        cb_DbBackup.SelectedIndex = AppSettings.Default.DatabaseBackupFrequency.Days switch
        {
            1 => 0,
            3 => 1,
            7 => 2,
            _ => 1,
        };

        cb_FullBackup.Items.Clear();
        cb_FullBackup.Items.AddRange(["Semanalmente", "Cada 15 días", "Mensualmente"]);
        cb_FullBackup.SelectedIndex = AppSettings.Default.StorageBackupFrequency.Days switch
        {
             7 => 0,
            15 => 1,
            30 => 2,
             _ => 2,
        };

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

    private async void DoUpdatesCheck_Click(object sender, EventArgs e)
    {
        btn_UpdateCheck.Enabled = false;

        bool available = await AppUpdateService.CheckForUpdatesAsync();
        if (!available)
        {
            MessageBox.Show(
                "La versión más reciente ya está instalada.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        btn_UpdateCheck.Enabled = true;
    }
}
