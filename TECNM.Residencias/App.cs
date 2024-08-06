using System;
using System.IO;
using TECNM.Residencias.Data;

namespace TECNM.Residencias
{
    internal static class App
    {
        private static bool s_initialized = false;
        private static string? s_rootDataDirectory = null;
        private static DbFactory? s_factory = null;

        public static string Name => "Archivo de residencias | TECNM";

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
            if (!s_initialized)
            {
                Directory.CreateDirectory(RootDataDirectory);
                Directory.CreateDirectory(DocumentArchiveDirectory);
                s_initialized = true;
            }
        }
    }
}
