namespace TECNM.Residencias.Services;

using System.Collections.Generic;
using System.IO;
using System.Linq;

internal static class DirectoryCleanupService
{
    public static void DeleteOldFiles(string directory, int maxFilesToKeep)
    {
        IList<string> entries = Directory.EnumerateFiles(directory)
            .Order()
            .ToList();

        if (entries.Count < maxFilesToKeep)
        {
            return;
        }

        int limit = entries.Count - maxFilesToKeep;
        for (int i = 0; i < limit; i++)
        {
            File.Delete(entries[i]);
        }
    }

    public static void DeleteDirectoryIfEmpty(string directory)
    {
        IEnumerable<string> entries = Directory.EnumerateFileSystemEntries(directory);
        if (!entries.Any())
        {
            Directory.Delete(directory);
        }
    }
}
