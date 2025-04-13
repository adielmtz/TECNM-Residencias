namespace TECNM.Residencias;

using System;
using System.Linq;
using System.Windows.Forms;
using TECNM.Residencias.Forms;
using TECNM.Residencias.Forms.RecoveryForms;
using TECNM.Residencias.Services;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    internal static void Main(string[] args)
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        if (args.Length > 0 && args.Contains("--recovery-mode"))
        {
            RecoveryService.Initialize();
            Application.Run(new RecoveryStage1Form());
            return;
        }

        Application.Run(new MainWindow());
    }
}
