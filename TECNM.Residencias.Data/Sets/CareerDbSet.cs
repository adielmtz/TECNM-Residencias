using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
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

            return new Career
            {
                Id        = reader.GetInt64(0),
                Name      = reader.GetString(1),
                Enabled   = reader.GetBoolean(2),
                UpdatedOn = reader.GetDateTime(3),
                CreatedOn = reader.GetDateTime(4),
            };
        }

        public IList<Career> GetCareers()
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, name, enabled, updated_on, created_on FROM itcm_career ORDER BY name";
            using var reader = command.ExecuteReader();

            var result = new List<Career>(10);
            while (reader.Read())
            {
                result.Add(new Career
                {
                    Id        = reader.GetInt64(0),
                    Name      = reader.GetString(1),
                    Enabled   = reader.GetBoolean(2),
                    UpdatedOn = reader.GetDateTime(3),
                    CreatedOn = reader.GetDateTime(4),
                });
            }

            return result;
        }

        public IList<Career> GetCareers(bool enabled)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, name, enabled, updated_on, created_on FROM itcm_career WHERE enabled = $p0 ORDER BY name";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = enabled;
            using var reader = command.ExecuteReader();

            var result = new List<Career>(10);
            while (reader.Read())
            {
                result.Add(new Career
                {
                    Id        = reader.GetInt64(0),
                    Name      = reader.GetString(1),
                    Enabled   = reader.GetBoolean(2),
                    UpdatedOn = reader.GetDateTime(3),
                    CreatedOn = reader.GetDateTime(4),
                });
            }

            return result;
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
    }
}
