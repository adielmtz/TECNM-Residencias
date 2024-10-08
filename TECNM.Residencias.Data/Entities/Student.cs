namespace TECNM.Residencias.Data.Entities;

using System;

public sealed class Student
{
    public long Id { get; set; }

    public long SpecialtyId { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Email { get; set; } = "";

    public string Phone { get; set; } = "";

    public long GenderId { get; set; }

    public string Semester { get; set; } = "";

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Project { get; set; } = "";

    public long CompanyId { get; set; }

    public long? InternalAdvisorId { get; set; }

    public long? ExternalAdvisorId { get; set; }

    public long? ReviewerAdvisorId { get; set; }

    public string Section { get; set; } = "";

    public string Schedule { get; set; } = "";

    public string Notes { get; set; } = "";

    public bool Closed { get; set; }

    public DateTime UpdatedOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public override string ToString()
    {
        return $"[{Id}] {FirstName} {LastName}";
    }
}
