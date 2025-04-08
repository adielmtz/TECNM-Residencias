namespace TECNM.Residencias.Controls;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Services;

public partial class DocumentListItemControl : UserControl
{
    private static readonly DocumentType DocumentTypePlaceholder = new DocumentType { Id = -1, Label = "SELECCIONAR", Tag = "NONE", };

    private readonly List<DocumentType> _documentTypes = [DocumentTypePlaceholder];
    private Action<DocumentListItemControl>? _onDelete;
    private Document _document = new Document();
    private string _fullpath = "";

    public DocumentListItemControl()
    {
        InitializeComponent();
    }

    public DocumentListItemControl(IReadOnlyList<DocumentType> types, FileInfo fileInfo, Action<DocumentListItemControl> onDelete) : this()
    {
        _fullpath = fileInfo.FullName;
        _document.Location = StorageService.GetDocumentLocation(_fullpath);
        _document.OriginalName = fileInfo.Name;
        _document.Size = fileInfo.Length;
        _onDelete = onDelete;
        lbl_OriginalName.Text = fileInfo.Name;
        _documentTypes.AddRange(types);
    }

    public DocumentListItemControl(IReadOnlyList<DocumentType> types, Document document, Action<DocumentListItemControl> onDelete) : this()
    {
        Debug.Assert(document.Id > 0, "Document must exist in the database and have a valid rowid!");
        _fullpath = StorageService.GetDocumentPath(document);
        _document = document;
        _onDelete = onDelete;
        lbl_OriginalName.Text = document.OriginalName;
        _documentTypes.AddRange(types);
    }

    public Document Document => _document;

    public DocumentType DocumentType => _documentTypes[cb_DocumentType.SelectedIndex];

    public string FullPath => _fullpath;

    public bool IsNew => _document.Id == 0;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        bool selectedItem = false;
        foreach (DocumentType type in _documentTypes)
        {
            int index = cb_DocumentType.Items.Add(type);
            if (type.Id == _document.TypeId)
            {
                cb_DocumentType.SelectedIndex = index;
                selectedItem = true;
            }
        }

        if (!selectedItem)
        {
            cb_DocumentType.SelectedIndex = 0;
        }

        if (IsNew)
        {
            cb_DocumentType.Enabled = true;
            cb_DocumentType.SelectedIndexChanged += DocumentType_SelectedIndexChanged;
        }
    }

    private void DocumentType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _document.TypeId = DocumentType.Id;
    }

    private void OpenFile_Click(object sender, EventArgs e)
    {
        string path = _fullpath;

        if (string.IsNullOrEmpty(path) || !File.Exists(path))
        {
            MessageBox.Show(
                "No se pudo abrir el archivo. Puede que el archivo no exista o se haya movido de lugar.",
                "Abrir archivo.",
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
