using Microsoft.Data.Sqlite;
using System;

namespace TECNM.Residencias.Data.Extensions
{
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
}
