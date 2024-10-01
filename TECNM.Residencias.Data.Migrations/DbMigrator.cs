namespace TECNM.Residencias.Data.Migrations;

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;

/// <summary>
/// The <see cref="DbMigrator"/> class is responsible for managing and applying
/// database migrations. It ensures that the database schema is up-to-date.
/// </summary>
public sealed class DbMigrator : IDisposable
{
    /// <summary>
    /// The current version of the database schema. Must only be increased.
    /// This number must match the migration SQL scripts numbering.
    /// </summary>
    private const long CURRENT_VERSION = 4;

    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbMigrator"/> class.
    /// </summary>
    /// <param name="connection">The database connection to be migrated.</param>
    public DbMigrator(IDbConnection connection)
    {
        _connection = connection;
    }

    /// <summary>
    /// Gets a value indicating if the database needs to be migrated.
    /// </summary>
    public bool NeedsMigration => UserVersion < CURRENT_VERSION;

    /// <summary>
    /// Gets or sets the current user version of the database schema.
    /// </summary>
    private long UserVersion
    {
        get => Convert.ToInt64(GetPragma("user_version"));
        set => SetPragma("user_version", value);
    }

    /// <summary>
    /// Gets or sets the page size of the database.
    /// </summary>
    private long PageSize
    {
        get => Convert.ToInt64(GetPragma("page_size"));
        set => SetPragma("page_size", value);
    }

    /// <summary>
    /// Gets or sets the journal mode of the database.
    /// </summary>
    private string JournalMode
    {
        get => (string) GetPragma("journal_mode")!;
        set => SetPragma("journal_mode", value);
    }

    /// <summary>
    /// Applies any required migration to the database.
    /// </summary>
    public void Migrate()
    {
        long version = UserVersion;
        ConfigureDatabase();
        _transaction = _connection.BeginTransaction();

        for (long i = version + 1; i <= CURRENT_VERSION; i++)
        {
            ApplyMigration(i);
        }

        _transaction.Commit();
        SetPragma("wal_checkpoint", "full");
    }

    /// <summary>
    /// Disposes of the active transaction and closes the database connection.
    /// </summary>
    public void Dispose()
    {
        _transaction?.Dispose();
        _connection.Dispose();
    }

    /// <summary>
    /// Executes a <c>PRAGMA</c> command to retrieve a database property.
    /// </summary>
    /// <param name="pragma">The name of the <c>PRAGMA</c> command to execute.</param>
    /// <returns>The result of the <c>PRAGMA</c> command.</returns>
    private object? GetPragma(string pragma)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $"PRAGMA {pragma};";
        return command.ExecuteScalar();
    }

    /// <summary>
    /// Executes a <c>PRAGMA</c> command to set a database property.
    /// </summary>
    /// <param name="pragma">The name of the <c>PRAGMA</c> command.</param>
    /// <param name="value">The value to assign.</param>
    private void SetPragma(string pragma, object value)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $"PRAGMA {pragma}={value};";
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Sets the initial database configuration.
    /// </summary>
    private void ConfigureDatabase()
    {
        PageSize = 4096;
        JournalMode = "wal";
    }

    /// <summary>
    /// Applies the migration script corresponding to the given version number.
    /// </summary>
    /// <param name="version">The version number of the migration to apply.</param>
    private void ApplyMigration(long version)
    {
        string sql = GetStringResource(version);
        using var command = _connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();

        UserVersion = version;
    }

    /// <summary>
    /// Retrieves the migration SQL script embedded into the assembly.
    /// </summary>
    /// <param name="version">The version number of the migration script to retrieve.</param>
    /// <returns>The content of the migration SQL script as string.</returns>
    private string GetStringResource(long version)
    {
        Assembly assembly = typeof(DbMigrator).Assembly;
        using var stream = assembly.GetManifestResourceStream($"TECNM.Residencias.Data.Migrations.Resources.migration_{version}.sql");
        Debug.Assert(stream != null);

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
