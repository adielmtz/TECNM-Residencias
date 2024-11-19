namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DTO;
using TECNM.Residencias.Data.Extensions;

public sealed class StudentDbSet : DbSet<Student>
{
    public StudentDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a student entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the student entity.</param>
    /// <returns>A <see cref="Student"/> instance if a student with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public Student? GetStudent(long id)
    {
        using var command = CreateCommand("""
        SELECT Id,                SpecialtyId, FirstName, LastName, Email,     Phone,             Gender,
               Semester,          StartDate,   EndDate,   Project,  CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section,     Schedule,  Notes,    Closed,    UpdatedOn,         CreatedOn
        FROM Student
        WHERE Id = $id
        """);

        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    /// <summary>
    /// Searches for student records based on the provided query.
    /// </summary>
    /// <param name="query">The search term used to find students.</param>
    /// <param name="count">The number of results to return per page.</param>
    /// <param name="page">The page number to retrieve, starting from 1.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the search results.
    /// </returns>
    public IEnumerable<StudentSearchResultDto> Search(string query, int count, int page)
    {
        using var command = CreateCommand("""
        SELECT rowid, FirstName, LastName
        FROM StudentSearch
        WHERE StudentSearch MATCH $query OR rowid = $rowid
        ORDER BY rank
        LIMIT $page, $count
        """);

        command.Parameters.Add("$query", SqliteType.Text).Value = query.ToFtsQuery();
        command.Parameters.Add("$rowid", SqliteType.Integer).Value = TryConvertToRowid(query);
        command.Parameters.Add("$page", SqliteType.Integer).Value = (page - 1) * count;
        command.Parameters.Add("$count", SqliteType.Integer).Value = count;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new StudentSearchResultDto(
                Id:        reader.GetInt64(0),
                FirstName: reader.GetString(1),
                LastName:  reader.GetString(2)
            );
        }
    }

