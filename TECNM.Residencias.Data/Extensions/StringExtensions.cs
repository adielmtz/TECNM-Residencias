namespace TECNM.Residencias.Data.Extensions;

using System.Text;

internal static class StringExtensions
{
    /// <summary>
    /// Produce un query con carácteres especiales removidos y encapsulado entre comillas dobles.
    /// </summary>
    /// <param name="str">El string para escapar.</param>
    /// <returns>El string escapado y listo para usar en consultas FTS5 de SQLite.</returns>
    public static string ToFtsQuery(this string str)
    {
        var builder = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
            {
                c = ' ';
            }

            builder.Append(c);
        }

        return builder.Trim().Append('*').ToString();
    }
}
