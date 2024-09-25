namespace TECNM.Residencias.Data.Extensions;

using System;

internal static class DateTimeExtensions
{
    private const string ISO8601_LONG_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private const string ISO8601_SHORT_FORMAT = "yyyy-MM-dd";

    public static string ToLongIsoString(this DateTime dt)
    {
        return dt.ToString(ISO8601_LONG_FORMAT);
    }

    public static string ToShortIsoString(this DateTime dt)
    {
        return dt.ToString(ISO8601_SHORT_FORMAT);
    }

    public static string ToLongIsoStringUtc(this DateTime dt)
    {
        return dt.ToUniversalTime().ToLongIsoString();
    }

    public static string ToShortIsoStringUtc(this DateTime dt)
    {
        return dt.ToUniversalTime().ToShortIsoString();
    }
}
