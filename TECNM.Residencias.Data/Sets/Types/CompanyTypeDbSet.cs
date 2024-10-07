namespace TECNM.Residencias.Data.Sets.Types;

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

public sealed class CompanyTypeDbSet : DbSet<CompanyType>
{
    public CompanyTypeDbSet(IDbContext context) : base(context)
    {
    }

    public CompanyType? GetCompanyTypeById(long id)
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Label FROM CompanyType WHERE Id = $id";
        command.Parameters.Add("$id", SqliteType.Integer).Value = id;
        using var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        return HydrateObject(reader);
    }

    public IEnumerable<CompanyType> EnumerateAll()
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Label FROM CompanyType ORDER BY Id";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            CompanyType type = HydrateObject(reader);
            yield return type;
        }
    }

    public override bool Insert(CompanyType entity)
    {
        throw new NotImplementedException();
    }

    public override int Update(CompanyType entity)
    {
        throw new NotImplementedException();
    }

    public override int Delete(CompanyType entity)
    {
        throw new NotImplementedException();
    }

    public override bool InsertOrUpdate(CompanyType entity)
    {
        throw new NotImplementedException();
    }

    protected override CompanyType HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 2);
        return new CompanyType
        {
            Id    = reader.GetInt64(0),
            Label = reader.GetString(1),
        };
    }
}
