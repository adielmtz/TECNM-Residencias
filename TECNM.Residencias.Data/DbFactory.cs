namespace TECNM.Residencias.Data;

using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data.Extensions;

/// <summary>
/// Factory class for creating database connections.
/// This class is intended exclusively for SQLite databases.
/// </summary>
public sealed class DbFactory
{
    /// <summary>
    /// The default page size for the SQLite database.
    /// </summary>
    public static readonly long DefaultPageSize = 32768;

    /// <summary>
    /// The default SQLite journal mode for transactions.
    /// </summary>
    public static readonly string DefaultJournalMode = "wal";

    private readonly SqliteConnectionStringBuilder _builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbFactory"/> class with the specified data source.
    /// </summary>
    /// <param name="dataSource">The data source for the SQLite database.</param>
    public DbFactory(string dataSource)
        => _builder = new SqliteConnectionStringBuilder
        {
            DataSource = dataSource,
            ForeignKeys = true,
            DefaultTimeout = 5,
            RecursiveTriggers = true,
        };

    /// <summary>
    /// Gets the connection data source.
    /// </summary>
    public string DataSource
        => _builder.DataSource;

    /// <summary>
    /// Gets the connection string used to connect to the database.
    /// </summary>
    public string ConnectionString
        => _builder.ConnectionString;

    /// <summary>
    /// Creates and opens a new <see cref="SqliteConnection"/> instance to the database.
    /// </summary>
    /// <returns>A <see cref="SqliteConnection"/> object that is ready for use.</returns>
    public SqliteConnection CreateConnection()
    {
        var sqlite = new SqliteConnection(ConnectionString);
        sqlite.Open();
        ConfigureDatabase(sqlite);
        RegisterCollations(sqlite);
        return sqlite;
    }

    /// <summary>
    /// Sets the initial database configuration.
    /// </summary>
    /// <param name="sqlite">The <see cref="SqliteConnection"/> instance to register the collation with.</param>
    private static void ConfigureDatabase(SqliteConnection sqlite)
    {
        sqlite.SetPragma("page_size", DefaultPageSize);
        sqlite.SetPragma("journal_mode", DefaultJournalMode);
    }

    /// <summary>
    /// Registers a custom collation for case-insensitive string comparison in a SQLite database.
    /// </summary>
    /// <param name="sqlite">The <see cref="SqliteConnection"/> instance to register the collation with.</param>
    /// <remarks>
    /// This method defines a custom collation named "NOCASE" that performs a case-insensitive string comparison
    /// by using <see cref="string.Compare(string, string, bool)"/> with the <c>ignoreCase</c> parameter set to <see langword="true"/>.
    /// It enables the use of the "NOCASE" collation for sorting or comparing string values in SQL queries.
    /// </remarks>
    private static void RegisterCollations(SqliteConnection sqlite)
        => sqlite.CreateCollation("NOCASE", (a, b) => string.Compare(a, b, ignoreCase: true));
}
