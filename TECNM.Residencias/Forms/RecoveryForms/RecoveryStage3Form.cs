namespace TECNM.Residencias.Forms.RecoveryForms;

using System;
using System.Diagnostics;
using System.Windows.Forms;
using TECNM.Residencias.Forms.RecoveryForms.Utils;
using TECNM.Residencias.Services;

public sealed partial class RecoveryStage3Form : Form
{
    private Form? _parent;
    private ArchiveWrapper? _archive;
    private int _selectedIndex = -1;

    public RecoveryStage3Form()
    {
        InitializeComponent();
    }

    internal RecoveryStage3Form(Form parent, ArchiveWrapper archive, int selectedIndex) : this()
    {
        _parent = parent;
        _archive = archive;
        _selectedIndex = selectedIndex;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        btn_Cancel.Click += RecoveryService.CancelRecoveryProcess_ClickHandler;

        if (_archive is not null)
        {
            ArchiveWrapper archive = _archive;
            EntryWrapper entry = archive.Databases[_selectedIndex];

            lbl_DbVersion.Text = $"Restaurando a la versión guardada el {entry.Timestamp:F}";
            lbl_FileCount.Text = $"Se restaurarán {archive.Entries.Count} archivos.";
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        RecoveryService.CancelRecoveryProcess_FormClosingHandler(e);
    }

    private void GoNext_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            """
            Está a punto de iniciar el proceso de restauración de respaldo.
            Esto SOBREESCRIBIRÁ toda la información existente en el sistema.
            Si prefiere no continuar, haga click en 'Cancelar'.
            """,
            "Advertencia",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning
        );

        if (result != DialogResult.OK)
        {
            return;
        }

        Debug.Assert(_archive is not null);
        Debug.Assert(_selectedIndex >= 0);

        var form = new RecoveryStage4Form(_archive, _selectedIndex);
        form.Show();
        Hide();
    }

    private void GoBack_Click(object sender, EventArgs e)
    {
        Debug.Assert(_parent is not null);
        _parent.Show();
        Close();
    }
}
