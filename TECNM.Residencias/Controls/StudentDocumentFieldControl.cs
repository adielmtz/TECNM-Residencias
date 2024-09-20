using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Controls
{
    public sealed partial class StudentDocumentFieldControl : UserControl
    {
        private readonly List<(string, string)> items;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private Document _document = new Document();
        private string _filename = "";
        private bool _isNewFile = true;

        public StudentDocumentFieldControl()
        {
            InitializeComponent();

            items = [
                ("Solicitud de residencia",              "SOLICITUD_RESIDENCIA"),
                ("Carta de presentación",                "CARTA_PRESENTACION"),
                ("Carta de aceptación",                  "CARTA_ACEPTACION"),
                ("Constancia de servicio social",        "CONSTANCIA_SERVICIO_SOCIAL"),
                ("Anteproyecto",                         "ANTEPROYECTO"),
                ("Autorización de anteproyecto",         "AUTORIZACION_ANTEPROYECTO"),
                ("Asignación de asesor",                 "ASIGNACION_ASESOR"),
                ("1er. reporte de asesoría",             "PRIMER_REPORTE"),
                ("2do. reporte de asesoría",             "SEGUNDO_REPORTE"),
                ("Evaluación final",                     "EVALUACION_FINAL"),
                ("Reporte final (PDF)",                  "REPORTE_FINAL"),
                ("Portada del reporte final con firmas", "PORTADA_REPORTE_FINAL"),
                ("Carta de liberación o terminación",    "CARTA_TERMINACION"),
                ("Otro",                                 "OTRO"),
            ];

            foreach (var tuple in items)
            {
                cb_DocumentType.Items.Add(tuple.Item1);
            }
        }

        public StudentDocumentFieldControl(Document entity) : this()
        {
            _document = entity;
            cb_DocumentType.SelectedIndex = entity.Type;
            lbl_DocumentName.Text = entity.OriginalName;
            _filename = entity.FullPath;
            _isNewFile = false;
        }

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

                return items[index].Item2;
            }
        }

        public bool IsNewFile => _isNewFile;

        public EventHandler? Removed;

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
                await ComputeHash(_tokenSource.Token);
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
                _tokenSource.Cancel();
                Removed?.Invoke(this, EventArgs.Empty);
            }
        }

        private async Task ComputeHash(CancellationToken cancellationToken)
        {
            try
            {
                await using var stream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var digest = SHA256.Create();
                byte[] result = await digest.ComputeHashAsync(stream, cancellationToken);

                var builder = new StringBuilder(result.Length * 2);
                foreach (byte b in result)
                {
                    builder.AppendFormat("{0:X}", b);
                }

                _document.Size = stream.Length;
                _document.Hash = builder.ToString();
            }
            catch (OperationCanceledException)
            {
                // Do nothing with the exception
            }
        }
    }
}
