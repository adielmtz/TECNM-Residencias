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

namespace TECNM.Residencias.Services
{
    internal sealed class BackupService
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly DirectoryInfo destination;
        private readonly DateTime backupDateTime;
        private IList<FileInfo> fileInfos = [];
        private Stream? stream;

        public BackupService(DirectoryInfo destination, DateTime datetime)
        {
            this.destination = destination;
            backupDateTime = datetime;
        }

        public BackupService(DirectoryInfo destination) : this(destination, DateTime.Now)
        {
        }

        public bool Compress { get; set; } = true;

        public int FileCount => fileInfos.Count;

        public string BackupFile => Path.Combine(destination.FullName, $"rp_backup_{backupDateTime:yyyy-MM-dd_HH.mm}.tar.gz");

        public CompressionLevel CompressionLevel => Compress ? CompressionLevel.Optimal : CompressionLevel.NoCompression;

        public async Task CollectFiles()
        {
            var source = new DirectoryInfo(App.FileStorageDirectory);
            fileInfos = await Task.Run(() => source.EnumerateFiles("*.*", SearchOption.AllDirectories).ToList(), cancellationTokenSource.Token);
        }

        public async Task BackupAsync(IProgress<(string, int)> progress)
        {
            BackupDatabase();

            if (fileInfos.Count == 0)
            {
                return;
            }

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

        private void BackupDatabase()
        {
            using var sqlite = App.Database.Open();
            using var backup = new DbFactory(Path.Combine(App.FileStorageDirectory, App.DatabaseName)).Open();
            sqlite.BackupDatabase(backup);
            SqliteConnection.ClearAllPools();
        }

        private TarWriter OpenBackupWriter()
        {
            var fileStream = new FileStream(BackupFile, FileMode.Create, FileAccess.Write, FileShare.None);
            var gzipStream = new GZipStream(fileStream, CompressionLevel, leaveOpen: false);
            return new TarWriter(gzipStream, leaveOpen: false);
        }
    }
}
