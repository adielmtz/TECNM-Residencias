namespace TECNM.Residencias.Data.Entities.DTO;

public sealed record AdvisorSearchResultDto(
    long Id,
    long CompanyId,
    string FirstName,
    string LastName
)
{
    /// <summary>
    /// Returns the first name and last name as string representation.
    /// </summary>
    /// <returns>The full name of the advisor.</returns>
    public override string ToString() => $"{FirstName} {LastName}";
}
