namespace TECNM.Residencias;

using System;
using System.IO;
using System.Reflection;
using Microsoft.Data.Sqlite;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Migrations;

internal static class App
{
    private static readonly string s_rootDirectory;
    private static readonly string s_fileStorageDirectory;
    private static readonly string s_logsDirectory;
    private static readonly string s_tempStorageDirectory;
    private static readonly string s_dbBackupDirectory;
    private static readonly string s_databaseName;
    private static readonly string s_databasePath;
    private static readonly DbFactory s_dbFactory;
    private static readonly Version s_version;
    private static bool s_initialized = false;

    static App()
    {
        string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        s_rootDirectory = Path.Combine(appDataDirectory, "TECNM-Residencias");
        s_fileStorageDirectory = Path.Combine(s_rootDirectory, "Archivo");
        s_logsDirectory = Path.Combine(s_rootDirectory, "Logs");
        s_tempStorageDirectory = Path.Combine(s_rootDirectory, "Temp");
        s_dbBackupDirectory = Path.Combine(s_fileStorageDirectory, ".db-backups");

        s_databaseName = "database.db";
        s_databasePath = Path.Combine(s_rootDirectory, s_databaseName);
        s_dbFactory = new DbFactory(s_databasePath);

        AssemblyName name = typeof(App).Assembly.GetName();
        s_version = name.Version!;
    }

    public static int DefaultRowsPerPage 
        => 100;

    public static int DefaultInitialPage
        => 1;

    public static string Name
        => "Archivo de residencias | TECNM";

    public static Version Version
        => s_version;

    public static bool Initialized
        => s_initialized;

    public static string RootDirectory
        => s_rootDirectory;

    public static string FileStorageDirectory
        => s_fileStorageDirectory;

    public static string LogsDirectory
        => s_logsDirectory;

    public static string TempStorageDirectory
        => s_tempStorageDirectory;

    public static string DatabaseBackupDirectory
        => s_dbBackupDirectory;

    public static string DatabaseName
        => s_databaseName;

    public static string DatabaseFullName
        => s_databasePath;

    public static DbFactory Database
        => s_dbFactory;

    public static void Initialize()
    {
        if (!s_initialized)
        {
            Directory.CreateDirectory(RootDirectory);
            Directory.CreateDirectory(FileStorageDirectory);
            Directory.CreateDirectory(LogsDirectory);
            Directory.CreateDirectory(TempStorageDirectory);
            Directory.CreateDirectory(DatabaseBackupDirectory);
            InitializeDatabase();
            s_initialized = true;
        }
    }

    private static void InitializeDatabase()
    {
        using SqliteConnection sqlite = Database.CreateConnection();
        using var migrator = new DbMigrator(sqlite);

        if (migrator.HasPendingMigrations)
        {
            MakeDbBackup(sqlite);
            migrator.Migrate();
        }
    }

    private static void MakeDbBackup(SqliteConnection sqlite)
    {
        var backup = new DbBackup(sqlite, DatabaseBackupDirectory);
        backup.Execute();
    }
}
