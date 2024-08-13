using FluentValidation;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(s => s.SpecialtyId).GreaterThan(0).WithMessage("Debe asignar una carrera y especialidad.");
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("El campo de nombre no puede estar vacío.");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("El campo de apellidos no puede estar vacío.");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Debe introducir una dirección de email válida.");
            RuleFor(s => s.Phone).Must(DataValidator.BeAPhoneNumber).When(c => c.Phone.Length > 0).WithMessage("Debe introducir un número telefónico válido.");
            RuleFor(s => s.Gender).IsInEnum();
            RuleFor(s => s.EndDate).GreaterThan(s => s.StartDate).WithMessage("La fecha de finalización debe ser después de la fecha de inicio.");
            RuleFor(s => s.CompanyId).GreaterThan(0).WithMessage("Debe asignar una empresa para la residencia.");
        }
    }
}
