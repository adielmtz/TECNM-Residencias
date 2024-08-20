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
    public sealed class AdvisorDbSet : DbSet<Advisor>
    {
        public AdvisorDbSet(IDbContext context) : base(context)
        {
        }

        public Advisor? GetAdvisorById(long id)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Id, CompanyId, Type, Name, Section, Role, Email, Phone, Enabled, UpdatedOn, CreatedOn FROM Advisor WHERE Id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return HydrateObject(reader);
        }

        public IEnumerable<Advisor> EnumerateAdvisorsByCompany(long companyId)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Id, CompanyId, Type, Name, Section, Role, Email, Phone, Enabled, UpdatedOn, CreatedOn FROM Advisor WHERE CompanyId = $p0 ORDER BY Name";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = companyId;
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Advisor advisor = HydrateObject(reader);
                yield return advisor;
            }
        }

        public IEnumerable<Advisor> EnumerateAdvisors()
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Id, CompanyId, Type, Name, Section, Role, Email, Phone, Enabled, UpdatedOn, CreatedOn FROM Advisor";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Advisor advisor = HydrateObject(reader);
                yield return advisor;
            }
        }

        public override bool Insert(Advisor entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO Advisor (CompanyId, Type, Name, Section, Role, Email, Phone, Enabled, UpdatedOn)
            VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, CURRENT_TIMESTAMP)
            RETURNING Id
            """;

            command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CompanyId;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Type.ToString();
            command.Parameters.Add("$p2", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p3", SqliteType.Text).Value = entity.Section;
            command.Parameters.Add("$p4", SqliteType.Text).Value = entity.Role;
            command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p6", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p7", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }

        public override int Update(Advisor entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            UPDATE Advisor
            SET CompanyId = $p0,
                Type      = $p1,
                Name      = $p2,
                Section   = $p3,
                Role      = $p4,
                Email     = $p5,
                Phone     = $p6,
                Enabled   = $p7,
                UpdatedOn = CURRENT_TIMESTAMP
            WHERE Id = $id;
            """;

            command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CompanyId;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Type.ToString();
            command.Parameters.Add("$p2", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p3", SqliteType.Text).Value = entity.Section;
            command.Parameters.Add("$p4", SqliteType.Text).Value = entity.Role;
            command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p6", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p7", SqliteType.Integer).Value = entity.Enabled;
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override int Delete(Advisor entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "DELETE FROM Advisor WHERE Id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override bool InsertOrUpdate(Advisor entity)
        {
            if (entity.Id > 0)
            {
                return Update(entity) > 0;
            }
            else
            {
                return Insert(entity);
            }
        }

        protected override Advisor HydrateObject(IDataReader reader)
        {
            Debug.Assert(reader.FieldCount == 11);
            return new Advisor
            {
                Id        = reader.GetInt64(0),
                CompanyId = reader.GetInt64(1),
                Type      = reader.GetEnum<AdvisorType>(2),
                Name      = reader.GetString(3),
                Section   = reader.GetString(4),
                Role      = reader.GetString(5),
                Email     = reader.GetString(6),
                Phone     = reader.GetString(7),
                Enabled   = reader.GetBoolean(8),
                UpdatedOn = reader.GetLocalDateTime(9),
                CreatedOn = reader.GetLocalDateTime(10),
            };
        }
    }
}
