namespace TECNM.Residencias.Data.Entities.DTO;

using System;
using System.Collections.Generic;

public sealed record class StudentFullDetailsDto
{
    public required long Id { get; init; }

    public required Specialty Specialty { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string Phone { get; init; }

    public required Gender Gender { get; init; }

    public required string Semester { get; init; }

    public required DateTime StartDate { get; init; }

    public required DateTime EndDate { get; init; }

    public required string Project { get; init; }

    public required Advisor? InternalAdvisor { get; init; }

    public required Advisor? ExternalAdvisor { get; init; }

    public required Advisor? ReviewerAdvisor { get; init; }

    public required Company Company { get; init; }

    public required string Department { get; init; }

    public required string Schedule { get; init; }

    public required string Notes { get; init; }

    public required bool IsClosed { get; init; }

    public required DateTime UpdatedOn { get; init; }

    public required DateTime CreatedOn { get; init; }

    public required IReadOnlyList<Extra> Extras { get; init; }
}
