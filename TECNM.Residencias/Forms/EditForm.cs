namespace TECNM.Residencias.Forms;

using System;
using System.Windows.Forms;

public class EditForm : Form
{
    private bool _suppressPrompt = true;

    public string CancelPromptTitle { get; set; } = "Confirmar salida";

    public string CancelPromptMessage { get; set; } = "¿Salir del formulario? Se perderán los cambios no guardados.";

    public Action? CancelledEditHandler;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (CancelButton is Button button)
        {
            button.Click += CancelButton_Click;
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);

        if (!_suppressPrompt)
        {
            DialogResult result = MessageBox.Show(
                CancelPromptMessage,
                CancelPromptTitle,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                _suppressPrompt = true;
            }
            else if (result == DialogResult.OK)
            {
                CancelledEditHandler?.Invoke();
            }
        }
    }

    private void CancelButton_Click(object? sender, EventArgs e)
    {
        _suppressPrompt = false;
    }
}
