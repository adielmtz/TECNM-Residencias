namespace TECNM.Residencias.Data.Sets.Types;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

public sealed class DocumentTypeDbSet : DbSet<DocumentType>
{
    public DocumentTypeDbSet(IDbContext context) : base(context)
    {
    }

    public IEnumerable<DocumentType> EnumerateAll()
    {
        using var command = Context.Database.CreateCommand();
        command.CommandText = "SELECT Id, Label, Tag, Keywords FROM DocumentType";
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            DocumentType type = HydrateObject(reader);
            yield return type;
        }
    }

    public override bool Insert(DocumentType entity)
    {
        throw new NotImplementedException();
    }

    public override int Update(DocumentType entity)
    {
        throw new NotImplementedException();
    }

    public override int Delete(DocumentType entity)
    {
        throw new NotImplementedException();
    }

    public override bool InsertOrUpdate(DocumentType entity)
    {
        throw new NotImplementedException();
    }

    protected override DocumentType HydrateObject(IDataReader reader)
    {
        Debug.Assert(reader.FieldCount == 4);
        return new DocumentType
        {
            Id       = reader.GetInt64(0),
            Label    = reader.GetString(1),
            Tag      = reader.GetString(2),
            Keywords = reader.GetString(3),
        };
    }
}
