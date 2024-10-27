namespace TECNM.Residencias.Forms.ReportForms;

using ScottPlot;
using ScottPlot.TickGenerators;
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
        cb_Semester.SelectedIndex = now.Month >= 1 && now.Month <= 7 ? 0 : 1;
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
        Enabled = false;
        int year = (int) cb_Year.SelectedItem!;
        string? semester = (string?) cb_Semester.SelectedItem;

        if (cb_Semester.SelectedIndex == 0)
        {
            semester = null;
        }

        string rootDirectory = GetOuputDirectory(year, semester ?? "Todos");
        string chartDirectory = Path.Combine(rootDirectory, "Gráficas");
        string internalAdvisorDirectory = Path.Combine(rootDirectory, "Reportes de asesor interno");
        string externalAdvisorDirectory = Path.Combine(rootDirectory, "Reportes de asesor externo");
        string reviewerAdvisorDirectory = Path.Combine(rootDirectory, "Reportes de revisor");
        Directory.CreateDirectory(rootDirectory);
        Directory.CreateDirectory(chartDirectory);
        Directory.CreateDirectory(internalAdvisorDirectory);
        Directory.CreateDirectory(externalAdvisorDirectory);
        Directory.CreateDirectory(reviewerAdvisorDirectory);

        using var context = new AppDbContext();
        IReadOnlyList<StudentFullDetailsDto> students = FetchStudentData(context, year, semester);
        GenerateGeneralCsvReport(rootDirectory, students);
        var internalGrouped = GenerateInternalAdvisorCsvReport(internalAdvisorDirectory, students);
        var externalGrouped = GenerateExternalAdvisorCsvReport(externalAdvisorDirectory, students);
        var reviewerGrouped = GenerateReviewerAdvisorCsvReport(reviewerAdvisorDirectory, students);

        Statistics stats = CollectStatistics(students);
        PlotGenderCountImage(stats, chartDirectory);
        PlotCompanyTypeCountImage(stats, chartDirectory);
        PlotSpecialtyCountImage(stats, chartDirectory);
        PlotAdvisorStudentCountImage(internalGrouped, chartDirectory, "Conteo residentes por asesor interno");
        PlotAdvisorStudentCountImage(externalGrouped, chartDirectory, "Conteo residentes por asesor externo");
        PlotAdvisorStudentCountImage(reviewerGrouped, chartDirectory, "Conteo residentes por revisor");

        PlotBarChartCountImage(stats, chartDirectory, 1, "Gestores de bases de datos");
        PlotBarChartCountImage(stats, chartDirectory, 2, "Editores de texto");
        PlotBarChartCountImage(stats, chartDirectory, 3, "Lenguajes de programación");
        PlotBarChartCountImage(stats, chartDirectory, 4, "Metodologías de desarrollo");

        MessageBox.Show("Reportes generados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        if (chk_OpenDirectory.Checked)
        {
            var info = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = rootDirectory,
            };

            Process.Start(info);
        }

        Close();
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
                    advisor = context.Advisors.GetAdvisorById(rowid);
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
                Gender          = context.Genders.GetGenderById(student.GenderId)!,
                Semester        = student.Semester,
                StartDate       = student.StartDate,
                EndDate         = student.EndDate,
                Project         = student.Project,
                InternalAdvisor = student.InternalAdvisorId == null ? null : advisorCache[(long) student.InternalAdvisorId],
                ExternalAdvisor = student.ExternalAdvisorId == null ? null : advisorCache[(long) student.ExternalAdvisorId],
                ReviewerAdvisor = student.ReviewerAdvisorId == null ? null : advisorCache[(long) student.ReviewerAdvisorId],
                Company         = company!,
                Section         = student.Section,
                Schedule        = student.Schedule,
                Notes           = student.Notes,
                Closed          = student.Closed,
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
            writer.Write("\"{0}\",", $"{student.FirstName} {student.LastName}".Replace("\"", "\"\""));
            writer.Write("\"{0}\",", student.Specialty.Name.Replace("\"", "\"\""));
            writer.Write("\"{0}\",", student.Company.Name.Replace("\"", "\"\""));
            writer.Write("\"{0}\",", student.Company.Name.Replace("\"", "\"\""));
            writer.Write("\"{0}\",", student.Project.Replace("\"", "\"\""));
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.TypeId == 1).Select(it => it.Value)));
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.TypeId == 2).Select(it => it.Value)));
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.TypeId == 3).Select(it => it.Value)));
            writer.Write("\"{0}\",", string.Join(", ", student.Extras.Where(it => it.TypeId == 4).Select(it => it.Value)));
            writer.WriteLine();
        }
    }

    private Dictionary<Advisor, IList<StudentFullDetailsDto>> GenerateInternalAdvisorCsvReport(string outputDirectory, IReadOnlyList<StudentFullDetailsDto> studentList)
    {
        Dictionary<Advisor, IList<StudentFullDetailsDto>> groupedByAdvisor = new(studentList.Count);
        foreach (StudentFullDetailsDto student in studentList)
        {
            if (student.InternalAdvisor is null)
            {
                continue;
            }

            IList<StudentFullDetailsDto>? list;
            if (!groupedByAdvisor.TryGetValue(student.InternalAdvisor, out list))
            {
                list = new List<StudentFullDetailsDto>();
                groupedByAdvisor[student.InternalAdvisor] = list;
            }

            list.Add(student);
        }

        foreach (KeyValuePair<Advisor, IList<StudentFullDetailsDto>> kvp in groupedByAdvisor)
        {
            Advisor advisor = kvp.Key;
            IList<StudentFullDetailsDto> students = kvp.Value;

            string filename = Path.Combine(outputDirectory, $"[Reporte] RESIDENTES {advisor.FirstName} {advisor.LastName}.csv");
            using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream, Encoding.UTF8);

            // Write CSV headers
            writer.WriteLine("\"N. Control\",\"Nombre\",\"Especialidad\",\"Empresa\",\"Proyecto\"");

            foreach (var student in students)
            {
                writer.Write("{0},", student.Id);
                writer.Write("\"{0}\",", $"{student.FirstName} {student.LastName}".Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Specialty.Name.Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Company.Name.Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Project.Replace("\"", "\"\""));
                writer.WriteLine();
            }
        }

        return groupedByAdvisor;
    }

    private Dictionary<Advisor, IList<StudentFullDetailsDto>> GenerateReviewerAdvisorCsvReport(string outputDirectory, IReadOnlyList<StudentFullDetailsDto> studentList)
    {
        Dictionary<Advisor, IList<StudentFullDetailsDto>> groupedByAdvisor = new(studentList.Count);
        foreach (StudentFullDetailsDto student in studentList)
        {
            if (student.ReviewerAdvisor is null)
            {
                continue;
            }

            IList<StudentFullDetailsDto>? list;
            if (!groupedByAdvisor.TryGetValue(student.ReviewerAdvisor, out list))
            {
                list = new List<StudentFullDetailsDto>();
                groupedByAdvisor[student.ReviewerAdvisor] = list;
            }

            list.Add(student);
        }

        foreach (KeyValuePair<Advisor, IList<StudentFullDetailsDto>> kvp in groupedByAdvisor)
        {
            Advisor advisor = kvp.Key;
            IList<StudentFullDetailsDto> students = kvp.Value;

            string filename = Path.Combine(outputDirectory, $"[Reporte] RESIDENTES {advisor.FirstName} {advisor.LastName}.csv");
            using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream, Encoding.UTF8);

            // Write CSV headers
            writer.WriteLine("\"N. Control\",\"Nombre\",\"Especialidad\",\"Empresa\",\"Proyecto\"");

            foreach (var student in students)
            {
                writer.Write("{0},", student.Id);
                writer.Write("\"{0}\",", $"{student.FirstName} {student.LastName}".Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Specialty.Name.Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Company.Name.Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Project.Replace("\"", "\"\""));
                writer.WriteLine();
            }
        }

        return groupedByAdvisor;
    }

    private Dictionary<Advisor, IList<StudentFullDetailsDto>> GenerateExternalAdvisorCsvReport(string outputDirectory, IReadOnlyList<StudentFullDetailsDto> studentList)
    {
        Dictionary<Advisor, IList<StudentFullDetailsDto>> groupedByAdvisor = new(studentList.Count);
        foreach (StudentFullDetailsDto student in studentList)
        {
            if (student.ExternalAdvisor is null)
            {
                continue;
            }

            IList<StudentFullDetailsDto>? list;
            if (!groupedByAdvisor.TryGetValue(student.ExternalAdvisor, out list))
            {
                list = new List<StudentFullDetailsDto>();
                groupedByAdvisor[student.ExternalAdvisor] = list;
            }

            list.Add(student);
        }

        foreach (KeyValuePair<Advisor, IList<StudentFullDetailsDto>> kvp in groupedByAdvisor)
        {
            Advisor advisor = kvp.Key;
            IList<StudentFullDetailsDto> students = kvp.Value;

            string filename = Path.Combine(outputDirectory, $"[Reporte] RESIDENTES {advisor.FirstName} {advisor.LastName}.csv");
            using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream, Encoding.UTF8);

            // Write CSV headers
            writer.WriteLine("\"N. Control\",\"Nombre\",\"Especialidad\",\"Empresa\",\"Proyecto\"");

            foreach (var student in students)
            {
                writer.Write("{0},", student.Id);
                writer.Write("\"{0}\",", $"{student.FirstName} {student.LastName}".Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Specialty.Name.Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Company.Name.Replace("\"", "\"\""));
                writer.Write("\"{0}\",", student.Project.Replace("\"", "\"\""));
                writer.WriteLine();
            }
        }

        return groupedByAdvisor;
    }

    private Statistics CollectStatistics(IReadOnlyList<StudentFullDetailsDto> students)
    {
        var stats = new Statistics();
        foreach (var s in students)
        {
            switch (s.Gender.Id)
            {
                case 1:
                    stats.GenderFemaleCount++;
                    break;
                case 2:
                    stats.GenderMaleCount++;
                    break;
                case 3:
                    stats.GenderOtherCount++;
                    break;
                default:
                    throw new UnreachableException();
            }
        
            switch (s.Company.TypeId)
            {
                case 1:
                    stats.CompanyTypePublicCount++;
                    break;
                case 2:
                    stats.CompanyTypePrivateCount++;
                    break;
                case 3:
                    stats.CompanyTypeIndustrialCount++;
                    break;
                case 4:
                    stats.CompanyTypeServicesCount++;
                    break;
                case 5:
                    stats.CompanyTypeOtherCount++;
                    break;
                default:
                    throw new UnreachableException();
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
        //pie.ShowSliceLabels = true;

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
        //pie.ShowSliceLabels = true;

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
            stats.CompanyTypeServicesPercentage,
            stats.CompanyTypeOtherPercentage,
        });

        pie.Slices[0].Label = $"Pública {stats.CompanyTypePublicPercentage:0}%";
        pie.Slices[1].Label = $"Privada {stats.CompanyTypePrivatePercentage:0}%";
        pie.Slices[2].Label = $"Industrial {stats.CompanyTypeIndustrialPercentage:0}%";
        pie.Slices[3].Label = $"Servicios {stats.CompanyTypeServicesPercentage:0}%";
        pie.Slices[4].Label = $"Otro {stats.CompanyTypeOtherPercentage:0}%";

        pie.ExplodeFraction = 0;
        //pie.ShowSliceLabels = true;

        plot.Title("Residentes por tipo de empresa.");
        plot.ShowLegend();
        plot.HideAxesAndGrid();
        plot.SavePng(
            Path.Combine(directory, "[Gráfico] Giros empresariales.png"),
            854,
            480
        );
    }

    private void PlotBarChartCountImage(Statistics stats, string directory, long type, string title)
    {
        IEnumerable<KeyValuePair<Extra, int>> items = stats.ExtraStats.Where(it => it.Key.TypeId == type);
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

        plot.Axes.Bottom.TickGenerator = new NumericManual(ticks.ToArray());
        plot.Axes.Bottom.MajorTickStyle.Length = 0;
        plot.Axes.Margins(bottom: 0);

        plot.Title(title);
        plot.SavePng(
            Path.Combine(directory, $"[Gráfico] {title}.png"),
            1280,
            720
        );
    }

    private void PlotAdvisorStudentCountImage(Dictionary<Advisor, IList<StudentFullDetailsDto>> grouped, string directory, string title)
    {
        List<Tick> ticks = [];
        var plot = new Plot();
        double pos = 1.0;

        foreach (var kvp in grouped)
        {
            string label = $"{kvp.Key.FirstName} {kvp.Key.LastName}";
            double value = kvp.Value.Count;

            var bar = plot.Add.Bar(position: pos, value: value);
            bar.LegendText = $"({value:0}) {label}";
            bar.Horizontal = true;

            ticks.Add(new Tick(pos, label));
            pos++;
        }

        plot.Axes.Left.TickGenerator = new NumericManual(ticks.ToArray());
        plot.Axes.Left.MajorTickStyle.Length = 0;
        plot.Axes.Margins(left: 0);

        plot.Title(title);
        plot.ShowLegend(alignment: Alignment.UpperRight);
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
        public int CompanyTypeServicesCount;
        public int CompanyTypeOtherCount;

        public int TotalCompanyTypeCount => CompanyTypePublicCount + CompanyTypePrivateCount + CompanyTypeIndustrialCount + CompanyTypeServicesCount + CompanyTypeOtherCount;
        public double CompanyTypePublicPercentage => (CompanyTypePublicCount / (double) TotalCompanyTypeCount) * 100.0;
        public double CompanyTypePrivatePercentage => (CompanyTypePrivateCount / (double) TotalCompanyTypeCount) * 100.0;
        public double CompanyTypeIndustrialPercentage => (CompanyTypeIndustrialCount / (double) TotalCompanyTypeCount) * 100.0;
        public double CompanyTypeServicesPercentage => (CompanyTypeServicesCount / (double) TotalCompanyTypeCount) * 100.0;
        public double CompanyTypeOtherPercentage => (CompanyTypeOtherCount / (double) TotalCompanyTypeCount) * 100.0;

        public Dictionary<long, SpecialtyStatistics> SpecialtyStats = [];
        public Dictionary<Extra, int> ExtraStats = [];
    }

    internal sealed class SpecialtyStatistics
    {
        public required Specialty Specialty { get; init; }
        public int Count { get; set; }
    }
}
