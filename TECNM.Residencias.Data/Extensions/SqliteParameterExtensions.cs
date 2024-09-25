namespace TECNM.Residencias.Data.Extensions;

using Microsoft.Data.Sqlite;
using System;

internal static class SqliteParameterExtensions
{
    public static void SetNullableValue(this SqliteParameter param, object? value)
    {
        if (value == null)
        {
            param.Value = DBNull.Value;
        }
        else
        {
            param.Value = value;
        }
    }
}
