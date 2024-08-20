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
            command.CommandText = "SELECT rowid FROM StudentSearch WHERE StudentSearch MATCH $query ORDER BY rank LIMIT $p0 OFFSET $p1";
            command.Parameters.Add("$query", SqliteType.Text).Value = query.ToFtsQuery();
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
            throw new NotImplementedException();
        }

        public override int Update(Student entity)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public override bool InsertOrUpdate(Student entity)
        {
            throw new NotImplementedException();
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
    }
}
