namespace TECNM.Residencias.Data.Sets;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DTO;
using TECNM.Residencias.Data.Extensions;

public sealed class CompanyDbSet : DbSet<Company>
{
    /// <summary>
    /// Gets the rowid of the company master record.
    /// </summary>
    public static readonly long MasterRecordRowid = 1;

    public CompanyDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets a company entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the company entity.</param>
    /// <returns>A <see cref="Company"/> instance if a company with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public Company? GetCompany(long id)
    {
        using SqliteCommand command = CreateCommand("""
        SELECT Id, Type, Rfc, Name, Email, Phone, Extension, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn
        FROM Company
        WHERE Id = $id
        """);

        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using SqliteDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    /// <summary>
    /// Gets the master (initial) entry that represents the host school.
    /// </summary>
    /// <returns>A <see cref="Company"/> instance that represents the rowid.</returns>
    public Company GetMasterEntry()
    {
        Company? company = GetCompany(MasterRecordRowid);
        Trace.Assert(company is not null);
        return company!;
    }

    /// <summary>
    /// Searches for companies based on the specified query.
    /// </summary>
    /// <param name="query">The search term used to find companies.</param>
    /// <param name="count">The number of results to return per page.</param>
    /// <param name="page">The page number to retrieve, starting from 1.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the search results.
    /// Each item in the collection represents a company matching the search criteria.
    /// </returns>
    public IEnumerable<CompanySearchResultDto> Search(string query, int count, int page)
    {
        using SqliteCommand command = CreateCommand("""
        SELECT rowid, Rfc, Name
        FROM CompanySearch
        WHERE CompanySearch MATCH $query
        ORDER BY rank
        LIMIT $page, $count
        """);

        command.Parameters.Add("$query", SqliteType.Text).Value = query.ToFtsQuery();
        command.Parameters.Add("$page", SqliteType.Integer).Value = (page - 1) * count;
        command.Parameters.Add("$count", SqliteType.Integer).Value = count;
        using SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new CompanySearchResultDto(
                Id: reader.GetInt64(0),
                Rfc: reader.GetOptionalString(1),
                Name: reader.GetString(2)
            );
        }
    }

    public override IEnumerable<Company> EnumerateAll()
    {
        using SqliteCommand command = CreateCommand("""
        SELECT Id, Type, Rfc, Name, Email, Phone, Extension, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn
        FROM Company
        ORDER BY Name
        """);

        using SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates a paginated collection of company entities.
    /// </summary>
    /// <param name="count">The number of results to return per page.</param>
    /// <param name="page">The page number to retrieve, starting from 1.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the companies for the specified page.
    /// </returns>
    public IEnumerable<Company> EnumerateAll(int count, int page)
    {
        using SqliteCommand command = CreateCommand("""
        SELECT Id, Type, Rfc, Name, Email, Phone, Extension, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn
        FROM Company
        ORDER BY Name
        LIMIT $page, $count
        """);

        command.Parameters.Add("$page", SqliteType.Integer).Value = (page - 1) * count;
        command.Parameters.Add("$count", SqliteType.Integer).Value = count;
        using SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Company entity)
        => throw new NotImplementedException();

    public override bool Add(Company entity)
    {
        using SqliteCommand command = CreateCommand("""
        INSERT INTO Company (Type, Rfc, Name, Email, Phone, Extension, Address, Locality, PostalCode, CityId, Enabled, UpdatedOn, CreatedOn)
        VALUES ($p00, $p01, $p02, $p03, $p04, $p05, $p06, $p07, $p08, $p09, $p10, $p11, $p12)
        RETURNING Id
        """);

        command.Parameters.Add("$p00", SqliteType.Text).Value = entity.Type.ToString();
        command.Parameters.Add("$p01", SqliteType.Text).SetValue(entity.Rfc);
        command.Parameters.Add("$p02", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p03", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p05", SqliteType.Text).Value = entity.Extension;
        command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Address;
        command.Parameters.Add("$p07", SqliteType.Text).Value = entity.Locality;
        command.Parameters.Add("$p08", SqliteType.Text).Value = entity.PostalCode;
        command.Parameters.Add("$p09", SqliteType.Integer).Value = entity.CityId;
        command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p11", SqliteType.Text).Value = DateTimeOffset.Now.ToRfc3339();
        command.Parameters.Add("$p12", SqliteType.Text).Value = DateTimeOffset.Now.ToRfc3339();
        object? result = command.ExecuteScalar();

        if (result is long rowid)
        {
            entity.Id = rowid;
            return true;
        }

        return false;
    }

    public override int Update(Company entity)
    {
        using SqliteCommand command = CreateCommand("""
        UPDATE Company
        SET Type       = $p00,
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
            UpdatedOn  = $p11
        WHERE Id = $pid
        """);

        command.Parameters.Add("$p00", SqliteType.Text).Value = entity.Type.ToString();
        command.Parameters.Add("$p01", SqliteType.Text).SetValue(entity.Rfc);
        command.Parameters.Add("$p02", SqliteType.Text).Value = entity.Name;
        command.Parameters.Add("$p03", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p04", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p05", SqliteType.Text).Value = entity.Extension;
        command.Parameters.Add("$p06", SqliteType.Text).Value = entity.Address;
        command.Parameters.Add("$p07", SqliteType.Text).Value = entity.Locality;
        command.Parameters.Add("$p08", SqliteType.Text).Value = entity.PostalCode;
        command.Parameters.Add("$p09", SqliteType.Integer).Value = entity.CityId;
        command.Parameters.Add("$p10", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p11", SqliteType.Text).Value = DateTimeOffset.Now.ToRfc3339();
        command.Parameters.Add("$pid", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool AddOrUpdate(Company entity)
        => entity.Id > 0 ? Update(entity) > 0 : Add(entity);

    public override int Remove(Company entity)
        => throw new NotImplementedException();

    protected override Company HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 14);
        int index = 0;
        return new Company
        {
            Id = reader.GetInt64(index++),
            Type = reader.GetEnum<CompanyType>(index++),
            Rfc = reader.GetOptionalString(index++),
            Name = reader.GetString(index++),
            Email = reader.GetString(index++),
            Phone = reader.GetString(index++),
            Extension = reader.GetString(index++),
            Address = reader.GetString(index++),
            Locality = reader.GetString(index++),
            PostalCode = reader.GetString(index++),
            CityId = reader.GetInt64(index++),
            Enabled = reader.GetBoolean(index++),
            UpdatedOn = reader.GetDateTimeOffset(index++),
            CreatedOn = reader.GetDateTimeOffset(index++),
        };
    }
}
