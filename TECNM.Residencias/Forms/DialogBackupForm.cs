using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Forms
{
    public sealed partial class DialogBackupForm : Form
    {
        private readonly FormConfirmClosingService closeConfirmService;
        private BackupService? _backup;

        public DialogBackupForm()
        {
            InitializeComponent();
            closeConfirmService = new FormConfirmClosingService(this, CancelAndCleanup);
            closeConfirmService.Prompt = "¿Cancelar copia de seguridad?";
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
                "¿Iniciar copia de seguridad? Este proceso puede llegar a tardar horas.",
                "Confirmar",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
            {
                return;
            }

            gb_Config.Enabled = false;
            gb_Status.Enabled = true;

            var target = new DirectoryInfo(tb_BackupLocation.Text);
            await using var backup = new BackupService(target);
            backup.Compress = chk_EnableCompression.Checked;
            _backup = backup;

            lbl_ProgressStatus.Text = "Recolectando archivos...";
            pb_Progress.Maximum = 1;
            pb_Progress.Value = 1;
            await backup.CollectFiles();

            pb_Progress.Maximum = backup.FileCount;
            pb_Progress.Value = 0;
            pb_Progress.Style = ProgressBarStyle.Blocks;

            var progress = new Progress<(string, int)>(((string, int) value) =>
            {
                lbl_ProgressStatus.Text = value.Item1;
                lbl_FileCount.Text = $"{value.Item2} / {backup.FileCount} archivos respaldados";
                pb_Progress.Value = value.Item2;
            });

            try
            {
                await backup.BackupAsync(progress);

                if (chk_OpenBackupFolder.Checked)
                {
                    var info = new ProcessStartInfo();
                    info.FileName = "explorer.exe";
                    info.ArgumentList.Add(tb_BackupLocation.Text);
                    Process.Start(info);
                }

                MessageBox.Show(
                    "Copia de seguridad guardada en: " + backup.BackupFile,
                    "Acción completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void CancelAndCleanup()
        {
            _backup?.Cancel();
        }
    }
}
