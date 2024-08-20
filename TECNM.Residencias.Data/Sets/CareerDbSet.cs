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
    public sealed class CareerDbSet : DbSet<Career>
    {
        public CareerDbSet(IDbContext context) : base(context)
        {
        }

        public Career? GetCareerById(long id)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Id, Name, Enabled, UpdatedOn, CreatedOn FROM Career WHERE Id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return HydrateObject(reader);
        }

        public IEnumerable<Career> EnumerateCareers()
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Id, Name, Enabled, UpdatedOn, CreatedOn FROM Career ORDER BY Name";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Career career = HydrateObject(reader);
                yield return career;
            }
        }

        public override bool Insert(Career entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "INSERT INTO Career (Name, Enabled, UpdatedOn) VALUES ($p0, $p1, CURRENT_TIMESTAMP) RETURNING Id";
            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }

        public override int Update(Career entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "UPDATE Career SET Name = $p0, Enabled = $p1, UpdatedOn = CURRENT_TIMESTAMP WHERE Id = $id";
            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override int Delete(Career entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "DELETE FROM Career WHERE Id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override bool InsertOrUpdate(Career entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO Career (Name, Enabled, UpdatedOn)
            VALUES ($p0, $p1, CURRENT_TIMESTAMP)
            ON CONFLICT(Name) DO UPDATE
            SET Enabled   = excluded.Enabled,
                UpdatedOn = excluded.UpdatedOn
            RETURNING Id
            """;

            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }

        protected override Career HydrateObject(IDataReader reader)
        {
            Debug.Assert(reader.FieldCount == 5);
            return new Career
            {
                Id        = reader.GetInt64(0),
                Name      = reader.GetString(1),
                Enabled   = reader.GetBoolean(2),
                UpdatedOn = reader.GetLocalDateTime(3),
                CreatedOn = reader.GetLocalDateTime(4),
            };
        }
    }
}
