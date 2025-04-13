namespace TECNM.Residencias.Forms.RecoveryForms.Utils;

using System;
using System.Threading.Tasks;

internal abstract class EntryWrapper
{
    private readonly string _name;
    private readonly long _size;

    protected EntryWrapper(string name, long size)
    {
        _name = name;
        _size = size;
    }

    public string Name => _name;

    public long Size => _size;

    public DateTimeOffset Timestamp { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public abstract Task ExtractAsync(string directory);
}
