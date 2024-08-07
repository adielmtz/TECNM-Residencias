using FluentValidation;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(c => c.Type).IsInEnum().WithMessage("Debe seleccionar el giro de la empresa.");
            RuleFor(c => c.Rfc).NotEmpty().WithMessage("Debe proporcionar el RFC de la empresa.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("El nombre de la empresa no puede estar vacío.");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Debe completar la información de dirección.");
            RuleFor(c => c.Locality).NotEmpty().WithMessage("Debe completar la información de dirección.");
            RuleFor(c => c.PostalCode).NotEmpty().WithMessage("Debe completar la información de dirección.");
            RuleFor(c => c.CityId).GreaterThan(0).WithMessage("Debe completar la información de dirección.");
        }
    }
}