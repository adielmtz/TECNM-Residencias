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

    private readonly IDbConnection _connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbMigrator"/> class.
    /// </summary>
    /// <param name="connection">The database connection to be migrated.</param>
    public DbMigrator(IDbConnection connection)
        => _connection = connection;

    /// <summary>
    /// Gets a value indicating whether there are pending migrations to be applied.
    /// </summary>
    public bool HasPendingMigrations
        => GetUserVersion() < CurrentVersion;

    /// <summary>
    /// Releases the resources used by the <see cref="DbMigrator"/> class
    /// and closes the database connection.
    /// </summary>
    public void Dispose()
        => _connection.Dispose();

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

        long version = GetUserVersion();

        using IDbTransaction transaction = _connection.BeginTransaction();

        for (long i = version + 1; i <= CurrentVersion; i++)
        {
            ApplyMigration(i);
        }

        transaction.Commit();
        FlushWalFile();
    }

    /// <summary>
    /// Flushes and syncs the WAL file into the main database.
    /// </summary>
    private void FlushWalFile()
    {
        using IDbCommand command = _connection.CreateCommand();
        command.CommandText = "PRAGMA wal_checkpoint(FULL)";
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Gets the user version of the database schema.
    /// </summary>
    /// <returns>The result of PRAGMA user_version.</returns>
    private long GetUserVersion()
    {
        using IDbCommand command = _connection.CreateCommand();
        command.CommandText = "PRAGMA user_version";
        return (long) command.ExecuteScalar()!;
    }

    /// <summary>
    /// Sets the user version of the database schema.
    /// </summary>
    /// <param name="version">The schema version to set.</param>
    private void SetUserVersion(long version)
    {
        using IDbCommand command = _connection.CreateCommand();
        command.CommandText = $"PRAGMA user_version={version}";
        command.ExecuteNonQuery();
    }

    /// <summary>
    /// Applies the migration script corresponding to the given version number.
    /// </summary>
    /// <param name="version">The version number of the migration to apply.</param>
    private void ApplyMigration(long version)
    {
        string sql = GetStringResource(version);
        using IDbCommand command = _connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
        SetUserVersion(version);
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
        using Stream? stream = assembly.GetManifestResourceStream(resource);
        Trace.Assert(stream is not null, $"Failed to get migration script resource: '{resource}'.");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
