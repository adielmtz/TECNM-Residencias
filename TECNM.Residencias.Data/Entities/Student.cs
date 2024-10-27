namespace TECNM.Residencias.Data.Entities;

using System;

/// <summary>
/// Represents a student entity in the database.
/// </summary>
public sealed class Student
{
    /// <summary>
    /// Gets or sets the unique rowid of the entity.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid for the specialty to which the student belongs.
    /// </summary>
    public long SpecialtyId { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; } = "";

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; } = "";

    /// <summary>
    /// Gets or sets the contact email address.
    /// </summary>
    public string Email { get; set; } = "";

    /// <summary>
    /// Gets or sets the contact phone number.
    /// </summary>
    public string Phone { get; set; } = "";

    /// <summary>
    /// Gets or sets the unique rowid of the gender.
    /// </summary>
    public long GenderId { get; set; }

    /// <summary>
    /// Gets or sets the semester. Should be "ENE-JUN" or "AGO-DIC".
    /// </summary>
    public string Semester { get; set; } = "";

    /// <summary>
    /// Gets or sets the start date of the internship.
    /// </summary>
    public DateOnly StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the internship.
    /// </summary>
    public DateOnly EndDate { get; set; }

    /// <summary>
    /// Gets or sets the name of the internship project.
    /// </summary>
    public string Project { get; set; } = "";

    /// <summary>
    /// Gets or sets the unique rowid of the company to which the project belongs.
    /// </summary>
    public long CompanyId { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid of the internal advisor.
    /// </summary>
    public long? InternalAdvisorId { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid of the external advisor.
    /// </summary>
    public long? ExternalAdvisorId { get; set; }

    /// <summary>
    /// Gets or sets the unique rowid of the reviewer advisor.
    /// </summary>
    public long? ReviewerAdvisorId { get; set; }

    /// <summary>
    /// Gets or sets the section or department within the company.
    /// </summary>
    public string Section { get; set; } = "";

    /// <summary>
    /// Gets or sets the internship schedule.
    /// </summary>
    public string Schedule { get; set; } = "";

    /// <summary>
    /// Gets or sets arbitrary notes.
    /// </summary>
    public string Notes { get; set; } = "";

    /// <summary>
    /// Gets or sets a value indicating whether the internship is concluded.
    /// </summary>
    public bool Closed { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTimeOffset UpdatedOn { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Returns the first name and last name as string representation.
    /// </summary>
    /// <returns>The full name of the student.</returns>
    public override string ToString() => $"[{Id}] {FirstName} {LastName}";
}
