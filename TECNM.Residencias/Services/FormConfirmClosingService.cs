namespace TECNM.Residencias.Services;

using System;
using System.Windows.Forms;

internal sealed class FormConfirmClosingService
{
    private readonly Form _form;
    private readonly Control? _button;
    private Action? _closeAction;
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

    public string Prompt { get; set; } = "¿Salir del formulario? Se perderán los cambios no guardados.";

    public FormConfirmClosingService(Form form, Action action) : this(form)
    {
        _closeAction = action;
    }

    private void Form_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (_promptExitConfirm)
        {
            DialogResult result = MessageBox.Show(
                Prompt,
                "Confirmar acción",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                _promptExitConfirm = false;
                return;
            }

            _closeAction?.Invoke();
        }
    }

    private void CancelButton_Click(object? sender, EventArgs e)
    {
        _promptExitConfirm = true;
    }
}
