using System;

namespace TECNM.Residencias.Data.Extensions
{
    internal static class DateTimeExtensions
    {
        private const string ISO8601_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public static string ToISOString(this DateTime dt)
        {
            return dt.ToString(ISO8601_FORMAT);
        }

        public static string TOISOStringUTC(this DateTime dt)
        {
            return dt.ToUniversalTime().ToISOString();
        }
    }
}
