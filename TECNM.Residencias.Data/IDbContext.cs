namespace TECNM.Residencias.Data;

using Microsoft.Data.Sqlite;
using System;

public interface IDbContext : IDisposable
{
    public SqliteConnection Database { get; }

    public void Commit();

    public void Rollback();
}
