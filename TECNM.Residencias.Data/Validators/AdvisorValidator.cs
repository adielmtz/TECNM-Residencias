using FluentValidation;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class AdvisorValidator : AbstractValidator<Advisor>
    {
        public AdvisorValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(a => a.CompanyId).GreaterThan(0).WithMessage("Debe asignar una empresa a la que pertenece el asesor.");
            RuleFor(a => a.Type).IsInEnum().WithMessage("Debe seleccionar el tipo de asesor.");
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("El campo de nombre no puede estar vacío.");
            RuleFor(a => a.LastName).NotEmpty().WithMessage("El campo de apellidos no puede estar vacío.");
            RuleFor(a => a.Email).EmailAddress().When(c => c.Email.Length > 0).WithMessage("Debe introducir una dirección de email válida.");
            RuleFor(a => a.Phone).Must(DataValidator.BeAPhoneNumber).When(c => c.Phone.Length > 0).WithMessage("Debe introducir un número telefónico válido.");
        }
    }
}
