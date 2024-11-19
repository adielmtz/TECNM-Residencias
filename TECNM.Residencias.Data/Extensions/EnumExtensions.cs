namespace TECNM.Residencias.Data.Extensions;

using System.Diagnostics;
using TECNM.Residencias.Data.Entities;

/// <summary>
/// Provides extension methods for retrieving localized names for various enums.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Gets the localized name in spanish for a given <see cref="CompanyType"/>.
    /// </summary>
    /// <param name="type">The <see cref="CompanyType"/> value.</param>
    /// <returns>The localized name as string.</returns>
    /// <exception cref="UnreachableException">Thrown when an unsupported or unknown <see cref="CompanyType"/> is provided.</exception>
    public static string GetLocalizedName(this CompanyType type) => type switch
    {
        CompanyType.Public => "Pública",
        CompanyType.Private => "Privada",
        CompanyType.Industrial => "Industrial",
        CompanyType.Services => "Servicios",
        CompanyType.Other => "Otro",
        _ => throw new UnreachableException(),
    };

    /// <summary>
    /// Gets the localized name in spanish for a given <see cref="SkillType"/>.
    /// </summary>
    /// <param name="type">The <see cref="SkillType"/> value.</param>
    /// <returns>The localized name as string.</returns>
    /// <exception cref="UnreachableException">Thrown when an unsupported or unknown <see cref="SkillType"/> is provided.</exception>
    public static string GetLocalizedName(this SkillType type) => type switch
    {
        SkillType.Database => "Base de datos",
        SkillType.Editor => "Entorno de desarrollo o editor",
        SkillType.Language => "Lenguaje de programación",
        SkillType.Methodology => "Metodología de desarrollo",
        _ => throw new UnreachableException(),
    };

    /// <summary>
    /// Gets the localized name in spanish for a given <see cref="Gender"/>.
    /// </summary>
    /// <param name="type">The <see cref="Gender"/> value.</param>
    /// <returns>The localized name as string.</returns>
    /// <exception cref="UnreachableException">Thrown when an unsupported or unknown <see cref="Gender"/> is provided.</exception>
    public static string GetLocalizedName(this Gender gender) => gender switch
    {
        Gender.Male => "Hombre",
        Gender.Female => "Mujer",
        Gender.NonBinary => "No binario",
        _ => throw new UnreachableException(),
    };
}
