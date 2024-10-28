namespace TECNM.Residencias.Data.Entities.DTO;

public sealed record StudentSearchResultDto(
    long Id,
    string FirstName,
    string LastName
)
{
    /// <summary>
    /// Returns the first name and last name as string representation.
    /// </summary>
    /// <returns>The full name of the student.</returns>
    public override string ToString() => $"[{Id}] {FirstName} {LastName}";
}
