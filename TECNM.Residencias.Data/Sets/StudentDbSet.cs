using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            command.CommandText = "SELECT id, specialty_id, first_name, last_name, email, phone, gender, semester, start_date, end_date, internal_advisor_id, external_advisor_id, reviewer_advisor_id, company_id, department, schedule, closed, notes, updated_on, created_on FROM itcm_student WHERE id = $id";
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
            command.CommandText = "SELECT rowid FROM itcm_student_search WHERE itcm_student_search MATCH $query ORDER BY rank LIMIT $p0 OFFSET $p1";
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
            command.CommandText = "SELECT id, specialty_id, first_name, last_name, email, phone, gender, semester, start_date, end_date, internal_advisor_id, external_advisor_id, reviewer_advisor_id, company_id, department, schedule, closed, notes, updated_on, created_on FROM itcm_student ORDER BY id LIMIT $p0 OFFSET $p1";
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
            Debug.Assert(reader.FieldCount == 20);
            return new Student
            {
                Id               = reader.GetInt64(0),
                SpecialtyId      = reader.GetInt64(1),
                FirstName        = reader.GetString(2),
                LastName         = reader.GetString(3),
                Email            = reader.GetString(4),
                Phone            = reader.GetString(5),
                Gender           = reader.GetEnum<Gender>(6),
                Semester         = reader.GetString(7),
                StartDate        = reader.GetDateTime(8),
                EndDate          = reader.GetDateTime(9),
                InternalAsesorId = reader.GetNullableInt64(10),
                ExternalAsesorId = reader.GetNullableInt64(11),
                ReviewerAsesorId = reader.GetNullableInt64(12),
                CompanyId        = reader.GetInt64(13),
                Department       = reader.GetString(14),
                Schedule         = reader.GetString(15),
                Enabled           = reader.GetBoolean(16),
                Notes            = reader.GetString(17),
                UpdatedOn        = reader.GetLocalDateTime(18),
                CreatedOn        = reader.GetLocalDateTime(19),
            };
        }
    }
}
