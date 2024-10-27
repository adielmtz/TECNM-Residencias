namespace TECNM.Residencias.Data.Extensions;

using System.Text;

/// <summary>
/// Provides extension methods for the <see cref="string"/> class.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string into a format suitable for full-text search queries.
    /// </summary>
    /// <param name="str">The input string to be converted.</param>
    /// <returns>A modified string suitable for full-text search queries.</returns>
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