    public override IEnumerable<Student> EnumerateAll()
    {
        using var command = CreateCommand("""
        SELECT Id,                SpecialtyId, FirstName, LastName, Email,     Phone,             Gender,
               Semester,          StartDate,   EndDate,   Project,  CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section,     Schedule,  Notes,    Closed,    UpdatedOn,         CreatedOn
        FROM Student
        ORDER BY Id
        """);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates a paginated collection of student entities.
    /// </summary>
    /// <param name="count">The number of results to return per page.</param>
    /// <param name="page">The page number to retrieve, starting from 1.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the companies for the specified page.
    /// </returns>
    public IEnumerable<Student> EnumerateAll(int count, int page)
    {
        using var command = CreateCommand("""
        SELECT Id,                SpecialtyId, FirstName, LastName, Email,     Phone,             Gender,
               Semester,          StartDate,   EndDate,   Project,  CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section,     Schedule,  Notes,    Closed,    UpdatedOn,         CreatedOn
        FROM Student
        ORDER BY Id
        LIMIT $page, $count
        """);

        command.Parameters.Add("$page", SqliteType.Integer).Value = (page - 1) * count;
        command.Parameters.Add("$count", SqliteType.Integer).Value = count;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all recently modified student records.
    /// </summary>
    /// <param name="count">The maximum number of recently modified students to retrieve.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the basic information of the recently
    /// modified students, sorted by their last update time in descending order.
    /// </returns>
    public IEnumerable<StudentLastModifiedDto> EnumerateRecentlyModified(int count)
    {
        using var command = CreateCommand("SELECT Id, FirstName, LastName, UpdatedOn FROM Student ORDER BY UpdatedOn DESC LIMIT $p0");
        command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new StudentLastModifiedDto(
                Id:        reader.GetInt64(0),
                FirstName: reader.GetString(1),
                LastName:  reader.GetString(2),
                UpdatedOn: reader.GetDateTimeOffset(3)
            );
        }
    }

    /// <summary>
    /// Retrieves and enumerates a collection of students enrolled in a specified academic year and semester.
    /// </summary>
    /// <param name="year">The academic year for which to retrieve students. Must be a valid year (e.g., 2023).</param>
    /// <param name="semester">An optional string representing the semester (e.g., "ENE-JUN", "AGO-DIC"). If null, students from all semesters will be included.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the students that match the specified year and semester.</returns>
    public IEnumerable<Student> EnumerateAll(int year, string? semester)
    {
        using var command = CreateCommand();
        string extraParam = "";

        if (semester is not null)
        {
            extraParam = "AND Semester = $p1";
            command.Parameters.Add("$p1", SqliteType.Text).Value = semester!;
        }

        command.CommandText = $"""
        SELECT Id,                SpecialtyId, FirstName, LastName, Email,     Phone,             Gender,
               Semester,          StartDate,   EndDate,   Project,  CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section,     Schedule,  Notes,    Closed,    UpdatedOn,         CreatedOn
        FROM Student
        WHERE strftime('%Y', StartDate) = $p0 {extraParam}
        """;

        command.Parameters.Add("$p0", SqliteType.Text).Value = year.ToString();
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Student entity) => throw new NotImplementedException();

    public override bool Add(Student entity)
    {
        using var command = CreateCommand("""
        INSERT INTO Student (Id,                SpecialtyId, FirstName, LastName, Email,     Phone,             Gender,
                             Semester,          StartDate,   EndDate,   Project,  CompanyId, InternalAdvisorId, ExternalAdvisorId,
                             ReviewerAdvisorId, Section,     Schedule,  Notes,    Closed,    UpdatedOn,         CreatedOn)
        VALUES ($p00, $p01, $p02, $p03, $p04, $p05, $p06, $p07, $p08, $p09, $p10, $p11, $p12, $p13, $p14, $p15, $p16, $p17, $p18, $p19, $p20)
        """);

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.Id;
        command.Parameters.Add("$p01", SqliteType.Integer).Value = entity.SpecialtyId;
        command.Parameters.Add("$p02", SqliteType.Text).Value    = entity.FirstName;
        command.Parameters.Add("$p03", SqliteType.Text).Value    = entity.LastName;
        command.Parameters.Add("$p04", SqliteType.Text).Value    = entity.Email;
        command.Parameters.Add("$p05", SqliteType.Text).Value    = entity.Phone;
        command.Parameters.Add("$p06", SqliteType.Text).Value    = entity.Gender.ToString();
        command.Parameters.Add("$p07", SqliteType.Text).Value    = entity.Semester;
        command.Parameters.Add("$p08", SqliteType.Text).Value    = entity.StartDate;
        command.Parameters.Add("$p09", SqliteType.Text).Value    = entity.EndDate;
        command.Parameters.Add("$p10", SqliteType.Text).Value    = entity.Project;
        command.Parameters.Add("$p11", SqliteType.Integer).SetValue(entity.CompanyId);
        command.Parameters.Add("$p12", SqliteType.Integer).SetValue(entity.InternalAdvisorId);
        command.Parameters.Add("$p13", SqliteType.Integer).SetValue(entity.ExternalAdvisorId);
        command.Parameters.Add("$p14", SqliteType.Integer).SetValue(entity.ReviewerAdvisorId);
        command.Parameters.Add("$p15", SqliteType.Text).Value    = entity.Section;
        command.Parameters.Add("$p16", SqliteType.Text).Value    = entity.Schedule;
        command.Parameters.Add("$p17", SqliteType.Text).Value    = entity.Notes;
        command.Parameters.Add("$p18", SqliteType.Integer).Value = entity.Closed;
        command.Parameters.Add("$p19", SqliteType.Text).Value    = DateTimeOffset.Now.ToRfc3339();
        command.Parameters.Add("$p20", SqliteType.Text).Value    = DateTimeOffset.Now.ToRfc3339();
        return command.ExecuteNonQuery() == 1;
    }

    public override int Update(Student entity)
    {
        using var command = CreateCommand("""
        UPDATE Student
        SET SpecialtyId       = $p00,
            FirstName         = $p01,
            LastName          = $p02,
            Email             = $p03,
            Phone             = $p04,
            Gender            = $p05,
            Semester          = $p06,
            StartDate         = $p07,
            EndDate           = $p08,
            Project           = $p09,
            CompanyId         = $p10,
            InternalAdvisorId = $p11,
            ExternalAdvisorId = $p12,
            ReviewerAdvisorId = $p13,
            Section           = $p14,
            Schedule          = $p15,
            Notes             = $p16,
            Closed            = $p17,
            UpdatedOn         = $p18
        WHERE Id = $pid
        """);

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.SpecialtyId;
        command.Parameters.Add("$p01", SqliteType.Text).Value    = entity.FirstName;
        command.Parameters.Add("$p02", SqliteType.Text).Value    = entity.LastName;
        command.Parameters.Add("$p03", SqliteType.Text).Value    = entity.Email;
        command.Parameters.Add("$p04", SqliteType.Text).Value    = entity.Phone;
        command.Parameters.Add("$p05", SqliteType.Text).Value    = entity.Gender.ToString();
        command.Parameters.Add("$p06", SqliteType.Text).Value    = entity.Semester;
        command.Parameters.Add("$p07", SqliteType.Text).Value    = entity.StartDate;
        command.Parameters.Add("$p08", SqliteType.Text).Value    = entity.EndDate;
        command.Parameters.Add("$p09", SqliteType.Text).Value    = entity.Project;
        command.Parameters.Add("$p10", SqliteType.Integer).SetValue(entity.CompanyId);
        command.Parameters.Add("$p11", SqliteType.Integer).SetValue(entity.InternalAdvisorId);
        command.Parameters.Add("$p12", SqliteType.Integer).SetValue(entity.ExternalAdvisorId);
        command.Parameters.Add("$p13", SqliteType.Integer).SetValue(entity.ReviewerAdvisorId);
        command.Parameters.Add("$p14", SqliteType.Text).Value    = entity.Section;
        command.Parameters.Add("$p15", SqliteType.Text).Value    = entity.Schedule;
        command.Parameters.Add("$p16", SqliteType.Text).Value    = entity.Notes;
        command.Parameters.Add("$p17", SqliteType.Integer).Value = entity.Closed;
        command.Parameters.Add("$p18", SqliteType.Text).Value    = DateTimeOffset.Now.ToRfc3339();
        command.Parameters.Add("$pid", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool AddOrUpdate(Student entity)
    {
        return entity.Id > 0 ? Update(entity) > 0 : Add(entity);
    }

    public override int Remove(Student entity)
    {
        using var command = CreateCommand("DELETE FROM Student WHERE Id = $id");
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    protected override Student HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 21);
        int index = 0;
        return new Student
        {
            Id                = reader.GetInt64(index++),
            SpecialtyId       = reader.GetInt64(index++),
            FirstName         = reader.GetString(index++),
            LastName          = reader.GetString(index++),
            Email             = reader.GetString(index++),
            Phone             = reader.GetString(index++),
            Gender            = reader.GetEnum<Gender>(index++),
            Semester          = reader.GetString(index++),
            StartDate         = reader.GetDateOnly(index++),
            EndDate           = reader.GetDateOnly(index++),
            Project           = reader.GetString(index++),
            CompanyId         = reader.GetInt64(index++),
            InternalAdvisorId = reader.GetOptionalInt64(index++),
            ExternalAdvisorId = reader.GetOptionalInt64(index++),
            ReviewerAdvisorId = reader.GetOptionalInt64(index++),
            Section           = reader.GetString(index++),
            Schedule          = reader.GetString(index++),
            Notes             = reader.GetString(index++),
            Closed            = reader.GetBoolean(index++),
            UpdatedOn         = reader.GetDateTimeOffset(index++),
            CreatedOn         = reader.GetDateTimeOffset(index++),
        };
    }

    private long TryConvertToRowid(string text)
    {
        if (long.TryParse(text, out long result))
        {
            return result;
        }

        return 0L;
    }
}
