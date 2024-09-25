namespace TECNM.Residencias.Data.Validators;

using FluentValidation;
using TECNM.Residencias.Data.Entities;

public sealed class CareerValidator : AbstractValidator<Career>
{
    public CareerValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(c => c.Name).NotEmpty().WithName("Nombre de la carrera");
    }
}
