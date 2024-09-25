namespace TECNM.Residencias.Data.Sets;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Data.Sets.Common;

public sealed class ExtraDbSet : DbSet<Extra>
{
    public ExtraDbSet(IDbContext context) : base(context)
    {
    }

    public IEnumerable<Extra> EnumerateExtras()
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Type, Value FROM Extra ORDER BY Id";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Extra extra = HydrateObject(reader);
            yield return extra;
        }
    }

    public IEnumerable<Extra> EnumerateExtras(ExtraType type)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Type, Value FROM Extra WHERE Type = $p0 ORDER BY Id";
        command.Parameters.Add("$p0", SqliteType.Text).Value = type.ToString();
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Extra extra = HydrateObject(reader);
            yield return extra;
        }
    }

    public IEnumerable<long> EnumerateExtras(Student student)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT ExtraId FROM StudentExtras WHERE StudentId = $id ORDER BY ExtraId";
        command.Parameters.Add("$id", SqliteType.Integer).Value = student.Id;
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return reader.GetInt64(0);
        }
    }

    public int DeleteExtrasForStudent(Student student)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "DELETE FROM StudentExtras WHERE StudentId = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = student.Id;
        return command.ExecuteNonQuery();
    }

    public int InsertExtrasForStudent(Student student, IList<Extra> extras)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "INSERT INTO StudentExtras (StudentId, ExtraId) VALUES ($p0, $p1) ON CONFLICT DO NOTHING";
        command.Parameters.Add("$p0", SqliteType.Integer).Value = student.Id;

        SqliteParameter parameter = command.Parameters.Add("$p1", SqliteType.Integer);
        int count = 0;

        foreach (Extra extra in extras)
        {
            parameter.Value = extra.Id;
            count += command.ExecuteNonQuery();
        }

        return count;
    }

    public override bool Insert(Extra entity)
    {
        throw new NotImplementedException();
    }

    public override int Update(Extra entity)
    {
        throw new NotImplementedException();
    }

    public override int Delete(Extra entity)
    {
        throw new NotImplementedException();
    }

    public override bool InsertOrUpdate(Extra entity)
    {
        throw new NotImplementedException();
    }

    protected override Extra HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 3);
        return new Extra
        {
            Id    = reader.GetInt64(0),
            Type  = reader.GetEnum<ExtraType>(1),
            Value = reader.GetString(2),
        };
    }
}
