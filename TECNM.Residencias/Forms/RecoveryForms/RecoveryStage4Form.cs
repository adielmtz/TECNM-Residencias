namespace TECNM.Residencias.Forms.RecoveryForms;

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Forms.RecoveryForms.Utils;
using TECNM.Residencias.Services;

public sealed partial class RecoveryStage4Form : Form
{
    private static readonly TimeSpan s_refreshFrequency = TimeSpan.FromMilliseconds(100);

    private ArchiveWrapper? _archive;
    private int _selectedIndex = -1;

    public RecoveryStage4Form()
    {
        InitializeComponent();
    }

    internal RecoveryStage4Form(ArchiveWrapper archive, int selectedIndex) : this()
    {
        _archive = archive;
        _selectedIndex = selectedIndex;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await RestoreFilesAsync();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        _archive?.Dispose();
        RecoveryService.CancelRecoveryProcess_FormClosingHandler(e);
    }

    private async Task RestoreFilesAsync()
    {
        Debug.Assert(_archive is not null);
        Debug.Assert(_selectedIndex >= 0);

        ArchiveWrapper archive = _archive;
        EntryWrapper selectedEntry = _archive.Databases[_selectedIndex];

        SetProgressBarMaximum(1);
        UpdateProgressStatus("Preparando archivos para copia de seguridad...", 1);
        int count = archive.Entries.Count;

        SetProgressBarMaximum(count);
        UpdateProgressStatus("Iniciando copia de seguridad...", 0);

        var stopwatch = Stopwatch.StartNew();
        var progress = new Progress<(string, int)>(((string, int) x) =>
        {
            if (stopwatch.Elapsed < s_refreshFrequency && x.Item2 < count)
            {
                return;
            }

            stopwatch.Restart();
            UpdateProgressStatus(x.Item1, x.Item2);
        });

        string storageDirectory = App.FileStorageDirectory;
        await archive.ExtractEntriesAsync(storageDirectory, progress);

        string backupDatabase = Path.Combine(storageDirectory, selectedEntry.Name);
        RestoreDatabase(backupDatabase);

        EndRestoreAndRestart();
    }

    private void RestoreDatabase(string backupFilename)
    {
        using var source = new DbFactory(backupFilename).CreateConnection();
        using var target = App.Database.CreateConnection();
        target.SetPragma("journal_mode", "delete");
        source.BackupDatabase(target);
    }

    private void EndRestoreAndRestart()
    {
        MessageBox.Show(
            """
            La restauración del sistema se completó correctamente.
            La aplicación se reiniciará al cerrar la ventana.
            """,
            "Información",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );

        Process.Start(Application.ExecutablePath);
        Environment.Exit(0);
    }

    private void UpdateProgressStatus(string label, int value)
    {
        pb_Progress.Value = value;
        lbl_ProgressStatus.Text = label;
        lbl_FileCount.Text = $"{value} / {pb_Progress.Maximum}";
    }

    private void SetProgressBarMaximum(int maximum)
    {
        pb_Progress.Maximum = maximum;
        pb_Progress.Style = maximum > 1 ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;
        lbl_FileCount.Visible = maximum > 1;
    }
}
