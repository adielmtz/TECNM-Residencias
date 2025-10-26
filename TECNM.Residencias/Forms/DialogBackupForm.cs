namespace TECNM.Residencias.Forms;

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data;
using TECNM.Residencias.Services;

public sealed partial class DialogBackupForm : EditForm
{
    private static readonly TimeSpan refreshFrequency = TimeSpan.FromMilliseconds(100);
    private CancellationTokenSource? tokenSource;

    public DialogBackupForm()
    {
        InitializeComponent();
        CancelledEditHandler = CancelAndCleanup;
        CancelPromptMessage = "¿Cancelar copia de seguridad?";
        lbl_FileCount.Text = "";
    }

    private void ChoseBackupDestination_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            tb_BackupLocation.Text = dialog.SelectedPath;
            btn_StartBackup.Enabled = true;
        }
    }

    private async void StartBackup_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            """
            ¿Está listo para iniciar el proceso de copia de seguridad?
            Este proceso puede tardar horas en completarse.
            """,
            "Confirmar",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Cancel)
        {
            return;
        }

        string destination = tb_BackupLocation.Text;
        DateTime backupTime = DateTime.Now;

        AppSettings.Default.LastStorageBackupDate = backupTime;
        AppSettings.Default.Save();

        gb_Config.Enabled = false;
        gb_Status.Enabled = true;

        if (chk_DatabaseBackup.Checked)
        {
            RunDatabaseBackup(backupTime);
        }

        try
        {
            string backupFile = await RunStorageBackupAsync(destination, chk_EnableCompression.Checked, backupTime);
            if (chk_OpenBackupFolder.Checked)
            {
                var info = new ProcessStartInfo();
                info.FileName = "explorer.exe";
                info.ArgumentList.Add(tb_BackupLocation.Text);
                Process.Start(info);
            }

            MessageBox.Show(
                "Copia de seguridad guardada en: " + backupFile,
                "Acción completada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        catch
        {
        }
        finally
        {
            Close();
        }
    }

    private void RunDatabaseBackup(DateTime backupTime)
    {
        SetProgressBarMaximum(1);
        UpdateProgressStatus("Respaldando base de datos...", 1);

        using var sqlite = App.Database.CreateConnection();
        string target = App.DatabaseBackupDirectory;

        using var backup = new DbBackup(sqlite, target, backupTime);
        backup.Execute();
    }

    private async Task<string> RunStorageBackupAsync(string destination, bool compress, DateTime backupTime)
    {
        var backup = new StorageBackupService(App.FileStorageDirectory, destination, backupTime);
        backup.Compress = compress;
        tokenSource = new CancellationTokenSource();

        SetProgressBarMaximum(1);
        UpdateProgressStatus("Preparando archivos para copia de seguridad...", 1);
        int count = await backup.PrepareFilesAsync(tokenSource.Token);

        SetProgressBarMaximum(count);
        UpdateProgressStatus("Iniciando copia de seguridad...", 0);

        var stopwatch = Stopwatch.StartNew();
        var progress = new Progress<(string, int)>(((string, int) x) =>
        {
            if (stopwatch.Elapsed < refreshFrequency && x.Item2 < count)
            {
                return;
            }

            stopwatch.Restart();
            UpdateProgressStatus(x.Item1, x.Item2);
        });

        return await backup.ExecuteAsync(progress, tokenSource.Token);
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

    private void CancelAndCleanup()
    {
        tokenSource?.Cancel();
    }
}
