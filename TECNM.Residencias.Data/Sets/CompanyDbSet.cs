namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

public sealed class CompanyDbSet : DbSet<Company>
{
    public CompanyDbSet(IDbContext context) : base(context)
    {
    }

    public Company? GetCompanyById(long id)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT Id, TypeId, Rfc, Name, Email, Phone, Extension, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn
        FROM Company
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

    public IEnumerable<Company> Search(string query, int count, int page)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT rowid
        FROM CompanySearch
        WHERE CompanySearch MATCH $query
        ORDER BY rank
        LIMIT $p0 OFFSET $p1
        """;

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
        command.CommandText = """
        SELECT Id, TypeId, Rfc, Name, Email, Phone, Extension, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn
        FROM Company
        ORDER BY Name
        LIMIT $p0 OFFSET $p1
        """;

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
        INSERT INTO Company (TypeId, Rfc, Name, Email, Phone, Extension, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn)
        VALUES ($p00, $p01, $p02, $p03, $p04, $p05, $p06, $p07, $p08, $p09, $p10, CURRENT_TIMESTAMP)
        RETURNING Id
        """;

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.TypeId;
        command.Parameters.Add("$p01", SqliteType.Text).SetNullableValue(entity.Rfc);
        command.Parameters.Add("$p02", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p03", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p05", SqliteType.Text).Value = entity.Extension;
        command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Address;
        command.Parameters.Add("$p07", SqliteType.Text).Value = entity.Locality;
        command.Parameters.Add("$p08", SqliteType.Text).Value = entity.PostalCode;
        command.Parameters.Add("$p09", SqliteType.Integer).Value = entity.CityId;
        command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.Enabled;
        object? result = command.ExecuteScalar();

        entity.Id = Convert.ToInt64(result);
        return result != null;
    }

    public override int Update(Company entity)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        UPDATE Company
        SET TypeId     = $p00,
            Rfc        = $p01,
            Name       = $p02,
            Email      = $p03,
            Phone      = $p04,
            Extension  = $p05,
            Address    = $p06,
            Locality   = $p07,
            PostalCode = $p08,
            CityId     = $p09,
            Enabled    = $p10,
            UpdatedOn  = CURRENT_TIMESTAMP
        WHERE Id = $id
        """;

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.TypeId;
        command.Parameters.Add("$p01", SqliteType.Text).SetNullableValue(entity.Rfc);
        command.Parameters.Add("$p02", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p03", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p05", SqliteType.Text).Value = entity.Extension;
        command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Address;
        command.Parameters.Add("$p07", SqliteType.Text).Value = entity.Locality;
        command.Parameters.Add("$p08", SqliteType.Text).Value = entity.PostalCode;
        command.Parameters.Add("$p09", SqliteType.Integer).Value = entity.CityId;
        command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.Enabled;
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
        if (entity.Id > 0)
        {
            return Update(entity) != 0;
        }
        else
        {
            return Insert(entity);
        }
    }

    protected override Company HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 14);
        return new Company
        {
            Id         = reader.GetInt64(0),
            TypeId     = reader.GetInt64(1),
            Rfc        = reader.GetNullableString(2),
            Name       = reader.GetString(3),
            Email      = reader.GetString(4),
            Phone      = reader.GetString(5),
            Extension  = reader.GetString(6),
            Address    = reader.GetString(7),
            Locality   = reader.GetString(8),
            PostalCode = reader.GetString(9),
            CityId     = reader.GetInt64(10),
            Enabled    = reader.GetBoolean(11),
            UpdatedOn  = reader.GetLocalDateTime(12),
            CreatedOn  = reader.GetLocalDateTime(13),
        };
    }
}
