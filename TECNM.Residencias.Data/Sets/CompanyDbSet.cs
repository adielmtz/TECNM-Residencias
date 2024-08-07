using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DataObjects;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

namespace TECNM.Residencias.Data.Sets
{
    public sealed class CompanyDbSet : DbSet<Company>
    {
        public CompanyDbSet(IDbContext context) : base(context)
        {
        }

        public Company? GetCompanyById(long id)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, type, rfc, name, email, phone, address, locality, postcode, city_id, enabled, updated_on, created_on FROM itcm_company WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return HydrateObject(reader);
        }

        public IList<CompanySearchDto> SearchCompany(string query, int count = 100, int page = 1)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT rowid, rfc, name FROM itcm_company_search WHERE itcm_company_search MATCH $query ORDER BY rank LIMIT $p0 OFFSET $p1";
            command.Parameters.Add("$query", SqliteType.Text).Value = query.ToFtsQuery();
            command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = (page - 1) * count;
            using var reader = command.ExecuteReader();

            var result = new List<CompanySearchDto>(count);
            while (reader.Read())
            {
                result.Add(new CompanySearchDto
                {
                    Id   = reader.GetInt64(0),
                    Rfc  = reader.GetString(1),
                    Name = reader.GetString(2),
                });
            }

            return result;
        }

        public IList<Company> GetCompanies(int count = 100, int page = 1)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, type, rfc, name, email, phone, address, locality, postcode, city_id, enabled, updated_on, created_on FROM itcm_company ORDER BY name LIMIT $p0 OFFSET $p1";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = (page - 1) * count;
            using var reader = command.ExecuteReader();

            var result = new List<Company>(count);
            while (reader.Read())
            {
                Company company = HydrateObject(reader);
                result.Add(company);
            }

            return result;
        }

        public IList<Company> GetCompanies(bool enabled)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, type, rfc, name, email, phone, address, locality, postcode, city_id, enabled, updated_on, created_on FROM itcm_company WHERE enabled = $p0 ORDER BY name";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = enabled;
            using var reader = command.ExecuteReader();

            var result = new List<Company>();
            while (reader.Read())
            {
                Company company = HydrateObject(reader);
                result.Add(company);
            }

            return result;
        }

        public override bool Insert(Company entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO itcm_company (type, rfc, name, email, phone, address, locality, postcode, city_id, enabled, updated_on)
            VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, $p8, $p9, CURRENT_TIMESTAMP)
            RETURNING id
            """;

            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Type;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Rfc;
            command.Parameters.Add("$p2", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p3", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p4", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Address;
            command.Parameters.Add("$p6", SqliteType.Text).Value = entity.Locality;
            command.Parameters.Add("$p7", SqliteType.Text).Value = entity.PostalCode;
            command.Parameters.Add("$p8", SqliteType.Integer).Value = entity.CityId;
            command.Parameters.Add("$p9", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }

        public override int Update(Company entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            UPDATE itcm_company
            SET type       = $p0,
                rfc        = $p1,
                name       = $p2,
                email      = $p3,
                phone      = $p4,
                address    = $p5,
                locality   = $p6,
                postcode   = $p7,
                city_id    = $p8,
                enabled    = $p9,
                updated_on = CURRENT_TIMESTAMP
            WHERE id = $id
            """;

            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Type;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Rfc;
            command.Parameters.Add("$p2", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p3", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p4", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Address;
            command.Parameters.Add("$p6", SqliteType.Text).Value = entity.Locality;
            command.Parameters.Add("$p7", SqliteType.Text).Value = entity.PostalCode;
            command.Parameters.Add("$p8", SqliteType.Integer).Value = entity.CityId;
            command.Parameters.Add("$p9", SqliteType.Integer).Value = entity.Enabled;
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override int Delete(Company entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "DELETE FROM itcm_company WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override bool InsertOrUpdate(Company entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO itcm_company (type, rfc, name, email, phone, address, locality, postcode, city_id, enabled, updated_on)
            VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, $p8, $p9, CURRENT_TIMESTAMP)
            ON CONFLICT(rfc) DO UPDATE
            SET type       = excluded.type,
                name       = excluded.name,
                email      = excluded.email,
                phone      = excluded.phone,
                address    = excluded.address,
                locality   = excluded.locality,
                postcode   = excluded.postcode,
                city_id    = excluded.city_id,
                enabled    = excluded.enabled,
                updated_on = excluded.updated_on
            RETURNING id
            """;

            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Type;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Rfc;
            command.Parameters.Add("$p2", SqliteType.Text).Value = entity.Name;
            command.Parameters.Add("$p3", SqliteType.Text).Value = entity.Email;
            command.Parameters.Add("$p4", SqliteType.Text).Value = entity.Phone;
            command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Address;
            command.Parameters.Add("$p6", SqliteType.Text).Value = entity.Locality;
            command.Parameters.Add("$p7", SqliteType.Text).Value = entity.PostalCode;
            command.Parameters.Add("$p8", SqliteType.Integer).Value = entity.CityId;
            command.Parameters.Add("$p9", SqliteType.Integer).Value = entity.Enabled;
            object? result = command.ExecuteScalar();

            entity.Id = Convert.ToInt64(result);
            return result != null;
        }

        protected override Company HydrateObject(IDataReader reader)
        {
            Debug.Assert(reader.FieldCount == 13);
            return new Company
            {
                Id         = reader.GetInt64(0),
                Type       = Enum.Parse<CompanyType>(reader.GetString(1)),
                Rfc        = reader.GetString(2),
                Name       = reader.GetString(3),
                Email      = reader.GetString(4),
                Phone      = reader.GetString(5),
                Address    = reader.GetString(6),
                Locality   = reader.GetString(7),
                PostalCode = reader.GetString(8),
                CityId     = reader.GetInt64(9),
                Enabled    = reader.GetBoolean(10),
                UpdatedOn  = reader.GetDateTime(11),
                CreatedOn  = reader.GetDateTime(12),
            };
        }
    }
}
