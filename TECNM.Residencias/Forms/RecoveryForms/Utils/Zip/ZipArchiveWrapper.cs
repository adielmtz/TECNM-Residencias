namespace TECNM.Residencias.Forms.RecoveryForms.Utils.Zip;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal sealed class ZipArchiveWrapper : ArchiveWrapper
{
    private readonly ZipArchive _archive;
    private readonly List<EntryWrapper> _entries = [];
    private readonly List<EntryWrapper> _databases = [];

    public ZipArchiveWrapper(string filename) : base(filename)
    {
        var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        _archive = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen: false);
    }

    public override IReadOnlyList<EntryWrapper> Entries => _entries;

    public override IReadOnlyList<EntryWrapper> Databases => _databases;

    public override void Dispose()
    {
        _archive.Dispose();
    }

    public override Task LoadEntriesAsync()
    {
        ZipArchive archive = _archive;
        Regex regex = s_databaseBackupFileRegex;

        List<EntryWrapper> entries = _entries;
        List<EntryWrapper> databases = _databases;

        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            if (Path.EndsInDirectorySeparator(entry.FullName))
            {
                // Ignore directory entries
                continue;
            }

            var wrapped = new ZipEntryWrapper(entry);
            Match match = regex.Match(wrapped.Name);
            entries.Add(wrapped);

            if (match.Success)
            {
                string capture = match.Groups[1].Value;
                wrapped.Timestamp = DateTimeOffset.ParseExact(capture, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                databases.Add(wrapped);
            }
        }

        databases.Sort((a, b) => b.Timestamp.CompareTo(a.Timestamp));
        return Task.CompletedTask;
    }

    public override async Task ExtractEntriesAsync(string directory, IProgress<(string, int)> progress)
    {
        List<EntryWrapper> entries = _entries;
        for (int i = 0; i < entries.Count; i++)
        {
            EntryWrapper entry = entries[i];
            progress.Report((entry.Name, i + 1));
            await entry.ExtractAsync(directory);
        }
    }
}
