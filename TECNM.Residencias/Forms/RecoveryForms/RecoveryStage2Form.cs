namespace TECNM.Residencias.Forms.RecoveryForms;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Forms.RecoveryForms.Utils;
using TECNM.Residencias.Services;

public sealed partial class RecoveryStage2Form : Form
{
    private Form? _parent;
    private string? _filename;
    private ArchiveWrapper? _archive;

    public RecoveryStage2Form()
    {
        InitializeComponent();
    }

    internal RecoveryStage2Form(Form parent, string filename) : this()
    {
        _parent = parent;
        _filename = filename;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        btn_Cancel.Click += RecoveryService.CancelRecoveryProcess_ClickHandler;
        await TryLoadArchiveAsync();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        RecoveryService.CancelRecoveryProcess_FormClosingHandler(e);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _archive?.Dispose();
    }

    private void BackupVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = lb_BackupVersion.SelectedIndex;
        btn_Next.Enabled = index >= 0 && index < _archive!.Databases.Count;
    }

    private void GoNext_Click(object sender, EventArgs e)
    {
        int index = lb_BackupVersion.SelectedIndex;

        Debug.Assert(_archive is not null);
        Debug.Assert(index >= 0 && index < _archive!.Databases.Count);

        var form = new RecoveryStage3Form(this, _archive, index);
        form.Show();
        Hide();
    }

    private void GoBack_Click(object sender, EventArgs e)
    {
        Debug.Assert(_parent is not null);
        _parent.Show();
        Close();
    }

    private async Task TryLoadArchiveAsync()
    {
        string? filename = _filename;
        if (string.IsNullOrEmpty(filename))
        {
            return;
        }

        ArchiveWrapper archive = ArchiveWrapper.OpenArchive(filename);
        await archive.LoadEntriesAsync();

        for (int i = 0; i < archive.Databases.Count; i++)
        {
            EntryWrapper entry = archive.Databases[i];
            lb_BackupVersion.Items.Add($"{i + 1}: {entry.Timestamp:F}");
        }

        _archive = archive;
        pb_UnpackProgress.Visible = false;
    }
}
