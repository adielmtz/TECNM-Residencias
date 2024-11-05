namespace TECNM.Residencias.Controls;

using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators;
using TECNM.Residencias.Services;

public sealed partial class DocumentCollectionControl : UserControl
{
    private readonly AbstractValidator<Document> _validator = new DocumentValidator();
    private readonly List<DocumentType> _documentTypes = [];
    private readonly List<Document> _deleted = [];

    public DocumentCollectionControl()
    {
        InitializeComponent();
    }

    private void DocumentCollectionControl_Load(object sender, EventArgs e)
    {
        if (_documentTypes.Count == 0)
        {
            using var context = new AppDbContext();
            _documentTypes.AddRange(context.Documents.EnumerateDocumentTypes());
        }
    }

    public void Add(Document document)
    {
        var control = new DocumentListItemControl(_documentTypes, document, OnDocumentDeleted);
        flp_ControlContainer.Controls.Add(control);
    }

    public void Add(FileInfo fileInfo)
    {
        var control = new DocumentListItemControl(_documentTypes, fileInfo, OnDocumentDeleted);
        flp_ControlContainer.Controls.Add(control);
    }

    public void RemoveAll(DbSet<Document> set)
    {
        IList<DocumentListItemControl> controls = flp_ControlContainer.Controls.Cast<DocumentListItemControl>().ToList();
        for (int i = 0; i < controls.Count; i++)
        {
            DocumentListItemControl item = controls[i];
            flp_ControlContainer.Controls.Remove(item);

            if (!item.IsNew)
            {
                _deleted.Add(item.Document);
            }
        }

        PurgeDeletedDocuments(set);
    }

    public async Task<bool> SaveAsync(DbSet<Document> set, Student owner)
    {
        PurgeDeletedDocuments(set);

        if (!CheckValidDocuments(owner))
        {
            return false;
        }

        foreach (var control in flp_ControlContainer.Controls)
        {
            if (control is DocumentListItemControl listItem && listItem.IsNew)
            {
                await SaveDocument(set, owner, listItem.Document, listItem.DocumentType!);
            }
        }

        return true;
    }

    private bool CheckValidDocuments(Student owner)
    {
        foreach (var control in flp_ControlContainer.Controls)
        {
            if (control is DocumentListItemControl listItem && listItem.IsNew)
            {
                Document document = listItem.Document;
                document.StudentId = owner.Id;

                ValidationResult result = _validator.Validate(document);
                if (!result.IsValid)
                {
                    Debug.Assert(result.Errors.Count > 0);
                    MessageBox.Show(result.Errors[0].ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        return true;
    }

    private void PurgeDeletedDocuments(DbSet<Document> set)
    {
        foreach (Document document in _deleted)
        {
            int result = set.Remove(document);
            if (result > 0)
            {
                StorageService.DeleteFile(document.FullPath);
            }
        }
    }

    private async Task SaveDocument(DbSet<Document> set, Student owner, Document original, DocumentType type)
    {
        Document stored = await StorageService.SaveFileAsync(owner, original, type);
        Debug.Assert(stored.StudentId == owner.Id);
        set.Add(stored);
    }

    private void OnDocumentDeleted(DocumentListItemControl control)
    {
        flp_ControlContainer.Controls.Remove(control);
        if (!control.IsNew)
        {
            _deleted.Add(control.Document);
        }
    }
}
