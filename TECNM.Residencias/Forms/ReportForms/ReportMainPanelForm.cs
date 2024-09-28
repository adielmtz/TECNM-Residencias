namespace TECNM.Residencias.Forms.ReportForms;

using ScottPlot;
using ScottPlot.Colormaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;

public sealed partial class ReportMainPanelForm : Form
{
    public ReportMainPanelForm()
    {
        InitializeComponent();
        Text = $"Generación de reportes | {App.Name}";

        DateTime now = DateTime.Now;
        cb_Semester.SelectedIndex = now.Month >= 1 && now.Month < 7 ? 0 : 1;
    }

    private void ReportMainPanelForm_Load(object sender, EventArgs e)
    {
        for (int i = DateTime.Today.Year; i >= App.MinimumReportYear; i--)
        {
            cb_Year.Items.Add(i);
        }

        cb_Year.SelectedIndex = 0;
    }

    private void GenerateStats_Click(object sender, EventArgs e)
    {
        int year = (int) cb_Year.SelectedItem!;
        string? semester = (string?) cb_Semester.SelectedItem;

        if (cb_Semester.SelectedIndex == 0)
        {
            semester = null;
        }

        string outputDirectory = GetOuputDirectory(year, semester ?? "Todos");
        Directory.CreateDirectory(outputDirectory);

        using var context = new AppDbContext();
        Student[] students = context.Students.EnumerateStudents(year, semester).ToArray();
        GenerateGeneralCsvReport(context, outputDirectory, students);

        Statistics stats = GenerateStatistics(students);

        var plot = new Plot();
        var pie = plot.Add.Pie(new double[]
        {
            stats.GenderMaleCount,
            stats.GenderFemaleCount,
            stats.GenderOtherCount,
        });

        pie.Slices[0].Label = $"Hombres ({stats.GenderMaleCount})";
        pie.Slices[1].Label = $"Mujeres ({stats.GenderFemaleCount})";
        pie.Slices[2].Label = $"Otro ({stats.GenderOtherCount})";

        pie.ExplodeFraction = 0.1;
        pie.ShowSliceLabels = true;

        plot.Title("Conteo de residentes por género.");
        plot.ShowLegend();
        plot.SavePng(
            @"C:\Users\Adiel\Downloads\sample.png",
            600,
            500
        );
    }

    private string GetOuputDirectory(int year, string semester)
    {
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return Path.Combine(
            documents,
            "TECNM Reportes",
            $"[{year} {semester}] {DateTime.Now:yyyy-MM-dd HH.mm.ss}"
        );
    }

    private void GenerateGeneralCsvReport(AppDbContext context, string outputDirectory, Student[] students)
    {
        string filename = Path.Combine(outputDirectory, "reporte-residentes.csv");
        using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        using var writer = new StreamWriter(stream, Encoding.UTF8);

        // Write CSV headers
        writer.WriteLine("\"N. Control\",\"Nombre\",\"Especialidad\",\"Empresa registrada en el SII\",\"Sector empresarial\",\"Proyecto\",\"Lenguaje(s) de programación utilizados\",\"Bases de datos utilizadas\",\"Entornos de desarrollo utilizados\",\"Metodologías de desarrollo\"");

        var specialtyCache = new Dictionary<long, Specialty>();
        var companyCache = new Dictionary<long, Company>();

        foreach (Student student in students)
        {
            Specialty? specialty;
            if (!specialtyCache.TryGetValue(student.SpecialtyId, out specialty))
            {
                specialty = context.Specialties.GetSpecialtyById(student.SpecialtyId);
                specialtyCache[student.SpecialtyId] = specialty!;
            }

            Company? company;
            if (!companyCache.TryGetValue(student.CompanyId, out company))
            {
                company = context.Companies.GetCompanyById(student.CompanyId);
                companyCache[student.CompanyId] = company!;
            }

            IList<Extra> studentExtras = context.Extras.EnumerateExtras(student.Id).ToList();
            string[] programmingLanguages = studentExtras.Where(extra => extra.Type == ExtraType.Language).Select(extra => extra.Value).ToArray();
            string[] databaseEngines = studentExtras.Where(extra => extra.Type == ExtraType.Database).Select(extra => extra.Value).ToArray();
            string[] ideNames = studentExtras.Where(extra => extra.Type == ExtraType.Editor).Select(extra => extra.Value).ToArray();
            string[] methodologies = studentExtras.Where(extra => extra.Type == ExtraType.Methodology).Select(extra => extra.Value).ToArray();

            writer.Write("{0},", student.Id);
            writer.Write("\"{0}\",", $"{student.FirstName} {student.LastName}");
            writer.Write("\"{0}\",", specialty!.Name);
            writer.Write("\"{0}\",", company!.Name);
            writer.Write("\"{0}\",", company!.Type);
            writer.Write("\"{0}\",", student.Project);
            writer.Write("\"{0}\",", string.Join(", ", programmingLanguages));
            writer.Write("\"{0}\",", string.Join(", ", databaseEngines));
            writer.Write("\"{0}\",", string.Join(", ", ideNames));
            writer.Write("\"{0}\",", string.Join(", ", methodologies));
            writer.WriteLine();
        }
    }

    private Statistics GenerateStatistics(Student[] students)
    {
        var stats = new Statistics();
        foreach (Student s in students)
        {
            switch (s.Gender)
            {
                case Gender.Male:
                    stats.GenderMaleCount++;
                    break;
                case Gender.Female:
                    stats.GenderFemaleCount++;
                    break;
                case Gender.Other:
                    stats.GenderOtherCount++;
                    break;
            }
        }

        return stats;
    }

    internal class Statistics
    {
        public int GenderMaleCount;
        public int GenderFemaleCount;
        public int GenderOtherCount;
    }
}
