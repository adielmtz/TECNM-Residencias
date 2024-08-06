using Microsoft.Data.Sqlite;
using System;

namespace TECNM.Residencias.Data
{
    public interface IDbContext : IDisposable
    {
        public SqliteConnection Database { get; }

        public void Save();

        public void Rollback();
    }
}
