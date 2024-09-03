using System.Diagnostics;
using System.IO;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Services
{
    internal static class DocumentStorageService
    {
        public static void SaveFile(Student student, Document document, string filename)
        {
            Debug.Assert(student.Id > 0);
            document.StudentId = student.Id;

            string yearComponent = student.StartDate.Year.ToString();
            string semesterComponent = student.Semester;
            string extension = Path.GetExtension(filename);
            string targetName = $"{student.Id}_{document.Type}_{document.Hash.Substring(0, 8)}{extension}";

            string targetFile = Path.Combine(App.DocumentArchiveDirectory, yearComponent, semesterComponent, $"{student.Id}", targetName);
            string directory = Path.GetDirectoryName(targetFile)!;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.Copy(filename, targetFile);
            document.FullPath = targetFile;
        }
    }
}
