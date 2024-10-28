namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Entities;

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
        SELECT Id, CompanyId, Internal, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn
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

    public override IEnumerable<Advisor> EnumerateAll()
    {
        using var command = CreateCommand("""
        SELECT Id, CompanyId, Internal, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn
        FROM Advisor
        ORDER BY CompanyId, FirstName, LastName
        """);

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
        INSERT INTO Advisor (CompanyId, Internal, FirstName, LastName, Section, Role, Email, Phone, Extension, Enabled, UpdatedOn, CreatedOn)
        VALUES ($p00, $p01, $p02, $p03, $p04, $p05, $p06, $p07, $p08, $p09, $p10, $p11)
        RETURNING Id
        """);

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p01", SqliteType.Integer).Value = entity.Internal;
        command.Parameters.Add("$p02", SqliteType.Text).Value    = entity.FirstName;
        command.Parameters.Add("$p03", SqliteType.Text).Value    = entity.LastName;
        command.Parameters.Add("$p04", SqliteType.Text).Value    = entity.Section;
        command.Parameters.Add("$p05", SqliteType.Text).Value    = entity.Role;
        command.Parameters.Add("$p06", SqliteType.Text).Value    = entity.Email;
        command.Parameters.Add("$p07", SqliteType.Text).Value    = entity.Phone;
        command.Parameters.Add("$p08", SqliteType.Text).Value    = entity.Extension;
        command.Parameters.Add("$p09", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p10", SqliteType.Text).Value    = DateTimeOffset.Now;
        command.Parameters.Add("$p11", SqliteType.Text).Value    = DateTimeOffset.Now;
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
        SET CompanyId = $p00,
            Internal  = $p01,
            FirstName = $p02,
            LastName  = $p03,
            Section   = $p04,
            Role      = $p05,
            Email     = $p06,
            Phone     = $p07,
            Extension = $p08,
            Enabled   = $p09,
            UpdatedOn = $p10
        WHERE Id = $pid
        """);

        command.Parameters.Add("$p00", SqliteType.Integer).Value = entity.CompanyId;
        command.Parameters.Add("$p01", SqliteType.Integer).Value = entity.Internal;
        command.Parameters.Add("$p02", SqliteType.Text).Value    = entity.FirstName;
        command.Parameters.Add("$p03", SqliteType.Text).Value    = entity.LastName;
        command.Parameters.Add("$p04", SqliteType.Text).Value    = entity.Section;
        command.Parameters.Add("$p05", SqliteType.Text).Value    = entity.Role;
        command.Parameters.Add("$p06", SqliteType.Text).Value    = entity.Email;
        command.Parameters.Add("$p07", SqliteType.Text).Value    = entity.Phone;
        command.Parameters.Add("$p08", SqliteType.Text).Value    = entity.Extension;
        command.Parameters.Add("$p09", SqliteType.Integer).Value = entity.Enabled;
        command.Parameters.Add("$p10", SqliteType.Text).Value    = DateTimeOffset.Now;
        command.Parameters.Add("$pid", SqliteType.Integer).Value = entity.Id;
        return command.ExecuteNonQuery();
    }

    public override bool AddOrUpdate(Advisor entity)
    {
        return entity.Id > 0 ? Update(entity) > 0 : Add(entity);
    }

    public override int Remove(Advisor entity) => throw new NotImplementedException();

    protected override Advisor HydrateObject(SqliteDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 13);
        int index = 0;
        return new Advisor
        {
            Id        = reader.GetInt64(index++),
            CompanyId = reader.GetInt64(index++),
            Internal  = reader.GetBoolean(index++),
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
