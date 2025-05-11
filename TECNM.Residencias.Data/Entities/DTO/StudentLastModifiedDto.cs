namespace TECNM.Residencias.Data.Entities.DTO;

using System;

public sealed record StudentLastModifiedDto(
    long Id,
    string FirstName,
    string LastName,
    DateTimeOffset UpdatedOn
)
{
    /// <summary>
    /// Returns the first name and last name as string representation.
    /// </summary>
    /// <returns>The full name of the student.</returns>
    public override string ToString()
        => $"[{Id}] {FirstName} {LastName}";
}
