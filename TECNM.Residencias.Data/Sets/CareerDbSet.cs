using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
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
            command.CommandText = "SELECT id, name, enabled, updated_on, created_on FROM itcm_career WHERE id = $id";
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
            command.CommandText = "SELECT id, name, enabled, updated_on, created_on FROM itcm_career ORDER BY name";
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
            command.CommandText = "INSERT INTO itcm_career (name, enabled, updated_on) VALUES ($p0, $p1, CURRENT_TIMESTAMP) RETURNING id";
            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }

        public override int Update(Career entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "UPDATE itcm_career SET name = $p0, enabled = $p1, updated_on = CURRENT_TIMESTAMP WHERE id = $p2";
            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Enabled;
            command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override int Delete(Career entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "DELETE FROM itcm_career WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override bool InsertOrUpdate(Career entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO itcm_career (name, enabled, updated_on)
            VALUES ($p0, $p1, CURRENT_TIMESTAMP)
            ON CONFLICT(name) DO UPDATE
            SET enabled    = excluded.enabled,
                updated_on = excluded.updated_on
            RETURNING id
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
                UpdatedOn = reader.GetDateTime(3),
                CreatedOn = reader.GetDateTime(4),
            };
        }
    }
}
