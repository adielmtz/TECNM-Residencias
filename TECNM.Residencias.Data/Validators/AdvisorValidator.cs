namespace TECNM.Residencias.Data.Validators;

using FluentValidation;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Validators.Common;

public sealed class AdvisorValidator : AbstractValidator<Advisor>
{
    public AdvisorValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(a => a.CompanyId).GreaterThan(0).WithMessage("El asesor debe asignarse a una empresa.");
        RuleFor(a => a.Type).IsInEnum().WithMessage("Seleccione el tipo de asesor.");
        RuleFor(a => a.FirstName).NotEmpty().WithName("Nombre");
        RuleFor(a => a.LastName).NotEmpty().WithName("Apellidos");
        RuleFor(a => a.Email).EmailAddress().When(c => c.Email.Length > 0).WithName("Correo");
        RuleFor(a => a.Phone).Must(DataValidator.BeAPhoneNumber).When(c => c.Phone.Length > 0).WithMessage("Introduzca un número de teléfono válido.");
    }
}
