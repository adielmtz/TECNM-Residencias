using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Services;

namespace TECNM.Residencias.Controls
{
    public sealed partial class StudentDocumentFieldControl : UserControl
    {
        public static readonly IReadOnlyList<string> DocumentTypes = [
            "Solicitud de residencia",
            "Carta de presentación",
            "Carta de aceptación",
            "Constancia de servicio social",
            "Anteproyecto",
            "Autorización de anteproyecto",
            "Asignación de asesor",
            "1er. reporte de asesoría",
            "2do. reporte de asesoría",
            "Evaluación final",
            "Reporte final (PDF)",
            "Portada del reporte final con firmas",
            "Carta de liberación o terminación",
            "Otro",
        ];
        private Document _document = new Document();
        private string _extension = "";
        private bool _isNewFile = true;

        public StudentDocumentFieldControl()
        {
            InitializeComponent();

            foreach (string type in DocumentTypes)
            {
                cb_DocumentType.Items.Add(type);
            }
        }

        public StudentDocumentFieldControl(Document document) : this()
        {
            _document = document;
            _extension = Path.GetExtension(document.FullPath);
            _isNewFile = false;

            lbl_DocumentName.Text = document.OriginalName;
            cb_DocumentType.SelectedIndex = document.Type;

            cb_DocumentType.Enabled = false;
            btn_UploadFile.Enabled = false;
        }

        public bool IsNewFile => _isNewFile;

        public Document Document => _document;

        public EventHandler? Removed;

        public async Task SaveDocumentAsync(Student student)
        {
            if (!_isNewFile)
            {
                return;
            }

            int type = cb_DocumentType.SelectedIndex;
            _document.StudentId = student.Id;
            await DocumentStorageService.SaveDocumentAsync(_document);

            string studentId = student.Id.ToString("00000000");
            string tempFileName = _document.FullPath;
            string finalDirectory = Path.Combine(App.DocumentArchiveDirectory, studentId.Substring(0, 2), studentId);
            _document.FullPath = Path.Combine(finalDirectory, $"{studentId}_{_document.Hash}{_extension}");

            Directory.CreateDirectory(finalDirectory);
            File.Move(tempFileName, _document.FullPath, true);
        }

        private void UploadFile_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.RestoreDirectory = true;
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _document.FullPath = dialog.FileName;
                _extension = Path.GetExtension(_document.FullPath);
                lbl_DocumentName.Text = Path.GetFileName(_document.FullPath);
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_document.FullPath) || !File.Exists(_document.FullPath))
            {
                MessageBox.Show("No se puede abrir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var info = new ProcessStartInfo();
            info.FileName = _document.FullPath;
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
    }
}
