using System;
using System.IO;
using TECNM.Residencias.Data;
using TECNM.Residencias.Data.Migrations;

namespace TECNM.Residencias
{
    internal static class App
    {
        private static string? s_rootDataDirectory = null;
        private static DbFactory? s_factory = null;

        public static string Name => "Archivo de residencias | TECNM";

        public static int DefaultRowsPerPage => 100;

        public static int DefaultInitialPage => 1;

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

        public static string DatabaseFile => Path.Combine(RootDataDirectory, "database.db");

        public static DbFactory Database
        {
            get
            {
                if (s_factory == null)
                {
                    s_factory = new DbFactory(DatabaseFile);
                }

                return s_factory;
            }
        }

        public static void Initialize()
        {
            Directory.CreateDirectory(RootDataDirectory);
            Directory.CreateDirectory(DocumentArchiveDirectory);
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            using var sqlite = Database.Open();
            using var migrator = new DatabaseMigrator(sqlite);
            migrator.Migrate();
        }
    }
}
