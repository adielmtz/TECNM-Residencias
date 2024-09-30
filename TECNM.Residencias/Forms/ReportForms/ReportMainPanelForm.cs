namespace TECNM.Residencias.Forms.ReportForms;

using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Entities.DTO;

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
        IReadOnlyList<StudentFullDetailsDto> students = FetchStudentData(context, year, semester);
        GenerateGeneralCsvReport(outputDirectory, students);

        Statistics stats = CollectStatistics(students);
        PlotGenderCountImage(stats, outputDirectory);
        PlotCompanyTypeCountImage(stats, outputDirectory);
        PlotSpecialtyCountImage(stats, outputDirectory);
        PlotBarChartCountImage(stats, outputDirectory, ExtraType.Database, "Gestores de bases de datos");
        PlotBarChartCountImage(stats, outputDirectory, ExtraType.Editor, "Editores de texto");
        PlotBarChartCountImage(stats, outputDirectory, ExtraType.Language, "Lenguajes de programación");
        PlotBarChartCountImage(stats, outputDirectory, ExtraType.Methodology, "Metodologías de desarrollo");

        MessageBox.Show("Reportes generados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private IReadOnlyList<StudentFullDetailsDto> FetchStudentData(AppDbContext context, int year, string? semester)
    {
        List<StudentFullDetailsDto> result = [];
        var specialtyCache = new Dictionary<long, Specialty>();
        var companyCache = new Dictionary<long, Company>();
        var advisorCache = new Dictionary<long, Advisor>();

        foreach (Student student in context.Students.EnumerateStudents(year, semester))
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

            foreach (long? advisorId in new long?[] { student.InternalAdvisorId, student.ReviewerAdvisorId, student.ExternalAdvisorId })
            {
                if (advisorId == null)
                {
                    continue;
                }

                long rowid = (long) advisorId;
                if (!advisorCache.TryGetValue(rowid, out Advisor? advisor))
                {
                    advisorCache[rowid] = advisor!;
                }
            }

            var dto = new StudentFullDetailsDto
            {
                Id              = student.Id,
                Specialty       = specialty!,
                FirstName       = student.FirstName,
                LastName        = student.LastName,
                Email           = student.Email,
                Phone           = student.Phone,
                Gender          = student.Gender,
                Semester        = student.Semester,
                StartDate       = student.StartDate,
                EndDate         = student.EndDate,
                Project         = student.Project,
                InternalAdvisor = advisorCache[student.InternalAdvisorId ?? 0],
                ExternalAdvisor = advisorCache[student.ExternalAdvisorId ?? 0],
                ReviewerAdvisor = advisorCache[student.ReviewerAdvisorId ?? 0],
                Company         = company!,
                Department      = student.Department,
                Schedule        = student.Schedule,
                Notes           = student.Notes,
                IsClosed        = student.IsClosed,
                UpdatedOn       = student.UpdatedOn,
                CreatedOn       = student.CreatedOn,
                Extras          = context.Extras.EnumerateExtras(student.Id).ToList(),
            };

            result.Add(dto);
        }

        return result;
    }

    private void GenerateGeneralCsvReport(string outputDirectory, IReadOnlyList<StudentFullDetailsDto> studentList)
    {
        string filename = Path.Combine(outputDirectory, "[Reporte] Residentes.csv");
        using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        using var writer = new StreamWriter(stream, Encoding.UTF8);

        // Write CSV headers
        writer.WriteLine("\"N. Control\",\"Nombre\",\"Especialidad\",\"Empresa registrada en el SII\",\"Sector empresarial\",\"Proyecto\",\"Lenguaje(s) de programación utilizados\",\"Bases de datos utilizadas\",\"Entornos de desarrollo utilizados\",\"Metodologías de desarrollo\"");

        foreach (var student in studentList)
        {
            writer.Write("{0},", student.Id);
            writer.Write("\"{0}\",", $"{student.FirstName} {student.LastName}");
            writer.Write("\"{0}\",", student.Specialty.Name);
            writer.Write("\"{0}\",", student.Company.Name);
            writer.Write("\"{0}\",", student.Company.Type);
            writer.Write("\"{0}\",", student.Project);
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.Type == ExtraType.Language).Select(it => it.Value)));
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.Type == ExtraType.Database).Select(it => it.Value)));
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.Type == ExtraType.Editor).Select(it => it.Value)));
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.Type == ExtraType.Methodology).Select(it => it.Value)));
            writer.WriteLine();
        }
    }

    private Statistics CollectStatistics(IReadOnlyList<StudentFullDetailsDto> students)
    {
        var stats = new Statistics();
        foreach (var s in students)
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

            switch (s.Company.Type)
            {
                case CompanyType.Public:
                    stats.CompanyTypePublicCount++;
                    break;
                case CompanyType.Private:
                    stats.CompanyTypePrivateCount++;
                    break;
                case CompanyType.Industrial:
                    stats.CompanyTypeIndustrialCount++;
                    break;
            }

            foreach (Extra extra in s.Extras)
            {
                if (!stats.ExtraStats.ContainsKey(extra))
                {
                    stats.ExtraStats[extra] = 0;
                }

                stats.ExtraStats[extra]++;
            }

            SpecialtyStatistics? specialtyStats;
            if (!stats.SpecialtyStats.TryGetValue(s.Specialty.Id, out specialtyStats))
            {
                specialtyStats = new SpecialtyStatistics
                {
                    Specialty = s.Specialty,
                    Count = 0,
                };

                stats.SpecialtyStats[s.Specialty.Id] = specialtyStats;
            }

            specialtyStats!.Count++;
        }

        return stats;
    }

    private void PlotGenderCountImage(Statistics stats, string directory)
    {
        var plot = new Plot();
        var pie = plot.Add.Pie(new double[]
        {
            stats.GenderMaleCount,
            stats.GenderFemaleCount,
            stats.GenderOtherCount,
        });

        pie.Slices[0].Label = $"Hombres {stats.GenderMalePercentage:0}%";
        pie.Slices[1].Label = $"Mujeres {stats.GenderFemalePercentage:0}%";
        pie.Slices[2].Label = $"Otros {stats.GenderOtherPercentage:0}%";

        pie.ExplodeFraction = 0;
        pie.ShowSliceLabels = true;

        plot.Title("Residentes por género.");
        plot.ShowLegend();
        plot.HideAxesAndGrid();
        plot.SavePng(
            Path.Combine(directory, "[Gráfico] Residentes por género.png"),
            854,
            480
        );
    }

    private void PlotSpecialtyCountImage(Statistics stats, string directory)
    {
        List<PieSlice> slices = [];
        IPalette palette = new ScottPlot.Palettes.Category10();

        int index = 0;
        foreach (SpecialtyStatistics specialtyStatistics in stats.SpecialtyStats.Values)
        {
            Specialty specialty = specialtyStatistics.Specialty;

            var slice = new PieSlice
            {
                Label = $"{specialty.Name} ({specialtyStatistics.Count})",
                Value = specialtyStatistics.Count,
                FillColor = palette.GetColor(index),
            };

            slices.Add(slice);
            index++;
        }

        var plot = new Plot();
        var pie = plot.Add.Pie(slices);

        pie.ExplodeFraction = 0;
        pie.ShowSliceLabels = true;

        plot.Title("Conteo por especialidad.");
        plot.ShowLegend();
        plot.HideAxesAndGrid();
        plot.SavePng(
            Path.Combine(directory, "[Gráfico] Conteo por especialidad.png"),
            1280,
            720
        );
    }

    private void PlotCompanyTypeCountImage(Statistics stats, string directory)
    {
        var plot = new Plot();
        var pie = plot.Add.Pie(new double[]
        {
            stats.CompanyTypePublicPercentage,
            stats.CompanyTypePrivatePercentage,
            stats.CompanyTypeIndustrialPercentage,
        });

        pie.Slices[0].Label = $"Pública {stats.CompanyTypePublicPercentage:0}%";
        pie.Slices[1].Label = $"Privada {stats.CompanyTypePrivatePercentage:0}%";
        pie.Slices[2].Label = $"Industrial {stats.CompanyTypeIndustrialPercentage:0}%";

        pie.ExplodeFraction = 0;
        pie.ShowSliceLabels = true;

        plot.Title("Residentes por tipo de empresa.");
        plot.ShowLegend();
        plot.HideAxesAndGrid();
        plot.SavePng(
            Path.Combine(directory, "[Gráfico] Giros empresariales.png"),
            854,
            480
        );
    }

    private void PlotBarChartCountImage(Statistics stats, string directory, ExtraType type, string title)
    {
        IEnumerable<KeyValuePair<Extra, int>> items = stats.ExtraStats.Where(it => it.Key.Type == type);
        List<Tick> ticks = [];
        var plot = new Plot();
        double pos = 1.0;

        foreach (KeyValuePair<Extra, int> kvp in items)
        {
            string label = kvp.Key.Value;
            double value = kvp.Value;

            var bar = plot.Add.Bar(position: pos, value: value);
            bar.LegendText = $"({value:0}) {label}";

            ticks.Add(new Tick(pos, label));
            pos++;
        }

        plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks.ToArray());
        plot.Axes.Bottom.MajorTickStyle.Length = 0;
        plot.Axes.Margins(bottom: 0);

        plot.Title(title);
        plot.SavePng(
            Path.Combine(directory, $"[Gráfico] {title}.png"),
            1280,
            720
        );
    }

    internal sealed class Statistics
    {
        public int GenderMaleCount;
        public int GenderFemaleCount;
        public int GenderOtherCount;

        public int TotalGenderCount => GenderMaleCount + GenderFemaleCount + GenderOtherCount;
        public double GenderMalePercentage => (GenderMaleCount / (double) TotalGenderCount) * 100.0;
        public double GenderFemalePercentage => (GenderFemaleCount / (double) TotalGenderCount) * 100.0;
        public double GenderOtherPercentage => (GenderOtherCount / (double) TotalGenderCount) * 100.0;

        public int CompanyTypePublicCount;
        public int CompanyTypePrivateCount;
        public int CompanyTypeIndustrialCount;

        public int TotalCompanyTypeCount => CompanyTypePublicCount + CompanyTypePrivateCount + CompanyTypeIndustrialCount;
        public double CompanyTypePublicPercentage => (CompanyTypePublicCount / (double) TotalCompanyTypeCount) * 100.0;
        public double CompanyTypePrivatePercentage => (CompanyTypePrivateCount / (double) TotalCompanyTypeCount) * 100.0;
        public double CompanyTypeIndustrialPercentage => (CompanyTypeIndustrialCount / (double) TotalCompanyTypeCount) * 100.0;

        public Dictionary<long, SpecialtyStatistics> SpecialtyStats = [];
        public Dictionary<Extra, int> ExtraStats = [];
    }

    internal sealed class SpecialtyStatistics
    {
        public required Specialty Specialty { get; init; }
        public int Count { get; set; }
    }
}
