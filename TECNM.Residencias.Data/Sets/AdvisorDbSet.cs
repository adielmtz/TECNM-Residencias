namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DTO;
using TECNM.Residencias.Data.Extensions;

public sealed class AdvisorDbSet : DbSet<Advisor>
{
    public AdvisorDbSet(DbContext context) : base(context)
    {
    }

    /// <summary>
    /// Gets an advisor entity by its unique rowid.
    /// </summary>
    /// <param name="id">The unique rowid of the advisor entity.</param>
    /// <returns>A <see cref="Advisor"/> instance if an advisor with the specified rowid exists; otherwise <see langword="null"/>.</returns>
    public Advisor? GetAdvisor(long id)
    {
        using var command = CreateCommand("""
        SELECT Id, CompanyId, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn
        FROM Advisor
        WHERE Id = $id
        """);

        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return HydrateObject(reader);
        }

        return null;
    }

    /// <summary>
    /// Searches for advisors based on the specified query.
    /// </summary>
    /// <param name="query">The search term used to find advisors.</param>
    /// <param name="count">The number of results to return per page.</param>
    /// <param name="page">The page number to retrieve, starting from 1.</param>
    /// <param name="filterCompanyId">Optional. A specific company ID to filter the results by. If null, no company filter is applied.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> enumerating a collection of <see cref="AdvisorSearchResultDto"/> representing the search results.
    /// </returns>
    public IEnumerable<AdvisorSearchResultDto> Search(string query, int count, int page, long? filterCompanyId = null)
    {
        using var command = CreateCommand();
        string extraMatch = "";

        if (filterCompanyId.HasValue)
        {
            extraMatch += "CompanyId MATCH $e1 AND";
            command.Parameters.Add("$e1", SqliteType.Integer).Value = filterCompanyId.Value;
        }

        command.CommandText = $"""
        SELECT rowid, CompanyId, FirstName, LastName
        FROM AdvisorSearch
        WHERE {extraMatch} AdvisorSearch MATCH $query
        ORDER BY rank
        LIMIT $page, $count
        """;

        command.Parameters.Add("$query", SqliteType.Text).Value = query.ToFtsQuery();
        command.Parameters.Add("$page", SqliteType.Integer).Value = (page - 1) * count;
        command.Parameters.Add("$count", SqliteType.Integer).Value = count;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new AdvisorSearchResultDto(
                Id:        reader.GetInt64(0),
                CompanyId: reader.GetInt64(1),
                FirstName: reader.GetString(2),
                LastName:  reader.GetString(3)
            );
        }
    }

    public override IEnumerable<Advisor> EnumerateAll()
    {
        using var command = CreateCommand("""
        SELECT Id, CompanyId, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn
        FROM Advisor
        ORDER BY CompanyId, LastName, FirstName
        """);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    /// <summary>
    /// Retrieves and enumerates all advisor entities that belong to the specified company.
    /// </summary>
    /// <param name="company">A <see cref="Company"/> instance to use as filter.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> enumerating all the entities.</returns>
    public IEnumerable<Advisor> EnumerateAll(Company company)
    {
        using var command = CreateCommand("""
        SELECT Id, CompanyId, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn
        FROM Advisor
        WHERE CompanyId = $cid
        ORDER BY LastName, FirstName
        """);

        command.Parameters.Add("$cid", SqliteType.Integer).Value = company.Id;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return HydrateObject(reader);
        }
    }

    public override bool Contains(Advisor entity) => throw new NotImplementedException();

    public override bool Add(Advisor entity)
    {
        using var command = CreateCommand("""
        INSERT INTO Advisor (CompanyId, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn)
        VALUES ($p00, $p01, $p02, $p03, $p04, $p05, $p06, $p07, $p08, $p09, $p10)
        RETURNING Id
        """);

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p01", SqliteType.Text).Value    = entity.FirstName;
        command.Parameters.Add("$p02", SqliteType.Text).Value    = entity.LastName;
        command.Parameters.Add("$p03", SqliteType.Text).Value    = entity.Section;
        command.Parameters.Add("$p04", SqliteType.Text).Value    = entity.Role;
        command.Parameters.Add("$p05", SqliteType.Text).Value    = entity.Email;
        command.Parameters.Add("$p06", SqliteType.Text).Value    = entity.Phone;
        command.Parameters.Add("$p07", SqliteType.Text).Value    = entity.Extension;
        command.Parameters.Add("$p08", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p09", SqliteType.Text).Value    = DateTimeOffset.Now.ToRfc3339();
        command.Parameters.Add("$p10", SqliteType.Text).Value    = DateTimeOffset.Now.ToRfc3339();
        object? result = command.ExecuteScalar();

        if (result is long rowid)
        {
            entity.Id = rowid;
            return true;
        }

        return false;
    }

    public override int Update(Advisor entity)
    {
        using var command = CreateCommand("""
        UPDATE Advisor
        SET CompanyId = $p0,
            FirstName = $p1,
            LastName  = $p2,
            Section   = $p3,
            Role      = $p4,
            Email     = $p5,
            Phone     = $p6,
            Extension = $p7,
            Enabled   = $p8,
            UpdatedOn = $p9
        WHERE Id = $id
        """);

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p1", SqliteType.Text).Value    = entity.FirstName;
        command.Parameters.Add("$p2", SqliteType.Text).Value    = entity.LastName;
        command.Parameters.Add("$p3", SqliteType.Text).Value    = entity.Section;
        command.Parameters.Add("$p4", SqliteType.Text).Value    = entity.Role;
        command.Parameters.Add("$p5", SqliteType.Text).Value    = entity.Email;
        command.Parameters.Add("$p6", SqliteType.Text).Value    = entity.Phone;
        command.Parameters.Add("$p7", SqliteType.Text).Value    = entity.Extension;
        command.Parameters.Add("$p8", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p9", SqliteType.Text).Value    = DateTimeOffset.Now.ToRfc3339();
        command.Parameters.Add("$id", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool AddOrUpdate(Advisor entity)
    {
        return entity.Id > 0 ? Update(entity) > 0 : Add(entity);
    }

    public override int Remove(Advisor entity) => throw new NotImplementedException();

    protected override Advisor HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 12);
        int index = 0;
        return new Advisor
        {
            Id        = reader.GetInt64(index++),
            CompanyId = reader.GetInt64(index++),
            FirstName = reader.GetString(index++),
            LastName  = reader.GetString(index++),
            Section   = reader.GetString(index++),
            Role      = reader.GetString(index++),
            Email     = reader.GetString(index++),
            Phone     = reader.GetString(index++),
            Extension = reader.GetString(index++),
            Enabled   = reader.GetBoolean(index++),
            UpdatedOn = reader.GetDateTimeOffset(index++),
            CreatedOn = reader.GetDateTimeOffset(index++),
        };
    }
}
