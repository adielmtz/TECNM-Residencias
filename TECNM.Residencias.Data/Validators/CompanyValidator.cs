using FluentValidation;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(c => c.Rfc)
                .Length(12, 13)
                .Matches(@"^[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$")
                .When(c => c.Rfc != null)
                .WithMessage("Ingrese un RFC válido.");

            RuleFor(c => c.Type).IsInEnum().WithMessage("Debe seleccionar el giro de la empresa.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("El nombre de la empresa no puede estar vacío.");
            RuleFor(c => c.Email).EmailAddress().When(c => c.Email.Length > 0).WithMessage("Debe introducir una dirección de email válida.");
            RuleFor(c => c.Phone).Must(DataValidator.BeAPhoneNumber).When(c => c.Phone.Length > 0).WithMessage("Debe introducir un número telefónico válido.");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Debe completar la información de dirección.");
            RuleFor(c => c.Locality).NotEmpty().WithMessage("Debe completar la información de dirección.");
            RuleFor(c => c.PostalCode).NotEmpty().WithMessage("Debe completar la información de dirección.");
            RuleFor(c => c.CityId).GreaterThan(0).WithMessage("Debe completar la información de dirección.");
        }
    }
}
