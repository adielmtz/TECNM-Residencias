using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

namespace TECNM.Residencias.Data.Sets
{
    public sealed class StudentDbSet : DbSet<Student>
    {
        public const int DEFAULT_ROWS_PER_PAGE = 100;
        public const int DEFAULT_INITIAL_PAGE = 1;

        public StudentDbSet(IDbContext context) : base(context)
        {
        }

        public Student? GetStudentById(long id)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            SELECT Id, SpecialtyId, FirstName, LastName, Email, Phone, Gender, Semester,
                   StartDate, EndDate, InternalAdvisorId, ExternalAdvisorId, ReviewerAdvisorId,
                   CompanyId, Department, Schedule, Notes, HasSocialServiceCertificate,
                   HasInternshipApplication, HasPresentationLetter, HasAcceptanceLetter,
                   HasProjectDocument, Enabled, UpdatedOn, CreatedOn
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

        public IEnumerable<Student> Search(string query, int count = DEFAULT_ROWS_PER_PAGE, int page = DEFAULT_INITIAL_PAGE)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT rowid FROM StudentSearch WHERE StudentSearch MATCH $query OR rowid = $rid ORDER BY rank LIMIT $p0 OFFSET $p1";
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

        public IEnumerable<Student> EnumerateStudents(int count = DEFAULT_ROWS_PER_PAGE, int page = DEFAULT_INITIAL_PAGE)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            SELECT Id, SpecialtyId, FirstName, LastName, Email, Phone, Gender, Semester,
                   StartDate, EndDate, InternalAdvisorId, ExternalAdvisorId, ReviewerAdvisorId,
                   CompanyId, Department, Schedule, Notes, HasSocialServiceCertificate,
                   HasInternshipApplication, HasPresentationLetter, HasAcceptanceLetter,
                   HasProjectDocument, Enabled, UpdatedOn, CreatedOn
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

