using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Sets;
using TECNM.Residencias.Data.Sets.Location;

namespace TECNM.Residencias
{
    internal sealed class AppDbContext : IDbContext
    {
        private readonly SqliteConnection _connection;
        private readonly SqliteTransaction _transaction;

        public SqliteConnection Database => _connection;

        #region DbSets
        private CountryDbSet? _countries;
        public CountryDbSet Countries => _countries ??= new CountryDbSet(this);

        private StateDbSet? _states;
        public StateDbSet States => _states ??= new StateDbSet(this);

        private CityDbSet? _cities;
        public CityDbSet Cities => _cities ??= new CityDbSet(this);

        private CareerDbSet? _careers;
        public CareerDbSet Careers => _careers ??= new CareerDbSet(this);

        private SpecialtyDbSet? _specialties;
        public SpecialtyDbSet Specialties => _specialties ??= new SpecialtyDbSet(this);

        private CompanyDbSet? _companies;
        public CompanyDbSet Companies => _companies ??= new CompanyDbSet(this);
        #endregion

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
