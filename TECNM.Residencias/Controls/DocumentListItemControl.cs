namespace TECNM.Residencias.Controls;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

public partial class DocumentListItemControl : UserControl
{
    private readonly List<DocumentType> _documentTypes = [];
    private Document _document = new Document();
    private Action<DocumentListItemControl>? _onDelete;

    public DocumentListItemControl()
    {
        InitializeComponent();
    }

    public DocumentListItemControl(List<DocumentType> documentTypes, Document document, Action<DocumentListItemControl> onDelete) : this()
    {
        _documentTypes = documentTypes;
        _document = document;
        lbl_OriginalName.Text = document.OriginalName;
        _onDelete = onDelete;

        foreach (DocumentType type in _documentTypes)
        {
            cb_DocumentType.Items.Add(type);
        }
    }

    public Document Document => _document;

    public DocumentType DocumentType => _documentTypes[cb_DocumentType.SelectedIndex];

    public bool IsNew => _document.Id == 0;

    private void DocumentListItemControl_Load(object sender, EventArgs e)
    {
        if (!IsNew)
        {
            for (int i = 0; i < _documentTypes.Count; i++)
            {
                DocumentType type = _documentTypes[i];
                if (type.Id == _document.TypeId)
                {
                    cb_DocumentType.SelectedIndex = i;
                    break;
                }
            }

            cb_DocumentType.Enabled = false;
            return;
        }

        cb_DocumentType.SelectedIndex = 0;
        string filename = _document.OriginalName;

        for (int i = 0; i < _documentTypes.Count; i++)
        {
            string keywords = _documentTypes[i].Keywords;
            if (FilenameMatchesKeywords(filename, keywords))
            {
                cb_DocumentType.SelectedIndex = i;
                break;
            }
        }
    }

    private void DocumentType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _document.TypeId = DocumentType.Id;
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

    private bool FilenameMatchesKeywords(string filename, string keywords)
    {
        string normalized = NormalizeString(filename);
        string[] list = keywords.Split(',', StringSplitOptions.TrimEntries);

        foreach (string kw in list)
        {
            if (normalized.Contains(kw))
            {
                return true;
            }
        }

        return false;
    }

    private string NormalizeString(string str)
    {
        string normalized = str.Normalize(NormalizationForm.FormKD);
        var builder = new StringBuilder(str.Length);

        foreach (char c in normalized)
        {
            if (char.IsAsciiLetterOrDigit(c))
            {
                // Hack to convert ASCII char to lowercase
                builder.Append((char) (byte) (c | 0x20));
            }
        }

        return builder.ToString();
    }
}
