using FluentValidation;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class SpecialtyValidator : AbstractValidator<Specialty>
    {
        public SpecialtyValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(s => s.CareerId).GreaterThan(0).WithMessage("La especialidad debe asignarse a una carrera.");
            RuleFor(s => s.Name).NotEmpty().WithName("Nombre de la especialidad");
        }
    }
}
