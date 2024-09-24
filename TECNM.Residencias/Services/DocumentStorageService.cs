using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Services
{
    internal static class DocumentStorageService
    {
        public static async Task SaveDocumentAsync(Document document, CancellationToken token = default)
        {
            string outputFileName = Path.Combine(App.TempStorageDirectory, Guid.NewGuid().ToString());

            await using var sourceStream = new FileStream(document.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            await using var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write, FileShare.None);

            long size = sourceStream.Length;
            string hash = await CopyAndComputeHashAsync(sourceStream, outputStream, token);

            string originalName = Path.GetFileName(document.FullPath);
            document.FullPath = outputFileName;
            document.OriginalName = originalName;
            document.Size = size;
            document.Hash = hash;
        }

        public static void DeleteDocument(Document document)
        {
            if (document.FullPath.StartsWith(App.FileStorageDirectory))
            {
                string directory = Path.GetDirectoryName(document.FullPath)!;
                File.Delete(document.FullPath);
                DeleteDirectoryIfEmpty(directory);
            }
        }

        private static async Task<string> CopyAndComputeHashAsync(Stream source, Stream destination, CancellationToken token)
        {
            using var sha = SHA256.Create();
            byte[] buffer = new byte[81920];
            int read = 0;

            while (true)
            {
                read = await source.ReadAsync(buffer, 0, buffer.Length, token);
                if (read == 0)
                {
                    break;
                }

                await destination.WriteAsync(buffer, 0, read, token);
                sha.TransformBlock(buffer, 0, read, null, 0);
            }

            Debug.Assert(source.Length == destination.Length);
            sha.TransformFinalBlock(buffer, 0, read);

            byte[] hash = sha.Hash!;
            var builder = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                builder.AppendFormat("{0:X}", b);
            }

            return builder.ToString();
        }

        private static void DeleteDirectoryIfEmpty(string directory)
        {
            IEnumerable<string> entries = Directory.EnumerateFileSystemEntries(directory);
            if (!entries.Any())
            {
                Directory.Delete(directory);
                Debug.WriteLine("DocumentStorageService::DeleteDirectoryIfEmpty(): Deleted directory: '{0}'", directory);
            }
        }
    }
}
