namespace TECNM.Residencias.Data.Migrations;

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;

public sealed class DbMigrator : IDisposable
{
    private const long CURRENT_VERSION = 4;

    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public DbMigrator(IDbConnection connection)
    {
        _connection = connection;
    }

    public bool NeedsMigration => UserVersion < CURRENT_VERSION;

    private long UserVersion
    {
        get => Convert.ToInt64(GetPragma("user_version"));
        set => SetPragma("user_version", value);
    }

    private long PageSize
    {
        get => Convert.ToInt64(GetPragma("page_size"));
        set => SetPragma("page_size", value);
    }

    private string JournalMode
    {
        get => (string) GetPragma("journal_mode")!;
        set => SetPragma("journal_mode", value);
    }

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

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection.Dispose();
    }

    private object? GetPragma(string pragma)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $"PRAGMA {pragma};";
        return command.ExecuteScalar();
    }

    private void SetPragma(string pragma, object value)
    {
        using var command = _connection.CreateCommand();
        command.CommandText = $"PRAGMA {pragma}={value};";
        command.ExecuteNonQuery();
    }

    private void ConfigureDatabase()
    {
        PageSize = 4096;
        JournalMode = "wal";
    }

    private void ApplyMigration(long version)
    {
        string sql = GetStringResource(version);
        using var command = _connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();

        UserVersion = version;
    }

    private string GetStringResource(long version)
    {
        Assembly assembly = typeof(DbMigrator).Assembly;
        using var stream = assembly.GetManifestResourceStream($"TECNM.Residencias.Data.Migrations.Resources.migration_{version}.sql");
        Debug.Assert(stream != null);

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
