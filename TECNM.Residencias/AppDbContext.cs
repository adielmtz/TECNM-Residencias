using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Sets;

namespace TECNM.Residencias
{
    internal sealed class AppDbContext : IDbContext
    {
        private readonly SqliteConnection _connection;
        private readonly SqliteTransaction _transaction;

        public SqliteConnection Database => _connection;

        private CareerDbSet? _careers;
        public CareerDbSet Careers => _careers ??= new CareerDbSet(this);

        public AppDbContext()
        {
            _connection = App.Database.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _connection.Dispose();
        }
    }
}
