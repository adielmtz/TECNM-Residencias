namespace TECNM.Residencias.Data.Validators;

using FluentValidation;
using TECNM.Residencias.Data.Entities;

public sealed class SpecialtyValidator : AbstractValidator<Specialty>
{
    public SpecialtyValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(it => it.CareerId)
            .GreaterThan(0)
            .WithMessage("La especialidad debe asignarse a una carrera.");

        RuleFor(it => it.Name)
            .NotEmpty()
            .WithName("Nombre de la especialidad");
    }
}
