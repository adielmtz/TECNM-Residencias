namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

public sealed class AdvisorDbSet : DbSet<Advisor>
{
    public AdvisorDbSet(IDbContext context) : base(context)
    {
    }

    public Advisor? GetAdvisorById(long id)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT Id, CompanyId, Internal, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn
        FROM Advisor
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

    public IEnumerable<Advisor> Search(string query, int count, int page, long? filterCompanyId = null, bool? filterInternal = null)
    {
        using var command = Context.Database.CreateCommand();
        string extraMatch = "";

        if (filterCompanyId != null)
        {
            extraMatch += "CompanyId MATCH $e1 AND";
            command.Parameters.Add("$e1", SqliteType.Integer).Value = filterCompanyId.Value;
        }

        if (filterInternal != null)
        {
            extraMatch += "Internal MATCH $e2 AND";
            command.Parameters.Add("$e2", SqliteType.Integer).Value = filterInternal.Value;
        }

        command.CommandText = $"""
        SELECT rowid
        FROM AdvisorSearch
        WHERE {extraMatch} AdvisorSearch MATCH $query
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
            Advisor advisor = GetAdvisorById(rowid)!;
            yield return advisor;
        }
    }

    public IEnumerable<Advisor> EnumerateAdvisorsByCompany(long companyId)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = """
        SELECT Id, CompanyId, Internal, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn
        FROM Advisor
        WHERE CompanyId = $p0
        ORDER BY FirstName, LastName
        """;

        command.Parameters.Add("$p0", SqliteType.Integer).Value = companyId;
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
        INSERT INTO Advisor (CompanyId, Internal, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn)
        VALUES ($p0, $p1, $p2, $p3, $p4, $p5, $p6, $p7, $p8, $p9, CURRENT_TIMESTAMP)
        RETURNING Id
        """;

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Internal;
        command.Parameters.Add("$p2", SqliteType.Text).Value = entity.FirstName;
        command.Parameters.Add("$p3", SqliteType.Text).Value = entity.LastName;
        command.Parameters.Add("$p4", SqliteType.Text).Value = entity.Section;
        command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Role;
        command.Parameters.Add("$p6", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p7", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p8", SqliteType.Text).Value = entity.Extension;
        command.Parameters.Add("$p9", SqliteType.Integer).Value = entity.Enabled;
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
            Internal  = $p1,
            FirstName = $p2,
            LastName  = $p3,
            Section   = $p4,
            Role      = $p5,
            Email     = $p6,
            Phone     = $p7,
            Extension = $p8,
            Enabled   = $p9,
            UpdatedOn = CURRENT_TIMESTAMP
        WHERE Id = $id
        """;

        command.Parameters.Add("$p0", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p1", SqliteType.Integer).Value = entity.Internal;
        command.Parameters.Add("$p2", SqliteType.Text).Value = entity.FirstName;
        command.Parameters.Add("$p3", SqliteType.Text).Value = entity.LastName;
        command.Parameters.Add("$p4", SqliteType.Text).Value = entity.Section;
        command.Parameters.Add("$p5", SqliteType.Text).Value = entity.Role;
        command.Parameters.Add("$p6", SqliteType.Text).Value = entity.Email;
        command.Parameters.Add("$p7", SqliteType.Text).Value = entity.Phone;
        command.Parameters.Add("$p8", SqliteType.Text).Value = entity.Extension;
        command.Parameters.Add("$p9", SqliteType.Integer).Value = entity.Enabled;
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
        Debug.Assert(reader.FieldCount == 13);
        return new Advisor
        {
            Id        = reader.GetInt64(0),
            CompanyId = reader.GetInt64(1),
            Internal  = reader.GetBoolean(2),
            FirstName = reader.GetString(3),
            LastName  = reader.GetString(4),
            Section   = reader.GetString(5),
            Role      = reader.GetString(6),
            Email     = reader.GetString(7),
            Phone     = reader.GetString(8),
            Extension = reader.GetString(9),
            Enabled   = reader.GetBoolean(10),
            UpdatedOn = reader.GetLocalDateTime(11),
            CreatedOn = reader.GetLocalDateTime(12),
        };
    }
}
