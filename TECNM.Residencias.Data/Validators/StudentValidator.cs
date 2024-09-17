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
            RuleFor(s => s.Id).Must(BeAValidStudentId).WithMessage("El número de control no es correcto.");
            RuleFor(s => s.SpecialtyId).GreaterThan(0).WithMessage("Debe asignar una carrera y especialidad.");
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("El campo de nombre no puede estar vacío.");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("El campo de apellidos no puede estar vacío.");
            RuleFor(s => s.Email).EmailAddress().When(s => s.Email.Length > 0).WithMessage("Debe introducir una dirección de email válida.");
            RuleFor(s => s.Phone).Must(DataValidator.BeAPhoneNumber).When(s => s.Phone.Length > 0).WithMessage("Debe introducir un número telefónico válido.");
            RuleFor(s => s.Gender).IsInEnum();
            RuleFor(s => s.EndDate).GreaterThan(s => s.StartDate).WithMessage("La fecha de finalización debe ser después de la fecha de inicio.");
            RuleFor(s => s.Project).NotEmpty().WithMessage("El campo de nombre de proyecto no puede estar vacío.");
            RuleFor(s => s.CompanyId).GreaterThan(0).WithMessage("Debe asignar una empresa para la residencia.");
            RuleFor(s => s.Semester).NotEmpty().WithMessage("Debe seleccionar el semestre.");
            RuleFor(s => s.EndDate).GreaterThan(s => s.StartDate).WithMessage("La fecha de cierre debe ser después de la fecha de inicio.");
        }

        private bool BeAValidStudentId(long id)
        {
            return Regex.IsMatch(id.ToString(), @"\d{2}07\d{4}");
        }
    }
}
