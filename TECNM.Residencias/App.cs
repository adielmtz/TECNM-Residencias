using System;
using System.IO;
using System.Reflection;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Migrations;

namespace TECNM.Residencias
{
    internal static class App
    {
        private static readonly string s_rootDirectory;
        private static readonly string s_fileStorageDirectory;
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
            s_tempStorageDirectory = Path.Combine(s_rootDirectory, "Temp");
            s_dbBackupDirectory = Path.Combine(s_fileStorageDirectory, ".db-backups");

            s_databaseName = "database.db";
            s_databasePath = Path.Combine(s_rootDirectory, s_databaseName);
            s_dbFactory = new DbFactory(s_databasePath);

            AssemblyName name = typeof(App).Assembly.GetName();
            s_version = name.Version!;
        }

        public static int DefaultRowsPerPage => 100;

        public static int DefaultInitialPage => 1;

        public static int MinimumReportYear => 1954;

        public static string Name => "Archivo de residencias | TECNM";

        public static string SourceCodeUrl => "https://github.com/adielmtz/TECNM-Residencias";

        public static Version Version => s_version;

        public static bool Initialized => s_initialized;

        public static string RootDirectory => s_rootDirectory;

        public static string FileStorageDirectory => s_fileStorageDirectory;

        public static string TempStorageDirectory => s_tempStorageDirectory;

        public static string DatabaseBackupDirectory => s_dbBackupDirectory;

        public static string DatabaseName => s_databaseName;

        public static string DatabaseFullName => s_databasePath;

        public static DbFactory Database => s_dbFactory;

        public static void Initialize()
        {
            Directory.CreateDirectory(RootDirectory);
            Directory.CreateDirectory(FileStorageDirectory);
            Directory.CreateDirectory(TempStorageDirectory);
            Directory.CreateDirectory(DatabaseBackupDirectory);
            InitializeDatabase();
            s_initialized = true;
        }

        private static void InitializeDatabase()
        {
            using var sqlite = Database.Open();
            using var migrator = new DatabaseMigrator(sqlite);
            migrator.Migrate();
        }
    }
}
