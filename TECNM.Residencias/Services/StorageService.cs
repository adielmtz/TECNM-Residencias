namespace TECNM.Residencias.Services;

using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TECNM.Residencias.Data.Entities;

internal static class StorageService
{
    /// <summary>
    /// Retrieves the full path of the document by combining the application's file storage directory
    /// with the document's relative location.
    /// </summary>
    /// <param name="document">The document object that contains the relative location of the document.</param>
    /// <returns>The full file path where the document is stored on the system.</returns>
    public static string GetDocumentPath(Document document)
    {
        return Path.Combine(App.FileStorageDirectory, document.Location);
    }

    /// <summary>
    /// Converts a full file path to a relative file path with respect to the application's file storage directory.
    /// </summary>
    /// <param name="fullname">The full file path of the document.</param>
    /// <returns>The relative file path from the application's file storage directory to the document.</returns>
    public static string GetDocumentLocation(string fullname)
    {
        return Path.GetRelativePath(App.FileStorageDirectory, fullname);
    }

    public static async Task<Document> SaveFileAsync(Student owner, string filename, Document document, DocumentType type)
    {
        Debug.Assert(owner.Id > 0);
        Debug.Assert(document.Id == 0);

        // Generate temporary file
        string sourceFileName = filename;
        string tempFileName = Path.Combine(App.TempStorageDirectory, Guid.NewGuid().ToString());
        long size = 0;
        string hash = "";

        await using (var sourceStream = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        await using (var outputStream = new FileStream(tempFileName, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            size = sourceStream.Length;
            hash = await CopyAndComputeHashAsync(sourceStream, outputStream);
        }

        var builder = new FileNameBuilder
        {
            StudentId = owner.Id,
            Year      = owner.StartDate.Year,
            Semester  = owner.Semester,
            Type      = type,
            Hash      = hash,
            Extension = Path.GetExtension(sourceFileName),
        };

        Directory.CreateDirectory(builder.Directory);
        File.Move(tempFileName, builder.FullPath, true);

        return new Document
        {
            StudentId    = builder.StudentId,
            TypeId       = type.Id,
            Location     = GetDocumentLocation(builder.FullPath),
            OriginalName = document.OriginalName,
            Size         = size,
            Hash         = hash,
        };
    }

    public static void DeleteDocument(Document document)
    {
        string filename = GetDocumentPath(document);
        File.Delete(filename);
        string directory = Path.GetDirectoryName(filename)!;
        DirectoryCleanupService.DeleteDirectoryIfEmpty(directory);
    }

    private static async Task<string> CopyAndComputeHashAsync(Stream source, Stream destination)
    {
        using var sha = SHA256.Create();
        byte[] buffer = new byte[81920];
        int read = 0;

        while (true)
        {
            read = await source.ReadAsync(buffer, 0, buffer.Length);
            if (read == 0)
            {
                break;
            }

            await destination.WriteAsync(buffer, 0, read);
            sha.TransformBlock(buffer, 0, read, null, 0);
        }

        await destination.FlushAsync();
        Debug.Assert(source.Length == destination.Length);

        sha.TransformFinalBlock(buffer, 0, read);
        byte[] hash = sha.Hash!;
        var builder = new StringBuilder(hash.Length * 2);

        foreach (byte b in hash)
        {
            builder.AppendFormat("{0:X2}", b);
        }

        return builder.ToString();
    }

    private class FileNameBuilder
    {
        private string _directory = "";
        private string _fullpath = "";

        #region Properties from Owner
        public required long StudentId { get; init; }

        public required int Year { get; init; }

        public required string Semester { get; init; }
        #endregion

        #region Properties from Document
        public required DocumentType Type { get; init; }

        public required string Hash { get; init; }

        public required string Extension { get; init; }
        #endregion

        public string Directory
        {
            get
            {
                if (string.IsNullOrEmpty(_directory))
                {
                    _directory = BuildDirectoryPath();
                }

                return _directory;
            }
        }

        public string FullPath
        {
            get
            {
                if (string.IsNullOrEmpty(_fullpath))
                {
                    string name = BuildFileName();
                    _fullpath = Path.Combine(Directory, name);
                }

                return _fullpath;
            }
        }

        private string Owner => StudentId.ToString("00000000");

        public override string ToString()
        {
            return FullPath;
        }

        private string BuildDirectoryPath()
        {
            return Path.Combine(
                App.FileStorageDirectory,
                Year.ToString(),
                Semester,
                Owner
            );
        }

        private string BuildFileName()
        {
            string shortHash = Hash.Substring(0, 8);
            return $"{Owner}_{Type.Id}_{Type.Tag}_{shortHash}{Extension}";
        }
    }
}
