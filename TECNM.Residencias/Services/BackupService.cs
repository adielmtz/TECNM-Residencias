namespace TECNM.Residencias.Services;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TECNM.Residencias.Data;

internal sealed class BackupService
{
    private readonly int MaxDatabaseBackupsInFolder = 50;
    private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private readonly DateTime backupDateTime;
    private IList<FileInfo> fileInfos = [];

    public BackupService(DateTime datetime)
    {
        backupDateTime = datetime;

        // Default to Documents
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        Destination = new DirectoryInfo(documentsPath);
    }

    public BackupService() : this(DateTime.Now)
    {
    }

    public bool Compress { get; set; } = true;

    public int FileCount => fileInfos.Count;

    public DirectoryInfo Destination { get; set; }

    public string BackupFile => Path.Combine(Destination.FullName, $"rp_backup_{backupDateTime:yyyy-MM-dd_HH.mm}.tar.gz");

    public CompressionLevel CompressionLevel => Compress ? CompressionLevel.Optimal : CompressionLevel.NoCompression;

    public async Task CollectFiles()
    {
        var source = new DirectoryInfo(App.FileStorageDirectory);
        fileInfos = await Task.Run(() => source.EnumerateFiles("*.*", SearchOption.AllDirectories).ToList(), cancellationTokenSource.Token);
    }

    public void BackupDatabase()
    {
        string backupFileName = $"database.backup_{backupDateTime:yyyy-MM-dd_HH.mm.ss}.db";
        string backupDatabase = Path.Combine(App.DatabaseBackupDirectory, backupFileName);

        using var sqlite = App.Database.Open();
        using var backup = new DbFactory(backupDatabase).Open();
        sqlite.BackupDatabase(backup);
        SqliteConnection.ClearAllPools();
        RemoveOldDatabaseBackups();
    }

    public async Task BackupFilesAsync(IProgress<(string, int)> progress)
    {
        try
        {
            await using var writer = OpenBackupWriter();
            for (int i = 0; i < fileInfos.Count; i++)
            {
                FileInfo file = fileInfos[i];
                string entry = Path.GetRelativePath(App.FileStorageDirectory, file.FullName).Replace('\\', '/');

                progress.Report((file.Name, i + 1));
                await writer.WriteEntryAsync(file.FullName, entry, cancellationTokenSource.Token);
            }
        }
        catch (OperationCanceledException)
        {
            throw;
        }
    }

    public void Cancel()
    {
        cancellationTokenSource.Cancel();
    }

    private TarWriter OpenBackupWriter()
    {
        var fileStream = new FileStream(BackupFile, FileMode.Create, FileAccess.Write, FileShare.None);
        var gzipStream = new GZipStream(fileStream, CompressionLevel, leaveOpen: false);
        return new TarWriter(gzipStream, leaveOpen: false);
    }

    private void RemoveOldDatabaseBackups()
    {
        IList<FileInfo> fileList = new DirectoryInfo(App.DatabaseBackupDirectory)
            .EnumerateFiles()
            .Where(file => file.Extension == ".db") // Ensure we aren't grabbing ".db-shm" or ".db-wal" files
            .OrderBy(file => file.Name)
            .ToList();

        if (fileList.Count > MaxDatabaseBackupsInFolder)
        {
            fileList[0].Delete();
        }
    }
}
