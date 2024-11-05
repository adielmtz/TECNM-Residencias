namespace TECNM.Residencias.Data;

using Microsoft.Data.Sqlite;
using System.Diagnostics;

/// <summary>
/// Factory class for creating database connections.
/// This class is intended exclusively for SQLite databases.
/// </summary>
public sealed class DbFactory
{
    private readonly string _dataSource;
    private readonly string _connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbFactory"/> class with the specified data source.
    /// </summary>
    /// <param name="dataSource">The data source for the SQLite database.</param>
    public DbFactory(string dataSource)
    {
        _dataSource = dataSource;
        _connectionString = new SqliteConnectionStringBuilder
        {
            DataSource = dataSource,
            ForeignKeys = true,
            DefaultTimeout = 5,
            RecursiveTriggers = true,
        }.ConnectionString;
    }

    /// <summary>
    /// Gets the connection data source.
    /// </summary>
    public string DataSource => _dataSource;

    /// <summary>
    /// Gets the connection string used to connect to the database.
    /// </summary>
    public string ConnectionString => _connectionString;

    /// <summary>
    /// Creates and opens a new <see cref="SqliteConnection"/> instance to the database.
    /// </summary>
    /// <returns>A <see cref="SqliteConnection"/> object that is ready for use.</returns>
    public SqliteConnection CreateConnection()
    {
        var sqlite = new SqliteConnection(ConnectionString);
        RegisterCollations(sqlite);
        sqlite.Open();
        return sqlite;
    }

    private void RegisterCollations(SqliteConnection sqlite)
    {
        sqlite.CreateCollation("NOCASE", (a, b) => string.Compare(a, b, ignoreCase: true));
    }
}
