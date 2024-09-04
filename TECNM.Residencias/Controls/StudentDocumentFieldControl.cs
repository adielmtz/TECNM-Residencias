using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Controls
{
    public sealed partial class StudentDocumentFieldControl : UserControl
    {
        private Document _document = new Document();
        private string _filename = "";
        private bool _isNewFile = true;

        public Document Document => _document;

        public string SelectedFile => _filename;

        public string TypeName
        {
            get
            {
                int index = cb_DocumentType.SelectedIndex;

                if (index == -1)
                {
                    return "";
                }

                return (string) cb_DocumentType.Items[index]!;
            }
        }

        public bool IsNewFile => _isNewFile;

        public EventHandler? Removed;

        public StudentDocumentFieldControl()
        {
            InitializeComponent();
        }

        public StudentDocumentFieldControl(Document entity) : this()
        {
            _document = entity;
            cb_DocumentType.SelectedIndex = entity.Type;
            lbl_DocumentName.Text = entity.OriginalName;
            _filename = entity.FullPath;
            _isNewFile = false;
        }

        private void DocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _document.Type = cb_DocumentType.SelectedIndex;
        }

        private async void UploadFile_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (!_isNewFile || !string.IsNullOrEmpty(_filename))
            {
                result = MessageBox.Show(
                    "Se sobreescribirá el archivo actual. ¿Continuar?",
                    "Confirmar acción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            using var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.RestoreDirectory = true;
            result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _filename = dialog.FileName;
                _document.FullPath = _filename;
                _document.OriginalName = Path.GetFileName(_filename);
                lbl_DocumentName.Text = _document.OriginalName;
                _isNewFile = true;
                await ComputeHash();
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filename) || !File.Exists(_filename))
            {
                MessageBox.Show("No se puede abrir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var info = new ProcessStartInfo();
            info.FileName = _filename;
            info.UseShellExecute = true;
            Process.Start(info);
        }

        private void RemoveDocument_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de que quiere eliminar este documento?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                Removed?.Invoke(this, EventArgs.Empty);
            }
        }

        private async Task ComputeHash()
        {
            await using var stream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var digest = SHA256.Create();
            byte[] result = await digest.ComputeHashAsync(stream);

            var builder = new StringBuilder(result.Length * 2);
            foreach (byte b in result)
            {
                builder.AppendFormat("{0:x}", b);
            }

            _document.Size = stream.Length;
            _document.Hash = builder.ToString();
        }
    }
}
