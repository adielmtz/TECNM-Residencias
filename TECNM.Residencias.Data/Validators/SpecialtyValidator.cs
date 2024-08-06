using FluentValidation;
using TECNM.Residencias.Data.Entities;

namespace TECNM.Residencias.Data.Validators
{
    public sealed class SpecialtyValidator : AbstractValidator<Specialty>
    {
        public SpecialtyValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(s => s.CareerId).GreaterThan(0).WithMessage("Debe asignar una carrera para esta especialidad.");
            RuleFor(s => s.Name).NotEmpty().WithMessage("El nombre de la especialidad no puede estar vacío.");
        }
    }
}
