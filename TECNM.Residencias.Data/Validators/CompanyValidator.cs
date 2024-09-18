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
                .WithName("RFC")
                .Matches(@"^[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$")
                .When(c => c.Rfc != null)
                .WithMessage("Introduzca un RFC válido.");

            RuleFor(c => c.Type).IsInEnum().WithMessage("Seleccione el tipo de empresa.");
            RuleFor(c => c.Name).NotEmpty().WithName("Nombre de la empresa");
            RuleFor(c => c.Email).EmailAddress().When(c => c.Email.Length > 0).WithName("Correo");
            RuleFor(c => c.Phone).Must(DataValidator.BeAPhoneNumber).When(c => c.Phone.Length > 0).WithMessage("Introduzca un número de teléfono válido.");
            RuleFor(c => c.Address).NotEmpty().WithName("Introduzca la información de dirección.");
            RuleFor(c => c.Locality).NotEmpty().WithName("Introduzca la información de dirección.");
            RuleFor(c => c.PostalCode).NotEmpty().WithName("Introduzca la información de dirección.");
            RuleFor(c => c.CityId).GreaterThan(0).WithName("Introduzca la información de dirección.");
        }
    }
}
