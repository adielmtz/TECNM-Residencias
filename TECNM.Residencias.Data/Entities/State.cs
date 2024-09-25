namespace TECNM.Residencias.Data.Entities;

public sealed record State
{
    public required long Id { get; init; }

    public required long CountryId { get; init; }

    public required string Name { get; init; }

    public override string ToString()
    {
        return Name;
    }
}
