namespace TECNM.Residencias.Data.Validators;

using FluentValidation;
using System.Text.RegularExpressions;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

public sealed class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(it => it.Id)
            .Must(BeAValidStudentId)
            .WithMessage("Introduzca un número de control válido.");

        RuleFor(it => it.SpecialtyId)
            .GreaterThan(0)
            .WithMessage("Seleccione la carrera y la especialidad del residente.");

        RuleFor(it => it.FirstName)
            .NotEmpty()
            .WithName("Nombre");

        RuleFor(it => it.LastName)
            .NotEmpty()
            .WithName("Apellidos");

        RuleFor(it => it.Email)
            .EmailAddress()
            .WithName("Correo");

        RuleFor(it => it.Phone)
            .Must(PhoneValidator.BeAPhoneNumber)
            .When(it => it.Phone.Length > 0)
            .WithMessage("Introduzca un número de teléfono válido.");

        RuleFor(it => it.Gender)
            .IsInEnum()
            .WithMessage("Seleccione el género del residente.");

        RuleFor(it => it.Project)
            .NotEmpty()
            .WithName("Nombre del proyecto");

        RuleFor(it => it.CompanyId)
            .GreaterThan(0)
            .WithMessage("Asigne una empresa para el proyecto.");

        RuleFor(it => it.Semester)
            .NotEmpty()
            .WithMessage("Seleccione el semestre.");

        RuleFor(it => it.EndDate)
            .GreaterThan(it => it.StartDate)
            .WithMessage("La fecha de terminación debe ser después de la fecha de inicio.");
    }

    private bool BeAValidStudentId(long id)
    {
        return Regex.IsMatch(id.ToString(), @"\d{2}07\d{4}");
    }
}
