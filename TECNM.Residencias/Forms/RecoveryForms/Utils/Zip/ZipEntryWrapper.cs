namespace TECNM.Residencias.Forms.RecoveryForms.Utils.Zip;

using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

internal sealed class ZipEntryWrapper : EntryWrapper
{
    private readonly ZipArchiveEntry _entry;

    public ZipEntryWrapper(ZipArchiveEntry entry) : base(entry.FullName, entry.Length)
    {
        _entry = entry;
    }

    public override async Task ExtractAsync(string directory)
    {
        ZipArchiveEntry entry = _entry;
        string filename = Path.Combine(directory, Name);

        string parentDir = Path.GetDirectoryName(filename)!;
        Directory.CreateDirectory(parentDir);

        await using var source = entry.Open();
        await using var target = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        await source.CopyToAsync(target);
    }
}
