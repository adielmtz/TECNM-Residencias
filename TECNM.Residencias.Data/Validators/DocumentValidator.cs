namespace TECNM.Residencias.Data.Validators;

using FluentValidation;
using TECNM.Residencias.Data.Entities;

public sealed class DocumentValidator : AbstractValidator<Document>
{
    public DocumentValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(it => it.StudentId)
            .GreaterThan(0)
            .WithMessage("El documento debe asignarse a un estudiante.");

        RuleFor(it => it.TypeId)
            .GreaterThan(0)
            .WithMessage("Selecciona el tipo de documento.");

        RuleFor(it => it.FullPath)
            .NotEmpty()
            .WithName("Ruta del archivo");

        RuleFor(it => it.OriginalName)
            .NotEmpty()
            .WithName("Nombre original");

        RuleFor(it => it.Size)
            .GreaterThan(0)
            .WithMessage("No se permiten archivos vacíos.");

        RuleFor(it => it.Hash)
            .Length(64)
            .When(it => it.Hash.Length != 0);
    }
}
