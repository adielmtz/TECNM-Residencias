namespace TECNM.Residencias.Data.Validators;

using FluentValidation;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

public sealed class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(it => it.Rfc)
            .Length(12, 13)
            .WithName("RFC")
            .Matches(@"^[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$")
            .When(it => it.Rfc is not null)
            .WithMessage("Introduzca un RFC válido.");

        RuleFor(it => it.Type)
            .IsInEnum()
            .WithMessage("Seleccione el tipo de empresa.");

        RuleFor(it => it.Name)
            .NotEmpty()
            .WithName("Nombre de la empresa");

        RuleFor(it => it.Email)
            .EmailAddress()
            .When(it => it.Email.Length > 0)
            .WithName("Correo");

        RuleFor(it => it.Phone)
            .Must(PhoneValidator.BeAPhoneNumber)
            .When(it => it.Phone.Length > 0)
            .WithMessage("Introduzca un número de teléfono válido.");

        RuleFor(it => it.Address)
            .NotEmpty()
            .WithMessage("Introduzca la información de dirección.");

        RuleFor(it => it.Locality)
            .NotEmpty()
            .WithMessage("Introduzca la información de dirección.");

        RuleFor(it => it.PostalCode)
            .NotEmpty()
            .WithMessage("Introduzca la información de dirección.");

        RuleFor(it => it.CityId)
            .GreaterThan(0)
            .WithMessage("Introduzca la información de dirección.");
    }
}