        public override bool Insert(Student entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO Student
                (Id, SpecialtyId, FirstName, LastName, Email, Phone, Gender, Semester,
                StartDate, EndDate, InternalAdvisorId, ExternalAdvisorId, ReviewerAdvisorId,
                CompanyId, Department, Schedule, Notes, HasSocialServiceCertificate,
                HasInternshipApplication, HasPresentationLetter, HasAcceptanceLetter,
                HasProjectDocument, Enabled, UpdatedOn)
            VALUES ($p00, $p01, $p02, $p03, $p04, $p05, $p06, $p07, $p08, $p09, $p10, $p11,
                    $p12, $p13, $p14, $p15, $p16, $p17, $p18, $p19, $p20, $p21, $p22 CURRENT_TIMESTAMP)
            """;

            // TODO: Use reflection for this?

            command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.Id;
            command.Parameters.Add("$p01", SqliteType.Integer).Value = entity.SpecialtyId;
            command.Parameters.Add("$p02", SqliteType.Text).Value = entity.FirstName;
            command.Parameters.Add("$p03", SqliteType.Text).Value = entity.LastName;
            command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p05", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Gender;
            command.Parameters.Add("$p07", SqliteType.Text).Value = entity.Semester;
            command.Parameters.Add("$p08", SqliteType.Text).Value = entity.StartDate.TOISOStringUTC();
            command.Parameters.Add("$p09", SqliteType.Text).Value = entity.EndDate.TOISOStringUTC();
            command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.InternalAdvisorId;
            command.Parameters.Add("$p11", SqliteType.Integer).Value = entity.ExternalAdvisorId;
            command.Parameters.Add("$p12", SqliteType.Integer).Value = entity.ReviewerAdvisorId;
            command.Parameters.Add("$p13", SqliteType.Integer).Value = entity.CompanyId;
            command.Parameters.Add("$p14", SqliteType.Text).Value = entity.Department;
            command.Parameters.Add("$p15", SqliteType.Text).Value = entity.Schedule;
            command.Parameters.Add("$p16", SqliteType.Text).Value = entity.Notes;
            command.Parameters.Add("$p17", SqliteType.Integer).Value = entity.HasSocialServiceCertificate;
            command.Parameters.Add("$p18", SqliteType.Integer).Value = entity.HasInternshipApplication;
            command.Parameters.Add("$p19", SqliteType.Integer).Value = entity.HasPresentationLetter;
            command.Parameters.Add("$p20", SqliteType.Integer).Value = entity.HasAcceptanceLetter;
            command.Parameters.Add("$p21", SqliteType.Integer).Value = entity.HasProjectDocument;
            command.Parameters.Add("$p22", SqliteType.Integer).Value = entity.Enabled;
            return command.ExecuteNonQuery() > 0;
        }

        public override int Update(Student entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            UPDATE Student
            SET SpecialtyId                 = $p00,
                FirstName                   = $p01,
                LastName                    = $p02,
                Email                       = $p03,
                Phone                       = $p04,
                Gender                      = $p05,
                Semester                    = $p06,
                StartDate                   = $p07,
                EndDate                     = $p08,
                InternalAdvisorId           = $p09,
                ExternalAdvisorId           = $p10,
                ReviewerAdvisorId           = $p11,
                CompanyId                   = $p12,
                Department                  = $p13,
                Schedule                    = $p14,
                Notes                       = $p15,
                HasSocialServiceCertificate = $p16,
                HasInternshipApplication    = $p17,
                HasPresentationLetter       = $p18,
                HasAcceptanceLetter         = $p19,
                HasProjectDocument          = $p20,
                Enabled                     = $p21,
                UpdatedOn                   = CURRENT_TIMESTAMP
            WHERE Id = $id
            """;

            command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.SpecialtyId;
            command.Parameters.Add("$p01", SqliteType.Text).Value = entity.FirstName;
            command.Parameters.Add("$p02", SqliteType.Text).Value = entity.LastName;
            command.Parameters.Add("$p03", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p05", SqliteType.Text).Value = entity.Gender;
            command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Semester;
            command.Parameters.Add("$p07", SqliteType.Text).Value = entity.StartDate.TOISOStringUTC();
            command.Parameters.Add("$p08", SqliteType.Text).Value = entity.EndDate.TOISOStringUTC();
            command.Parameters.Add("$p09", SqliteType.Integer).Value = entity.InternalAdvisorId;
            command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.ExternalAdvisorId;
            command.Parameters.Add("$p11", SqliteType.Integer).Value = entity.ReviewerAdvisorId;
            command.Parameters.Add("$p12", SqliteType.Integer).Value = entity.CompanyId;
            command.Parameters.Add("$p13", SqliteType.Text).Value = entity.Department;
            command.Parameters.Add("$p14", SqliteType.Text).Value = entity.Schedule;
            command.Parameters.Add("$p15", SqliteType.Text).Value = entity.Notes;
            command.Parameters.Add("$p16", SqliteType.Integer).Value = entity.HasSocialServiceCertificate;
            command.Parameters.Add("$p17", SqliteType.Integer).Value = entity.HasInternshipApplication;
            command.Parameters.Add("$p18", SqliteType.Integer).Value = entity.HasPresentationLetter;
            command.Parameters.Add("$p19", SqliteType.Integer).Value = entity.HasAcceptanceLetter;
            command.Parameters.Add("$p20", SqliteType.Integer).Value = entity.HasProjectDocument;
            command.Parameters.Add("$p21", SqliteType.Integer).Value = entity.Enabled;
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
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
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO Student
                (Id, SpecialtyId, FirstName, LastName, Email, Phone, Gender, Semester,
                StartDate, EndDate, InternalAdvisorId, ExternalAdvisorId, ReviewerAdvisorId,
                CompanyId, Department, Schedule, Notes, HasSocialServiceCertificate,
                HasInternshipApplication, HasPresentationLetter, HasAcceptanceLetter,
                HasProjectDocument, Enabled, UpdatedOn)
            VALUES ($p00, $p01, $p02, $p03, $p04, $p05, $p06, $p07, $p08, $p09, $p10, $p11,
                    $p12, $p13, $p14, $p15, $p16, $p17, $p18, $p19, $p20, $p21, $p22, CURRENT_TIMESTAMP)
            ON CONFLICT(Id) DO UPDATE
            SET SpecialtyId                 = excluded.SpecialtyId,
                FirstName                   = excluded.FirstName,
                LastName                    = excluded.LastName,
                Email                       = excluded.Email,
                Phone                       = excluded.Phone,
                Gender                      = excluded.Gender,
                Semester                    = excluded.Semester,
                StartDate                   = excluded.StartDate,
                EndDate                     = excluded.EndDate,
                InternalAdvisorId           = excluded.InternalAdvisorId,
                ExternalAdvisorId           = excluded.ExternalAdvisorId,
                ReviewerAdvisorId           = excluded.ReviewerAdvisorId,
                CompanyId                   = excluded.CompanyId,
                Department                  = excluded.Department,
                Schedule                    = excluded.Schedule,
                Notes                       = excluded.Notes,
                HasSocialServiceCertificate = excluded.HasSocialServiceCertificate,
                HasInternshipApplication    = excluded.HasInternshipApplication,
                HasPresentationLetter       = excluded.HasPresentationLetter,
                HasAcceptanceLetter         = excluded.HasAcceptanceLetter,
                HasProjectDocument          = excluded.HasProjectDocument,
                Enabled                     = excluded.Enabled,
                UpdatedOn                   = excluded.UpdatedOn,
            """;

            command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.Id;
            command.Parameters.Add("$p01", SqliteType.Integer).Value = entity.SpecialtyId;
            command.Parameters.Add("$p02", SqliteType.Text).Value = entity.FirstName;
            command.Parameters.Add("$p03", SqliteType.Text).Value = entity.LastName;
            command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p05", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Gender;
            command.Parameters.Add("$p07", SqliteType.Text).Value = entity.Semester;
            command.Parameters.Add("$p08", SqliteType.Text).Value = entity.StartDate.TOISOStringUTC();
            command.Parameters.Add("$p09", SqliteType.Text).Value = entity.EndDate.TOISOStringUTC();
            command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.InternalAdvisorId;
            command.Parameters.Add("$p11", SqliteType.Integer).Value = entity.ExternalAdvisorId;
            command.Parameters.Add("$p12", SqliteType.Integer).Value = entity.ReviewerAdvisorId;
            command.Parameters.Add("$p13", SqliteType.Integer).Value = entity.CompanyId;
            command.Parameters.Add("$p14", SqliteType.Text).Value = entity.Department;
            command.Parameters.Add("$p15", SqliteType.Text).Value = entity.Schedule;
            command.Parameters.Add("$p16", SqliteType.Text).Value = entity.Notes;
            command.Parameters.Add("$p17", SqliteType.Integer).Value = entity.HasSocialServiceCertificate;
            command.Parameters.Add("$p18", SqliteType.Integer).Value = entity.HasInternshipApplication;
            command.Parameters.Add("$p19", SqliteType.Integer).Value = entity.HasPresentationLetter;
            command.Parameters.Add("$p20", SqliteType.Integer).Value = entity.HasAcceptanceLetter;
            command.Parameters.Add("$p21", SqliteType.Integer).Value = entity.HasProjectDocument;
            command.Parameters.Add("$p22", SqliteType.Integer).Value = entity.Enabled;
            return command.ExecuteNonQuery() > 0;
        }

        protected override Student HydrateObject(IDataReader reader)
        {
            Debug.Assert(reader.FieldCount == 25);
            return new Student
            {
                Id                          = reader.GetInt64(0),
                SpecialtyId                 = reader.GetInt64(1),
                FirstName                   = reader.GetString(2),
                LastName                    = reader.GetString(3),
                Email                       = reader.GetString(4),
                Phone                       = reader.GetString(5),
                Gender                      = reader.GetEnum<Gender>(6),
                Semester                    = reader.GetString(7),
                StartDate                   = reader.GetDateTime(8),
                EndDate                     = reader.GetDateTime(9),
                InternalAdvisorId           = reader.GetNullableInt64(10),
                ExternalAdvisorId           = reader.GetNullableInt64(11),
                ReviewerAdvisorId           = reader.GetNullableInt64(12),
                CompanyId                   = reader.GetInt64(13),
                Department                  = reader.GetString(14),
                Schedule                    = reader.GetString(15),
                Notes                       = reader.GetString(16),
                HasSocialServiceCertificate = reader.GetBoolean(17),
                HasInternshipApplication    = reader.GetBoolean(18),
                HasPresentationLetter       = reader.GetBoolean(19),
                HasAcceptanceLetter         = reader.GetBoolean(20),
                HasProjectDocument          = reader.GetBoolean(21),
                Enabled                     = reader.GetBoolean(22),
                UpdatedOn                   = reader.GetLocalDateTime(23),
                CreatedOn                   = reader.GetLocalDateTime(24),
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
}
