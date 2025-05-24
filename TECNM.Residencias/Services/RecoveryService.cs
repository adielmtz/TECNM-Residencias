namespace TECNM.Residencias.Services;

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

internal static class RecoveryService
{
    private static bool s_supressPrompt = false;

    public static void Initialize()
    {
        // Allow the parent process a grace period to shutdown gracefully before proceeding.
        Thread.Sleep(TimeSpan.FromSeconds(3));
        KillOtherProcesses();
    }

    public static void SupressNextExitPrompt()
    {
        s_supressPrompt = true;
    }

    public static void CancelRecoveryProcess_ClickHandler(object? sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            """
            ¿Salir del proceso de recuperación?
            """,
            "Cancelar proceso",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
            Environment.Exit(0);
        }
    }

    public static void CancelRecoveryProcess_FormClosingHandler(FormClosingEventArgs e)
    {
        if (s_supressPrompt)
        {
            s_supressPrompt = false;
            return;
        }

        DialogResult result = MessageBox.Show(
            """
            ¿Salir del proceso de recuperación?
            """,
            "Cancelar proceso",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
            Environment.Exit(0);
        }
    }

    public static void KillOtherProcesses()
    {
        Process self = Process.GetCurrentProcess();
        Process[] processes = Process.GetProcessesByName(self.ProcessName);

        foreach (Process process in processes)
        {
            if (process.Id != self.Id)
            {
                process.Kill();
            }
        }
    }
}
