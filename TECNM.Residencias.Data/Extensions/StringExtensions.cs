using System.Text;

namespace TECNM.Residencias.Data.Extensions
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Produce un query con carácteres especiales removidos y encapsulado entre comillas dobles.
        /// </summary>
        /// <param name="s">El string para escapar.</param>
        /// <returns>El string escapado y listo para usar en consultas FTS5 de SQLite.</returns>
        public static string ToFtsQuery(this string s)
        {
            var builder = new StringBuilder(s.Length + 2);
            builder.Append('"');

            foreach (char c in s)
            {
                if (c == '"')
                {
                    builder.Append('"');
                }

                builder.Append(c);
            }

            builder.Append('"');
            return builder.ToString();
        }
    }
}
