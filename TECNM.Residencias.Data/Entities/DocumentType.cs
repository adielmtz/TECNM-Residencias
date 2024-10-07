namespace TECNM.Residencias.Data.Entities;

public sealed class DocumentType
{
    public long Id { get; set; }

    public string Label { get; set; } = "";

    public string Tag { get; set; } = "";

    public string Keywords { get; set; } = "";

    public override string ToString()
    {
        return Label;
    }
}
