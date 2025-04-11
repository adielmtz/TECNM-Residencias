namespace TECNM.Residencias.Forms.ReportForms;

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;
using TECNM.Residencias.Forms.ReportForms.DTO;

public sealed partial class ReportMainPanelForm : Form
{
    private readonly Dictionary<long, Company> _companyCache = [];

    public ReportMainPanelForm()
    {
        InitializeComponent();

        var today = DateTime.Today;
        cb_Semester.SelectedIndex = today.Month >= 1 && today.Month < 7 ? 1 : 2;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        using var context = new AppDbContext();
        long? minYear = context.Students.GetMinimumYear();
        var today = DateTime.Today;

        if (!minYear.HasValue)
        {
            minYear = today.Year;
        }

        for (int i = today.Year; i >= minYear; i--)
        {
            cb_Year.Items.Add(i);
        }

        cb_Year.SelectedIndex = 0;

        if (AppSettings.Default.DefaultSemesterFilter >= 0)
        {
            cb_Semester.SelectedIndex = AppSettings.Default.DefaultSemesterFilter;
        }

        chk_OpenDirectory.Checked = AppSettings.Default.MustOpenReportsDirectory;
    }

    private void OpenDirectory_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.Default.MustOpenReportsDirectory = chk_OpenDirectory.Checked;
        AppSettings.Default.Save();
    }

    private sealed class SimpleDataGroup
    {
        public required string Name { get; init; }

        public required int Count { get; init; }
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

        string destinationDirectory = GetOuputDirectory();
        string temporaryExcelFile = GetTemporaryExcelFile();
        Directory.CreateDirectory(destinationDirectory);

        using var context = new AppDbContext();
        List<StudentExcelDto> students = FetchStudentData(context, year, semester);

        using var stream = GetExcelTemplateStream();
        using (var workbook = new XLWorkbook(stream))
        {
            PopulateStudentTable(workbook, students);
            PopulateCompanyTable(workbook, _companyCache.Values.ToList());

            List<SkillCount> skills = FetchStudentSkills(context, students);
            PopulateSkillTable(workbook, skills);

            workbook.SaveAs(temporaryExcelFile);
        }

        string semesterString = semester ?? "Todos";
        File.Copy(
            temporaryExcelFile,
            Path.Combine(
                destinationDirectory,
                $"({year} {semesterString}) Residentes {DateTime.Now:yyyy-MM-dd\\_HH.mm.ss}.xlsx"
            ),
            overwrite: true
        );

        MessageBox.Show("Reportes generados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        if (chk_OpenDirectory.Checked)
        {
            var info = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = destinationDirectory,
            };

            Process.Start(info);
        }

        Close();
    }

    private Stream GetExcelTemplateStream()
    {
        Assembly assembly = typeof(ReportMainPanelForm).Assembly;
        string resource = "TECNM.Residencias.Resources.TemplateDocument.xlsx";
        Stream? stream = assembly.GetManifestResourceStream(resource);
        Trace.Assert(stream is not null, $"Failed to create a stream to embedded resource: {resource}");
        return stream;
    }

    private void PopulateStudentTable(IXLWorkbook workbook, List<StudentExcelDto> students)
    {
        IXLWorksheet sheet = workbook.Worksheet("Residentes");
        IXLTable table = sheet.Table("TablaResidentes");

        if (students.Count > 1)
        {
            table.DataRange.Row(table.RowCount()).InsertRowsBelow(students.Count - 1);
        }

        for (int i = 0; i < students.Count; i++)
        {
            StudentExcelDto dto = students[i];

            sheet.Cell(i + 2, 1).Value = dto.Id;
            sheet.Cell(i + 2, 2).Value = dto.Name;
            sheet.Cell(i + 2, 3).Value = dto.SpecialtyName;
            sheet.Cell(i + 2, 4).Value = dto.GenderName;
            sheet.Cell(i + 2, 5).Value = dto.Semester;
            sheet.Cell(i + 2, 6).Value = dto.StartDate.ToString();
            sheet.Cell(i + 2, 7).Value = dto.EndDate.ToString();
            sheet.Cell(i + 2, 8).Value = dto.Project;
            sheet.Cell(i + 2, 9).Value = dto.CompanyName;
            sheet.Cell(i + 2, 10).Value = dto.InternalAdvisorName;
            sheet.Cell(i + 2, 11).Value = dto.ExternalAdvisorName;
            sheet.Cell(i + 2, 12).Value = dto.ReviewerAdvisorName;
            sheet.Cell(i + 2, 13).Value = dto.Closed;
        }

        table.SetShowAutoFilter(false);
        sheet.Columns().AdjustToContents();
    }

    private void PopulateCompanyTable(IXLWorkbook workbook, List<Company> companies)
    {
        IXLWorksheet sheet = workbook.Worksheet("Empresas");
        IXLTable table = sheet.Table("TablaEmpresas");

        if (companies.Count > 1)
        {
            table.DataRange.Row(table.RowCount()).InsertRowsBelow(companies.Count - 1);
        }

        for (int i = 0; i < companies.Count; i++)
        {
            Company company = companies[i];

            sheet.Cell(i + 2, 1).Value = company.Name;
            sheet.Cell(i + 2, 2).Value = company.Type.GetLocalizedName();
        }

        table.SetShowAutoFilter(false);
        sheet.Columns().AdjustToContents();
    }

    private void PopulateSkillTable(IXLWorkbook workbook, List<SkillCount> skills)
    {
        IXLWorksheet sheet = workbook.Worksheet("Habilidades");
        IXLTable table = sheet.Table("TablaHabilidades");

        if (skills.Count > 1)
        {
            table.DataRange.Row(table.RowCount()).InsertRowsBelow(skills.Count - 1);
        }

        for (int i = 0; i < skills.Count; i++)
        {
            SkillCount stat = skills[i];

            sheet.Cell(i + 2, 1).Value = stat.Skill.Value;
            sheet.Cell(i + 2, 2).Value = stat.Skill.Type.GetLocalizedName();
            sheet.Cell(i + 2, 3).Value = stat.Count;
        }

        table.SetShowAutoFilter(false);
        sheet.Columns().AdjustToContents();
    }

    private string GetOuputDirectory()
    {
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        return Path.Combine(documents, "TECNM Reportes");
    }

    private string GetTemporaryExcelFile()
    {
        return Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.xlsx");
    }

    private List<StudentExcelDto> FetchStudentData(AppDbContext context, int year, string? semester)
    {
        var specialtyCache = new Dictionary<long, Specialty>();
        var advisorCache = new Dictionary<long, Advisor>();
        var result = new List<StudentExcelDto>();

        foreach (Student student in context.Students.EnumerateAll(year, semester))
        {
            Specialty? specialty;
            if (!specialtyCache.TryGetValue(student.SpecialtyId, out specialty))
            {
                specialty = context.Specialties.GetSpecialty(student.SpecialtyId)!;
                specialtyCache[specialty.Id] = specialty;
            }

            Company? company;
            if (!_companyCache.TryGetValue(student.CompanyId, out company))
            {
                company = context.Companies.GetCompany(student.CompanyId)!;
                _companyCache[company.Id] = company;
            }

            Advisor? internalAdvisor = null;
            if (student.InternalAdvisorId.HasValue && !advisorCache.TryGetValue(student.InternalAdvisorId.Value, out internalAdvisor))
            {
                internalAdvisor = context.Advisors.GetAdvisor(student.InternalAdvisorId.Value)!;
                advisorCache[internalAdvisor.Id] = internalAdvisor;
            }

            Advisor? externalAdvisor = null;
            if (student.ExternalAdvisorId.HasValue && !advisorCache.TryGetValue(student.ExternalAdvisorId.Value, out externalAdvisor))
            {
                externalAdvisor = context.Advisors.GetAdvisor(student.ExternalAdvisorId.Value)!;
                advisorCache[externalAdvisor.Id] = externalAdvisor;
            }

            Advisor? reviewerAdvisor = null;
            if (student.ReviewerAdvisorId.HasValue && !advisorCache.TryGetValue(student.ReviewerAdvisorId.Value, out reviewerAdvisor))
            {
                reviewerAdvisor = context.Advisors.GetAdvisor(student.ReviewerAdvisorId.Value)!;
                advisorCache[reviewerAdvisor.Id] = reviewerAdvisor;
            }

            result.Add(new StudentExcelDto
            {
                Id = student.Id,
                Name = $"{student.FirstName} {student.LastName}",
                Specialty = specialty,
                Gender = student.Gender,
                Semester = student.Semester,
                StartDate = student.StartDate,
                EndDate = student.EndDate,
                Project = student.Project,
                Company = company,
                InternalAdvisor = internalAdvisor,
                ExternalAdvisor = externalAdvisor,
                ReviewerAdvisor = reviewerAdvisor,
                Closed = student.Closed ? "Sí" : "No"
            });
        }

        return result;
    }

    private List<SkillCount> FetchStudentSkills(AppDbContext context, List<StudentExcelDto> students)
    {
        var skills = new Dictionary<long, SkillCount>();
        foreach (StudentExcelDto dto in students)
        {
            foreach (Skill skill in context.Skills.EnumerateAll(dto.Id))
            {
                SkillCount? stat;

                if (!skills.TryGetValue(skill.Id, out stat))
                {
                    stat = new SkillCount
                    {
                        Skill = skill,
                        Count = 0,
                    };

                    skills[skill.Id] = stat;
                }

                stat.Count++;
            }
        }

        return skills.Values.OrderBy(s => s.Skill.Type).ToList();
    }

    private class SkillCount
    {
        public required Skill Skill { get; init; }

        public int Count { get; set; }
    }
}
