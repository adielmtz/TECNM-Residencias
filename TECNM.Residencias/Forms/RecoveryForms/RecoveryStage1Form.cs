namespace TECNM.Residencias.Forms.RecoveryForms;

using System;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Services;

public sealed partial class RecoveryStage1Form : Form
{
    public RecoveryStage1Form()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        btn_Cancel.Click += RecoveryService.CancelRecoveryProcess_ClickHandler;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        RecoveryService.CancelRecoveryProcess_FormClosingHandler(e);
    }

    private void OpenFileDialog_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Multiselect = false,
            RestoreDirectory = true,
            Filter = "Archivos .zip (*.zip)|*.zip|Archivos .tar.gz (*.tar.gz)|*.tar.gz",
        };

        DialogResult result = dialog.ShowDialog();
        if (result != DialogResult.OK)
        {
            return;
        }

        tb_SelectedFile.Text = dialog.FileName;
        btn_Next.Enabled = true;
    }

    private void GoNext_Click(object sender, EventArgs e)
    {
        Debug.Assert(!string.IsNullOrEmpty(tb_SelectedFile.Text));
        var form = new RecoveryStage2Form(this, tb_SelectedFile.Text);
        form.Show();
        Hide();
    }
}
