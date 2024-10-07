namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

public sealed class StudentDbSet : DbSet<Student>
{
    public StudentDbSet(IDbContext context) : base(context)
    {
    }

    public Student? GetStudentById(long id)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT Id, SpecialtyId, FirstName, LastName, Email, Phone, GenderId, Semester,
               StartDate, EndDate, Project, CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section, Schedule, Notes, Closed, UpdatedOn, CreatedOn
        FROM Student
        WHERE Id = $id
        """;

        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return HydrateObject(reader);
    }

    public IEnumerable<Student> Search(string query, int count, int page)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT rowid
        FROM StudentSearch
        WHERE StudentSearch MATCH $query OR rowid = $rid
        ORDER BY rank
        LIMIT $p0
        OFFSET $p1
        """;

        command.Parameters.Add("$query", SqliteType.Text).Value = query.ToFtsQuery();
        command.Parameters.Add("$rid", SqliteType.Integer).Value = TryConvertToId(query);
        command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = (page - 1) * count;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            long rowid = reader.GetInt64(0);
            Student student = GetStudentById(rowid)!;
            yield return student;
        }
    }

    public IEnumerable<Student> EnumerateStudents(int count, int page)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT Id, SpecialtyId, FirstName, LastName, Email, Phone, GenderId, Semester,
               StartDate, EndDate, Project, CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section, Schedule, Notes, Closed, UpdatedOn, CreatedOn
        FROM Student
        ORDER BY Id
        LIMIT $p0 OFFSET $p1
        """;

        command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = (page - 1) * count;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Student student = HydrateObject(reader);
            yield return student;
        }
    }

    public IEnumerable<Student> EnumerateStudents(int year, string? semester)
    {
        using var command = Context.Database.CreateCommand();
        string extraParam = "";
        if (semester != null)
        {
            extraParam = "AND Semester = $p1";
            command.Parameters.Add("$p1", SqliteType.Text).Value = semester;
        }

        command.CommandText = $"""
        SELECT Id, SpecialtyId, FirstName, LastName, Email, Phone, GenderId, Semester,
               StartDate, EndDate, Project, CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section, Schedule, Notes, Closed, UpdatedOn, CreatedOn
        FROM Student
        WHERE strftime('%Y', StartDate) = $p0 {extraParam}
        """;

        command.Parameters.Add("$p0", SqliteType.Text).Value = year.ToString();
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Student student = HydrateObject(reader);
            yield return student;
        }
    }

    public IEnumerable<Student> EnumerateStudents(int count = 10)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT Id, SpecialtyId, FirstName, LastName, Email, Phone, GenderId, Semester,
               StartDate, EndDate, Project, CompanyId, InternalAdvisorId, ExternalAdvisorId,
               ReviewerAdvisorId, Section, Schedule, Notes, Closed, UpdatedOn, CreatedOn
        FROM Student
        ORDER BY UpdatedOn DESC
        LIMIT $p0
        """;
        command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Student student = HydrateObject(reader);
            yield return student;
        }
    }

    public override bool Insert(Student entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        INSERT INTO Student (
            Id, SpecialtyId, FirstName, LastName, Email, Phone, GenderId, Semester,
            StartDate, EndDate, Project, CompanyId, InternalAdvisorId, ExternalAdvisorId,
            ReviewerAdvisorId, Section, Schedule, Notes, Closed, UpdatedOn
        )
        VALUES (
            $pid, $p00, $p01, $p02, $p03, $p04, $p05, $p06,
            $p07, $p08, $p09, $p10, $p11, $p12,
            $p13, $p14, $p15, $p16, $p17, CURRENT_TIMESTAMP
        )
        """;

        command.Parameters.Add("$pid", SqliteType.Integer).Value = entity.Id;
        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.SpecialtyId;
        command.Parameters.Add("$p01", SqliteType.Text).Value = entity.FirstName;
        command.Parameters.Add("$p02", SqliteType.Text).Value = entity.LastName;
        command.Parameters.Add("$p03", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p05", SqliteType.Integer).Value = entity.GenderId;
        command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Semester;
        command.Parameters.Add("$p07", SqliteType.Text).Value = entity.StartDate.ToShortIsoString();
        command.Parameters.Add("$p08", SqliteType.Text).Value = entity.EndDate.ToShortIsoString();
        command.Parameters.Add("$p09", SqliteType.Text).Value = entity.Project;
        command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p11", SqliteType.Integer).SetNullableValue(entity.InternalAdvisorId);
        command.Parameters.Add("$p12", SqliteType.Integer).SetNullableValue(entity.ExternalAdvisorId);
        command.Parameters.Add("$p13", SqliteType.Integer).SetNullableValue(entity.ReviewerAdvisorId);
        command.Parameters.Add("$p14", SqliteType.Text).Value = entity.Section;
        command.Parameters.Add("$p15", SqliteType.Text).Value = entity.Schedule;
        command.Parameters.Add("$p16", SqliteType.Text).Value = entity.Notes;
        command.Parameters.Add("$p17", SqliteType.Integer).Value = entity.Closed;
        return command.ExecuteNonQuery() > 0;
    }

    public override int Update(Student entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        UPDATE Student
        SET SpecialtyId       = $p00,
            FirstName         = $p01,
            LastName          = $p02,
            Email             = $p03,
            Phone             = $p04,
            GenderId          = $p05,
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
            UpdatedOn         = CURRENT_TIMESTAMP
        WHERE Id = $id
        """;

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.SpecialtyId;
        command.Parameters.Add("$p01", SqliteType.Text).Value = entity.FirstName;
        command.Parameters.Add("$p02", SqliteType.Text).Value = entity.LastName;
        command.Parameters.Add("$p03", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p05", SqliteType.Integer).Value = entity.GenderId;
        command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Semester;
        command.Parameters.Add("$p07", SqliteType.Text).Value = entity.StartDate.ToShortIsoString();
        command.Parameters.Add("$p08", SqliteType.Text).Value = entity.EndDate.ToShortIsoString();
        command.Parameters.Add("$p09", SqliteType.Text).Value = entity.Project;
        command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p11", SqliteType.Integer).SetNullableValue(entity.InternalAdvisorId);
        command.Parameters.Add("$p12", SqliteType.Integer).SetNullableValue(entity.ExternalAdvisorId);
        command.Parameters.Add("$p13", SqliteType.Integer).SetNullableValue(entity.ReviewerAdvisorId);
        command.Parameters.Add("$p14", SqliteType.Text).Value = entity.Section;
        command.Parameters.Add("$p15", SqliteType.Text).Value = entity.Schedule;
        command.Parameters.Add("$p16", SqliteType.Text).Value = entity.Notes;
        command.Parameters.Add("$p17", SqliteType.Integer).Value = entity.Closed;
        command.Parameters.Add("$pid", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override int Delete(Student entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "DELETE FROM Student WHERE Id = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool InsertOrUpdate(Student entity)
    {
        if (entity.Id > 0)
        {
            return Update(entity) != 0;
        }
        else
        {
            return Insert(entity);
        }
    }

    protected override Student HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 21);
        return new Student
        {
            Id                = reader.GetInt64(0),
            SpecialtyId       = reader.GetInt64(1),
            FirstName         = reader.GetString(2),
            LastName          = reader.GetString(3),
            Email             = reader.GetString(4),
            Phone             = reader.GetString(5),
            GenderId          = reader.GetInt64(6),
            Semester          = reader.GetString(7),
            StartDate         = reader.GetDateTime(8),
            EndDate           = reader.GetDateTime(9),
            Project           = reader.GetString(10),
            CompanyId         = reader.GetInt64(11),
            InternalAdvisorId = reader.GetNullableInt64(12),
            ExternalAdvisorId = reader.GetNullableInt64(13),
            ReviewerAdvisorId = reader.GetNullableInt64(14),
            Section           = reader.GetString(15),
            Schedule          = reader.GetString(16),
            Notes             = reader.GetString(17),
            Closed            = reader.GetBoolean(18),
            UpdatedOn         = reader.GetLocalDateTime(19),
            CreatedOn         = reader.GetLocalDateTime(20),
        };
    }

    private long TryConvertToId(string text)
    {
        if (long.TryParse(text, out long result))
        {
            return result;
        }

        return 0;
    }
}
