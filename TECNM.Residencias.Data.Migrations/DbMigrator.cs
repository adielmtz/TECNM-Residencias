namespace TECNM.Residencias.Data.Migrations;

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;

/// <summary>
/// The <see cref="DbMigrator"/> class is responsible for managing and applying
/// database migrations. It ensures that the database schema is up-to-date.
/// This migrator class is intended exclusively for SQLite databases.
/// </summary>
public sealed class DbMigrator : IDisposable
{
    /// <summary>
    /// The current version of the database schema. It must only increase.
    /// This number must match the SQL migration scrips numbering.
    /// </summary>
    public static readonly long CurrentVersion = 5;

    /// <summary>
    /// The default page size for the SQLite database.
    /// </summary>
    public static readonly long DefaultPageSize = 32768;

    /// <summary>
    /// The default SQLite journal mode for transactions.
    /// </summary>
    public static readonly string DefaultJournalMode = "WAL";

    private readonly IDbConnection _connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbMigrator"/> class.
    /// </summary>
    /// <param name="connection">The database connection to be migrated.</param>
    public DbMigrator(IDbConnection connection) => _connection = connection;

    /// <summary>
    /// Gets a value indicating whether there are pending migrations to be applied.
    /// </summary>
    public bool HasPendingMigrations => UserVersion < CurrentVersion;

    /// <summary>
    /// Gets or sets the user version of the database schema.
    /// </summary>
    public long UserVersion
    {
        get => GetPragma<long>("user_version");
        private set => SetPragma("user_version", value);
    }

    /// <summary>
    /// Releases the resources used by the <see cref="DbMigrator"/> class
    /// and closes the database connection.
    /// </summary>
    public void Dispose() => _connection.Dispose();

    /// <summary>
    /// Applies any pending migrations to the database.
    /// If there are no pending migrations, this method is a no-op.
    /// </summary>
    public void Migrate()
    {
        if (!HasPendingMigrations)
        {
            return;
        }

        long version = UserVersion;
        ConfigureDatabase();

        using var transaction = _connection.BeginTransaction();

        for (long i = version + 1; i <= CurrentVersion; i++)
        {
            ApplyMigration(i);
        }

        transaction.Commit();
        SetPragma("wal_checkpoint", "FULL");
    }

    /// <summary>
    /// Executes a <c>PRAGMA</c> command to retrieve a database property.
    /// </summary>
    /// <typeparam name="T">The type of the value to be retrieved.</typeparam>
    /// <param name="name">The name of the <c>PRAGMA</c> command to execute.</param>
    /// <returns>The value of the <c>PRAGMA</c>.</returns>
    private T GetPragma<T>(string name)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $"PRAGMA {name}";
        return (T) command.ExecuteScalar()!;
    }

    /// <summary>
    /// Executes a <c>PRAGMA</c> command to set a database property.
    /// </summary>
    /// <typeparam name="T">The type of the value to be set.</typeparam>
    /// <param name="name">The name of the <c>PRAGMA</c> command to execute.</param>
    /// <param name="value">The value to set.</param>
    private void SetPragma<T>(string name, T value)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $"PRAGMA {name}={value}";
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Sets the initial database configuration.
    /// </summary>
    private void ConfigureDatabase()
    {
        SetPragma("page_size", DefaultPageSize);
        SetPragma("journal_mode", DefaultJournalMode);
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
        string resource = $"TECNM.Residencias.Data.Migrations.Resources.migration_{version}.sql";
        using var stream = assembly.GetManifestResourceStream(resource);
        Trace.Assert(stream is not null, $"Failed to get migration script resource: '{resource}'.");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
