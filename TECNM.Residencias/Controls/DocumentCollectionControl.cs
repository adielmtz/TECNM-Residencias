using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Controls
{
    public sealed partial class DocumentCollectionControl : UserControl
    {
        private readonly IList<Document> _deleted = [];

        public DocumentCollectionControl()
        {
            InitializeComponent();
        }

        public void Add(Document document)
        {
            var control = new DocumentListItemControl(document, OnDocumentDeleted);
            flp_ControlContainer.Controls.Add(control);
        }

        public void Add(string filename)
        {
            var document = new Document
            {
                Type = 0,
                FullPath = filename,
                OriginalName = Path.GetFileName(filename),
            };

            Add(document);
        }

        public async Task SaveAsync(DbSet<Document> set, Student owner)
        {
            PurgeDeletedDocuments(set);

            foreach (var control in flp_ControlContainer.Controls)
            {
                if (control is DocumentListItemControl listItem && listItem.IsNew)
                {
                    await SaveDocument(set, owner, listItem.Document);
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

        private async Task SaveDocument(DbSet<Document> set, Student owner, Document original)
        {
            Document stored = await StorageService.SaveFileAsync(owner, original);
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
}
