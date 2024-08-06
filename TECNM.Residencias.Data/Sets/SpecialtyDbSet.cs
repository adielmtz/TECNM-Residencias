using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

namespace TECNM.Residencias.Data.Sets
{
    public sealed class SpecialtyDbSet : DbSet<Specialty>
    {
        public SpecialtyDbSet(IDbContext context) : base(context)
        {
        }

        public Specialty? GetSpecialtyById(long id)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, career_id, name, enabled, updated_on, created_on FROM itcm_specialty WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return new Specialty
            {
                Id        = reader.GetInt64(0),
                CareerId  = reader.GetInt64(1),
                Name      = reader.GetString(2),
                Enabled   = reader.GetBoolean(3),
                UpdatedOn = reader.GetDateTime(4),
                CreatedOn = reader.GetDateTime(5),
            };
        }

        public IList<Specialty> GetSpecialtiesByCareer(Career career)
        {
            return GetSpecialtiesByCareer(career.Id);
        }

        public IList<Specialty> GetSpecialtiesByCareer(long careerId)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, career_id, name, enabled, updated_on, created_on FROM itcm_specialty WHERE career_id = $p0 ORDER BY name";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = careerId;
            using var reader = command.ExecuteReader();

            var result = new List<Specialty>(10);
            while (reader.Read())
            {
                result.Add(new Specialty
                {
                    Id        = reader.GetInt64(0),
                    CareerId  = reader.GetInt64(1),
                    Name      = reader.GetString(2),
                    Enabled   = reader.GetBoolean(3),
                    UpdatedOn = reader.GetDateTime(4),
                    CreatedOn = reader.GetDateTime(5),
                });
            }

            return result;
        }

        public override bool Insert(Specialty entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "INSERT INTO itcm_specialty (career_id, name, enabled, updated_on) VALUES ($p0, $p1, $p2, CURRENT_TIMESTAMP) RETURNING id";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }

        public override int Update(Specialty entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "UPDATE itcm_specialty SET career_id = $p0, name = $p1, enabled = $p2, updated_on = CURRENT_TIMESTAMP WHERE id = $id";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override int Delete(Specialty entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "DELETE FROM itcm_specialty WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override bool InsertOrUpdate(Specialty entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO itcm_specialty (career_id, name, enabled, updated_on)
            VALUES ($p0, $p1, $p2, CURRENT_TIMESTAMP)
            ON CONFLICT(career_id, name) DO UPDATE
            SET enabled    = excluded.enabled,
                updated_on = excluded.updated_on
            RETURNING id
            """;

            command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CareerId;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p2", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }
    }
}
