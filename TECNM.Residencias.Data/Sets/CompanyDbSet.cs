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
    public sealed class CompanyDbSet : DbSet<Company>
    {
        public CompanyDbSet(IDbContext context) : base(context)
        {
        }

        public Company? GetCompanyById(long id)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Id, Rfc, Type, Name, Email, Phone, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn FROM Company WHERE Id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return HydrateObject(reader);
        }

        public string? GetCompanyNameById(long id)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Name FROM Company WHERE Id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            return (string?) command.ExecuteScalar();
        }

        public IEnumerable<Company> Search(string query, int count, int page)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT rowid FROM CompanySearch WHERE CompanySearch MATCH $query ORDER BY rank LIMIT $p0 OFFSET $p1";
            command.Parameters.Add("$query", SqliteType.Text).Value = query.ToFtsQuery();
            command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = (page - 1) * count;
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                long rowid = reader.GetInt64(0);
                Company company = GetCompanyById(rowid)!;
                yield return company;
            }
        }

        public IEnumerable<Company> EnumerateCompanies(int count, int page)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT Id, Rfc, Type, Name, Email, Phone, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn FROM Company ORDER BY Name LIMIT $p0 OFFSET $p1";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = count;
            command.Parameters.Add("$p1", SqliteType.Integer).Value = (page - 1) * count;
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Company company = HydrateObject(reader);
                yield return company;
            }
        }

        public override bool Insert(Company entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO Company (Rfc, Type, Name, Email, Phone, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn)
            VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, $p8, $p9, CURRENT_TIMESTAMP)
            RETURNING Id
            """;

            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Rfc;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Type.ToString();
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
            UPDATE Company
            SET Rfc        = $p0,
                Type       = $p1,
                Name       = $p2,
                Email      = $p3,
                Phone      = $p4,
                Address    = $p5,
                Locality   = $p6,
                PostalCode = $p7,
                CityId     = $p8,
                Enabled    = $p9,
                UpdatedOn  = CURRENT_TIMESTAMP
            WHERE Id = $id
            """;

            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Rfc;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Type.ToString();
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
            command.CommandText = "DELETE FROM Company WHERE Id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
            return command.ExecuteNonQuery();
        }

        public override bool InsertOrUpdate(Company entity)
        {
            using var command = Context.Database.CreateCommand();
            command.CommandText = """
            INSERT INTO Company (Rfc, Type, Name, Email, Phone, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn)
            VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, $p8, $p9, CURRENT_TIMESTAMP)
            ON CONFLICT(Rfc) DO UPDATE
            SET Type       = excluded.Type,
                Name       = excluded.Name,
                Email      = excluded.Email,
                Phone      = excluded.Phone,
                Address    = excluded.Address,
                Locality   = excluded.Locality,
                PostalCode = excluded.PostalCode,
                CityId     = excluded.CityId,
                Enabled    = excluded.Enabled,
                UpdatedOn  = excluded.UpdatedOn
            RETURNING Id
            """;

            command.Parameters.Add("$p0", SqliteType.Text).Value = entity.Rfc;
            command.Parameters.Add("$p1", SqliteType.Text).Value = entity.Type.ToString();
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
                Rfc        = reader.GetString(1),
                Type       = reader.GetEnum<CompanyType>(2),
                Name       = reader.GetString(3),
                Email      = reader.GetString(4),
                Phone      = reader.GetString(5),
                Address    = reader.GetString(6),
                Locality   = reader.GetString(7),
                PostalCode = reader.GetString(8),
                CityId     = reader.GetInt64(9),
                Enabled    = reader.GetBoolean(10),
                UpdatedOn  = reader.GetLocalDateTime(11),
                CreatedOn  = reader.GetLocalDateTime(12),
            };
        }
    }
}
