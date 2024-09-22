using System;
using System.IO;
using System.Reflection;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Migrations;

namespace TECNM.Residencias
{
    internal static class App
    {
        private static string? s_rootDataDirectory = null;
        private static DbFactory? s_factory = null;
        private static Version? s_version = null;
        private static bool s_initialized = false;

        public static bool Initialized => s_initialized;

        public static string Name => "Archivo de residencias | TECNM";

        public static Version Version
        {
            get
            {
                if (s_version == null)
                {
                    AssemblyName name = typeof(App).Assembly.GetName();
                    s_version = name.Version;
                }

                return s_version!;
            }
        }

        public static string SourceCodeUrl => "https://github.com/adielmtz/TECNM-Residencias";

        public static int DefaultRowsPerPage => 100;

        public static int DefaultInitialPage => 1;

        public static int MinimumReportYear => 1954;

        public static string RootDataDirectory
        {
            get
            {
                if (s_rootDataDirectory == null)
                {
                    string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    s_rootDataDirectory = Path.Combine(directory, "TECNM-Residencias");
                }

                return s_rootDataDirectory;
            }
        }

        public static string DocumentArchiveDirectory => Path.Combine(RootDataDirectory, "Archivo");

        public static string DatabaseName => "database.db";

        public static string DatabaseFullName => Path.Combine(RootDataDirectory, DatabaseName);

        public static DbFactory Database
        {
            get
            {
                if (s_factory == null)
                {
                    s_factory = new DbFactory(DatabaseFullName);
                }

                return s_factory;
            }
        }

        public static void Initialize()
        {
            Directory.CreateDirectory(RootDataDirectory);
            Directory.CreateDirectory(DocumentArchiveDirectory);
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
