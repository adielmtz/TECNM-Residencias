namespace TECNM.Residencias.Services;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

internal static class FormManagerService
{
    private readonly static Dictionary<Type, Form> s_openForms = new();

    public static void OpenForm<T>() where T : Form, new()
    {
        Type type = typeof(T);
        Form? form;

        if (s_openForms.TryGetValue(type, out form))
        {
            form.WindowState = FormWindowState.Normal;
            form.Focus();
            return;
        }

        form = new T();
        form.FormClosed += FormClosedHandler;
        s_openForms[type] = form;
        form.Show();
    }

    public static DialogResult OpenDialog<T>() where T : Form, new()
    {
        using var dialog = new T();
        return dialog.ShowDialog();
    }

    public static void CloseAll()
    {
        foreach (Form form in s_openForms.Values)
        {
            form.Close();
        }
    }

    private static void FormClosedHandler(object? sender, FormClosedEventArgs e)
    {
        Debug.Assert(sender != null);
        s_openForms.Remove(sender.GetType());
    }
}
