namespace TECNM.Residencias.Controls;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;
using TECNM.Residencias.Services;

public sealed partial class DocumentCollectionControl : UserControl
{
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
            _documentTypes.AddRange(context.DocumentTypes.EnumerateAll());
        }
    }

    public void Add(Document document)
    {
        var control = new DocumentListItemControl(_documentTypes, document, OnDocumentDeleted);
        flp_ControlContainer.Controls.Add(control);
    }

    public void Add(string filename)
    {
        var document = new Document
        {
            TypeId = 0,
            FullPath = filename,
            OriginalName = Path.GetFileName(filename),
        };

        Add(document);
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

    public async Task SaveAsync(DbSet<Document> set, Student owner)
    {
        PurgeDeletedDocuments(set);

        foreach (var control in flp_ControlContainer.Controls)
        {
            if (control is DocumentListItemControl listItem && listItem.IsNew)
            {
                await SaveDocument(set, owner, listItem.Document, listItem.DocumentType!);
            }
        }
    }

    private void PurgeDeletedDocuments(DbSet<Document> set)
    {
        foreach (Document document in _deleted)
        {
            int result = set.Delete(document);
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
        set.Insert(stored);
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
