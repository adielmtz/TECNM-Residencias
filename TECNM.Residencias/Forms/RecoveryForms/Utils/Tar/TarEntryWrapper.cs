namespace TECNM.Residencias.Forms.RecoveryForms.Utils.Tar;
using System.Formats.Tar;
using System.IO;
using System.Threading.Tasks;

internal sealed class TarEntryWrapper : EntryWrapper
{
    private readonly TarEntry _entry;
    private readonly Stream _stream;

    public TarEntryWrapper(TarEntry entry, Stream stream) : base(entry.Name, entry.Length)
    {
        _entry = entry;
        _stream = stream;
    }

    public override Task ExtractAsync(string directory)
    {
        /* no-op */
        return Task.CompletedTask;
    }
}
