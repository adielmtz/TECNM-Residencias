using System.Text;

namespace TECNM.Residencias.Data.Extensions
{
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
            foreach (char c in str)
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
