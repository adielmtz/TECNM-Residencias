namespace TECNM.Residencias.Forms.RecoveryForms.Utils;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TECNM.Residencias.Forms.RecoveryForms.Utils.Tar;
using TECNM.Residencias.Forms.RecoveryForms.Utils.Zip;

internal abstract class ArchiveWrapper : IDisposable
{
    protected static readonly Regex s_databaseBackupFileRegex = new Regex(@"database\.db\.(\d{14})\.bak$");

    private readonly string _filename;

    public static ArchiveWrapper OpenArchive(string filename)
    {
        if (filename.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
        {
            return new ZipArchiveWrapper(filename);
        }

        if (filename.EndsWith(".tar.gz", StringComparison.OrdinalIgnoreCase))
        {
            return new TarArchiveWrapper(filename);
        }

        throw new UnreachableException();
    }

    protected ArchiveWrapper(string filename)
    {
        _filename = filename;
    }

    public string FileName => _filename;

    public abstract IReadOnlyList<EntryWrapper> Entries { get; }

    public abstract IReadOnlyList<EntryWrapper> Databases { get; }

    public abstract void Dispose();

    public abstract Task LoadEntriesAsync();

    public abstract Task ExtractEntriesAsync(string directory, IProgress<(string, int)> progress);
}
