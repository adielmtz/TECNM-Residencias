namespace TECNM.Residencias.Data.Entities.DTO;

public sealed record CompanySearchResultDto(
    long Id,
    string? Rfc,
    string Name
)
{
    /// <summary>
    /// Returns the company name as string representation.
    /// </summary>
    /// <returns>The name of the company.</returns>
    public override string ToString()
        => Name;
}
