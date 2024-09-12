using System;
using System.Windows.Forms;

namespace TECNM.Residencias.Services
{
    internal sealed class FormConfirmClosingService
    {
        private readonly Form _form;
        private readonly Control? _button;
        private bool _promptExitConfirm = false;

        public FormConfirmClosingService(Form form)
        {
            _form = form;
            _button = (Control?) form.CancelButton;

            _form.FormClosing += Form_FormClosing;
            if (_button != null)
            {
                _button.Click += CancelButton_Click;
            }
        }

        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_promptExitConfirm)
            {
                DialogResult result = MessageBox.Show(
                    "¿Salir del formulario? Se perderán los cambios no guardados.",
                    "Confirmar acción",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    _promptExitConfirm = false;
                }
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            _promptExitConfirm = true;
        }
    }
}
