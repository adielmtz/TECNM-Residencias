using FluentValidation;
using System.Text.RegularExpressions;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(s => s.Id).Must(BeAValidStudentId).WithMessage("Introduzca un número de control válido.");
            RuleFor(s => s.SpecialtyId).GreaterThan(0).WithMessage("Seleccione la carrera y la especialidad del residente.");
            RuleFor(s => s.FirstName).NotEmpty().WithName("Nombre");
            RuleFor(s => s.LastName).NotEmpty().WithName("Apellidos");
            RuleFor(s => s.Email).EmailAddress().WithName("Correo");
            RuleFor(s => s.Phone).Must(DataValidator.BeAPhoneNumber).When(s => s.Phone.Length > 0).WithMessage("Introduzca un número de teléfono válido.");
            RuleFor(s => s.Gender).IsInEnum().WithMessage("Seleccione el género del residente.");
            RuleFor(s => s.Project).NotEmpty().WithName("Nombre del proyecto");
            RuleFor(s => s.CompanyId).GreaterThan(0).WithMessage("Asigne una empresa para el proyecto.");
            RuleFor(s => s.Semester).NotEmpty().WithMessage("Seleccione el semestre.");
            RuleFor(s => s.EndDate).GreaterThan(s => s.StartDate).WithMessage("La fecha de terminación debe ser después de la fecha de inicio.");
        }

        private bool BeAValidStudentId(long id)
        {
            return Regex.IsMatch(id.ToString(), @"\d{2}07\d{4}");
        }
    }
}
