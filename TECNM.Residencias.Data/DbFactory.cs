using Microsoft.Data.Sqlite;

namespace TECNM.Residencias.Data
{
    public sealed class DbFactory
    {
        private readonly string _dataSource;
        private string? _connectionString;

        public DbFactory(string dataSource)
        {
            _dataSource = dataSource;
        }

        public string DataSource => _dataSource;

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = new SqliteConnectionStringBuilder
                    {
                        DataSource = DataSource,
                        ForeignKeys = true,
                        DefaultTimeout = 10,
                        RecursiveTriggers = true,
                    }.ConnectionString;
                }

                return _connectionString;
            }
        }

        public SqliteConnection Open()
        {
            var sqlite = new SqliteConnection(ConnectionString);
            sqlite.Open();
            return sqlite;
        }
    }
}
