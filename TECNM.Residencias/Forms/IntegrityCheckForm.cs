namespace TECNM.Residencias.Forms;

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Services;

public sealed partial class IntegrityCheckForm : EditForm
{
    private CancellationTokenSource? cancellationToken;

    public IntegrityCheckForm()
    {
        InitializeComponent();
        Text = $"Comprobación de integridad de datos | {App.Name}";
        lbl_FileCount.Text = "";
        CancelledEditHandler += CancelAllTasks;
    }

    private void CancelAllTasks()
    {
        cancellationToken?.Cancel();
    }

    private void VerifyDb_CheckedChanged(object sender, EventArgs e)
    {
        chk_VerifyFKs.Enabled = chk_VerifyDb.Checked;

        if (!chk_VerifyFKs.Enabled)
        {
            chk_VerifyFKs.Checked = false;
        }
    }

    private void VerifyFileExists_CheckedChanged(object sender, EventArgs e)
    {
        chk_VerifyFileIntegrity.Enabled = chk_VerifyFileExist.Checked;

        if (!chk_VerifyFileIntegrity.Enabled)
        {
            chk_VerifyFileIntegrity.Checked = false;
        }
    }

    private async void StartCheck_Click(object sender, EventArgs e)
    {
        await using var logger = new LogWritter(lb_OutputLog);
        cancellationToken = new CancellationTokenSource();
        gb_Options.Enabled = false;

        try
        {
            Result result = await DoChecksAsync(logger);
            if (result == Result.Success)
            {
                MessageBox.Show(
                    """
                    Finalizó la comprobación de integridad sin encontrar errores.
                    """,
                    "Comprobación terminada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();
            }
            else
            {
                MessageBox.Show(
                    """
                    Se encontraron errores durante la comprobación de integridad.
                    """,
                    "Comprobación terminada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        catch (Exception ex)
        {
            await logger.WriteLineAsync($"{ex}");
        }

        gb_Options.Enabled = true;
    }

    private enum Result
    {
        Success,
        Failure,
    }

    private async Task<Result> DoChecksAsync(LogWritter logger)
    {
        Result result;

        if (chk_VerifyDb.Checked)
        {
            result = await PerformDatabaseIntegrityCheckAsync(logger, chk_VerifyFKs.Checked);
            if (result == Result.Failure)
            {
                return result;
            }
        }

        if (chk_VerifyFileExist.Checked)
        {
            result = await PerformFileSystemCheckAsync(logger, chk_VerifyFileIntegrity.Checked);
            if (result == Result.Failure)
            {
                return result;
            }
        }

        return Result.Success;
    }

    private async Task<Result> PerformDatabaseIntegrityCheckAsync(LogWritter logger, bool checkForeignKeys)
    {
        await logger.WriteLineAsync("Realizando comprobación de la base de datos.");
        await logger.WriteLineAsync($"Verificar integridad relacional: {(checkForeignKeys ? "Sí" : "No")}.");

        using var sqlite = App.Database.CreateConnection();
        using var command = sqlite.CreateCommand();
        command.CommandText = "PRAGMA integrity_check";
        using var reader = command.ExecuteReader();

        Debug.Assert(reader.HasRows, "PRAGMA integrity_check must return at least 1 row, but no rows were returned.");
        if (!reader.Read())
        {
            await logger.WriteLineAsync("Falló la comprobación de la base de datos.");
            return Result.Failure;
        }

        int errcount = 0;
        string output = reader.GetString(0);

        if (output.Equals("ok", StringComparison.OrdinalIgnoreCase))
        {
            await logger.WriteLineAsync("Finalizó la comprobación de la base de datos sin encontrar errores.");

            if (checkForeignKeys)
            {
                return await PerformDatabaseForeignKeysCheckAsync(logger, sqlite);
            }

            return Result.Success;
        }

        await logger.WriteLineAsync("Se encontraron errores en la base de datos.");

        do
        {
            output = reader.GetString(0);
            await logger.WriteLineAsync($"SQLite Error : {output}");
            errcount++;
        } while (reader.Read());

        await logger.WriteLineAsync($"Finalizó la comprobación de la base de datos encontrando {errcount} errore(s).");
        return Result.Failure;
    }

    private async Task<Result> PerformDatabaseForeignKeysCheckAsync(LogWritter logger, SqliteConnection sqlite)
    {
        await logger.WriteLineAsync("Realizando comprobación de integridad relacional.");

        using var command = sqlite.CreateCommand();
        command.CommandText = "PRAGMA foreign_key_check";
        using var reader = command.ExecuteReader();

        if (!reader.HasRows)
        {
            // No rows returned implies that no errors were found
            await logger.WriteLineAsync("Finalizó la comprobación de integridad relacional sin encontrar errores.");
            return Result.Success;
        }

        int errcount = 0;
        await logger.WriteLineAsync("Se encontraron errores de integridad relacional en la base de datos.");

        while (reader.Read())
        {
            string table = reader.GetString(0);
            long? rowid = reader.IsDBNull(1) ? null : reader.GetInt64(1);
            string parent = reader.GetString(2);
            object fkid = reader.GetValue(3);

            string srowid = rowid.HasValue ? rowid.ToString()! : "NULL";
            await logger.WriteLineAsync($"SQLite FK Error : table={table}; rowid={srowid}; parent={parent}; fkid={fkid}.");
            errcount++;
        }

        await logger.WriteLineAsync($"Finalizó la comprobación de integridad relacional encontrando {errcount} errore(s).");
        return Result.Failure;
    }

    private async Task<Result> PerformFileSystemCheckAsync(LogWritter logger, bool checkFileHashes)
    {
        Debug.Assert(cancellationToken is not null);
        await logger.WriteLineAsync("Realizando comprobación de archivos.");
        await logger.WriteLineAsync($"Verificar integridad de los archivos: {(checkFileHashes ? "Sí" : "No")}.");

        using var context = new AppDbContext();
        long count = context.Documents.Count();
        await logger.WriteLineAsync($"Se verificarán {count} archivos.");

        pb_Progress.Maximum = (int) count;
        pb_Progress.Value = 0;
        pb_Progress.Style = ProgressBarStyle.Blocks;

        int filesNotFound = 0;
        int filesDamaged = 0;
        int fileCount = 0;

        foreach (Document document in context.Documents.EnumerateAll())
        {
            fileCount++;
            pb_Progress.Value = fileCount;
            lbl_FileCount.Text = $"{fileCount} / {count} archivos";

            string path = StorageService.GetDocumentPath(document);
            string hash = document.Hash;

            if (!File.Exists(path))
            {
                await logger.WriteLineAsync($"No se encontró el archivo: {path}");
                filesNotFound++;
                continue;
            }

            if (checkFileHashes)
            {
                string actualHash = await ComputeFileHashAsync(path, cancellationToken.Token);
                if (!actualHash.Equals(hash, StringComparison.OrdinalIgnoreCase))
                {
                    await logger.WriteLineAsync($"""
                    El archivo está dañado: {path}
                        --> SHA256 Esperado : {hash}
                        --> SHA256 Actual   : {actualHash}
                    """);

                    filesDamaged++;
                }
            }
        }

        await logger.WriteLineAsync("Finalizó la comprobación de archivos.");
        if (filesNotFound > 0 || filesDamaged > 0)
        {
            await logger.WriteLineAsync($"""
            Se encontraron {filesNotFound + filesDamaged} errores en archivos.
                --> {filesNotFound} archivos no encontrados.
                --> {filesDamaged} archivos dañados.
            """);

            return Result.Failure;
        }

        await logger.WriteLineAsync("No se encontró ningún problema en los archivos.");
        return Result.Success;
    }

    private async Task<string> ComputeFileHashAsync(string filename, CancellationToken token)
    {
        await using var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var sha = SHA256.Create();

        byte[] digest = await sha.ComputeHashAsync(stream, token);
        var builder = new StringBuilder(digest.Length * 2);

        foreach (byte b in digest)
        {
            builder.AppendFormat("{0:X2}", b);
        }

        return builder.ToString();
    }

    private sealed class LogWritter : IAsyncDisposable
    {
        private readonly ListBox _listBox;
        private readonly EventLogger _logger;

        public LogWritter(ListBox listBox)
        {
            _listBox = listBox;
            _listBox.Items.Clear();
            _logger = new EventLogger("IntegrityCheck");
        }

        public async ValueTask DisposeAsync()
        {
            await _logger.DisposeAsync();
        }

        public async Task WriteLineAsync(string value)
        {
            ListBox listBox = _listBox;
            EventLogger logger = _logger;

            await logger.WriteLineAsync(value);

            listBox.Items.Add($"{DateTimeOffset.Now:yyyy\\-MM\\-dd HH\\:mm\\:ss} :: {value}");
            listBox.TopIndex = listBox.Items.Count - 1;
        }
    }
}
