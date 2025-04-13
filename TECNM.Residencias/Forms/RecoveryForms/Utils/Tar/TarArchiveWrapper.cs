namespace TECNM.Residencias.Forms.RecoveryForms.Utils.Tar;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal sealed class TarArchiveWrapper : ArchiveWrapper
{
    private readonly List<EntryWrapper> _entries = [];
    private readonly List<EntryWrapper> _databases = [];
    private string? _filename;
    private Stream? _stream;

    public TarArchiveWrapper(string filename) : base(filename)
    {
    }

    public override IReadOnlyList<EntryWrapper> Entries => _entries;

    public override IReadOnlyList<EntryWrapper> Databases => _databases;

    public override void Dispose()
    {
        _stream?.Dispose();

        if (_filename is not null)
        {
            try
            {
                File.Delete(_filename);
            }
            catch
            {
            }
        }
    }

    public override async Task LoadEntriesAsync()
    {
        await ExtractToTempFile();
        Debug.Assert(_stream is not null);

        Stream stream = _stream;
        Regex regex = s_databaseBackupFileRegex;
        using var reader = new TarReader(stream, leaveOpen: true);

        List<EntryWrapper> entries = _entries;
        List<EntryWrapper> databases = _databases;

        while (true)
        {
            TarEntry? entry = await reader.GetNextEntryAsync(copyData: false);
            if (entry is null)
            {
                break;
            }

            var wrapped = new TarEntryWrapper(entry, stream);
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
    }

    public override async Task ExtractEntriesAsync(string directory, IProgress<(string, int)> progress)
    {
        Debug.Assert(_stream is not null);

        Stream stream = _stream;
        stream.Seek(0, SeekOrigin.Begin);

        await using var reader = new TarReader(stream, leaveOpen: true);
        List<EntryWrapper> entries = _entries;

        for (int i = 0; i < entries.Count; i++)
        {
            TarEntry? entry = await reader.GetNextEntryAsync(copyData: false);
            if (entry is null)
            {
                return;
            }

            progress.Report((entry.Name, i + 1));
            string filename = Path.Combine(directory, entry.Name);
            string parentDir = Path.GetDirectoryName(filename)!;
            Directory.CreateDirectory(parentDir);

            Stream? source = entry.DataStream;
            Debug.Assert(source is not null);

            await using var target = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            await source.CopyToAsync(target);
        }
    }

    private async Task ExtractToTempFile()
    {
        await using var gzStream = new GZipStream(
            new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read),
            CompressionMode.Decompress,
            leaveOpen: false
        );

        string tempfile = Path.Combine(App.TempStorageDirectory, Guid.NewGuid().ToString());
        var destination = new FileStream(tempfile, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
        await gzStream.CopyToAsync(destination);
        destination.Seek(0, SeekOrigin.Begin);

        _filename = tempfile;
        _stream = destination;
    }
}
