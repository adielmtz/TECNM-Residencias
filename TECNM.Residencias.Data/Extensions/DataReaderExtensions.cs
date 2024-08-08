using System;
using System.Data;

namespace TECNM.Residencias.Data.Extensions
{
    internal static class DataReaderExtensions
    {
        public static long? GetNullableInt64(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetInt64(ordinal);
        }

        public static string? GetNullableString(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static T GetEnum<T>(this IDataReader reader, int ordinal) where T : struct
        {
            string value = reader.GetString(ordinal);
            return Enum.Parse<T>(value);
        }
    }
}
