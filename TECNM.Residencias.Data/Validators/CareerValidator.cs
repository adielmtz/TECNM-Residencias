using FluentValidation;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class CareerValidator : AbstractValidator<Career>
    {
        public CareerValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(c => c.Name).NotEmpty().WithName("Nombre de la carrera");
        }
    }
}
