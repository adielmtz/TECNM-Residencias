namespace TECNM.Residencias.Data.Validators;

using FluentValidation;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

public sealed class AdvisorValidator : AbstractValidator<Advisor>
{
    public AdvisorValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(it => it.CompanyId)
            .GreaterThan(0)
            .WithMessage("El asesor debe asignarse a una empresa.");

        RuleFor(it => it.FirstName)
            .NotEmpty()
            .WithName("Nombre");

        RuleFor(it => it.LastName)
            .NotEmpty()
            .WithName("Apellidos");

        RuleFor(it => it.Email)
            .EmailAddress()
            .When(it => it.Email.Length > 0)
            .WithName("Correo");

        RuleFor(it => it.Phone)
            .Must(PhoneValidator.BeAPhoneNumber)
            .When(it => it.Phone.Length > 0)
            .WithMessage("Introduzca un número de teléfono válido.");
    }
}
