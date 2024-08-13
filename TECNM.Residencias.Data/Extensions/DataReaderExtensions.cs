using System;
using System.Data;
using System.Diagnostics;

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

        public static DateTime GetLocalDateTime(this IDataReader reader, int ordinal)
        {
            Debug.Assert(reader.GetDataTypeName(ordinal) == "TEXT");
            DateTime value = reader.GetDateTime(ordinal);
            return DateTime.SpecifyKind(value, DateTimeKind.Utc).ToLocalTime();
        }

        public static T GetEnum<T>(this IDataReader reader, int ordinal) where T : struct
        {
            Debug.Assert(reader.GetDataTypeName(ordinal) == "TEXT");
            string value = reader.GetString(ordinal);
            return Enum.Parse<T>(value);
        }
    }
}
