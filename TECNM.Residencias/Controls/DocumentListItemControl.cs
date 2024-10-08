namespace TECNM.Residencias.Controls;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

public partial class DocumentListItemControl : UserControl
{
    private Document _document = new Document();
    private Action<DocumentListItemControl>? _onDelete;

    public DocumentListItemControl()
    {
        InitializeComponent();
    }

    public DocumentListItemControl(Document document, Action<DocumentListItemControl> onDelete) : this()
    {
        _document = document;
        lbl_OriginalName.Text = document.OriginalName;
        _onDelete = onDelete;
    }

    public Document Document => _document;

    public DocumentType DocumentType => (DocumentType) cb_DocumentType.SelectedItem!;

    public bool IsNew => _document.Id == 0;


    private void DocumentListItemControl_Load(object sender, EventArgs e)
    {
        using var context = new AppDbContext();

        foreach (DocumentType doctype in context.DocumentTypes.EnumerateAll())
        {
            int index = cb_DocumentType.Items.Add(doctype);
            if (doctype.Id == _document.TypeId)
            {
                cb_DocumentType.SelectedIndex = index;
            }
        }

        cb_DocumentType.SelectedIndex = 0;
        cb_DocumentType.SelectedIndexChanged += DocumentType_SelectedIndexChanged;

        if (!IsNew)
        {
            cb_DocumentType.Enabled = false;
        }
    }

    private void DocumentType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var type = (DocumentType) cb_DocumentType.SelectedItem!;
        _document.TypeId = type.Id;
    }

    private void OpenFile_Click(object sender, EventArgs e)
    {
        string path = _document.FullPath;

        if (string.IsNullOrEmpty(path) || !File.Exists(path))
        {
            MessageBox.Show(
                "No se puede abrir el archivo.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        var info = new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true,
        };

        Process.Start(info);
    }

    private void DeleteFile_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "¿Eliminar este documento?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Yes)
        {
            _onDelete?.Invoke(this);
        }
    }
}
