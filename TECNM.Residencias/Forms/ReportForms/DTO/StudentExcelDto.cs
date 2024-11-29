namespace TECNM.Residencias.Forms.ReportForms.DTO;

using ClosedXML.Attributes;
using System;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Extensions;

internal sealed class StudentExcelDto
{
    [XLColumn(Header = "N° Control")]
    public required long Id { get; init; }

    [XLColumn(Header = "Nombre")]
    public required string Name { get; init; }

    [XLColumn(Header = "Especialidad")]
    public string SpecialtyName => Specialty.Name;

    [XLColumn(Ignore = true)]
    public required Specialty Specialty { get; init; }

    [XLColumn(Header = "Género")]
    public string GenderName => Gender.GetLocalizedName();

    [XLColumn(Ignore = true)]
    public required Gender Gender { get; init; }

    [XLColumn(Header = "Semestre")]
    public required string Semester { get; init; }

    [XLColumn(Header = "Fecha de inicio")]
    public required DateOnly StartDate { get; init; }

    [XLColumn(Header = "Fecha de término")]
    public required DateOnly EndDate { get; init; }

    [XLColumn(Header = "Proyecto")]
    public required string Project { get; init; }

    [XLColumn(Header = "Empresa")]
    public string CompanyName => Company.Name;

    [XLColumn(Ignore = true)]
    public required Company Company { get; init; }

    [XLColumn(Header = "Asesor interno")]
    public string InternalAdvisorName => InternalAdvisor is null ? "SIN ASIGNAR" : InternalAdvisor.ToString();

    [XLColumn(Ignore = true)]
    public required Advisor? InternalAdvisor { get; init; }

    [XLColumn(Header = "Asesor externo")]
    public string ExternalAdvisorName => ExternalAdvisor is null ? "SIN ASIGNAR" : ExternalAdvisor.ToString();

    [XLColumn(Ignore = true)]
    public required Advisor? ExternalAdvisor { get; init; }

    [XLColumn(Header = "Revisor")]
    public string ReviewerAdvisorName => ReviewerAdvisor is null ? "SIN ASIGNAR" : ReviewerAdvisor.ToString();

    [XLColumn(Ignore = true)]
    public required Advisor? ReviewerAdvisor { get; init; }

    [XLColumn(Header = "Expediente cerrado")]
    public required string Closed { get; init; }
}
