using System;
using System.Reflection;
using System.Windows.Forms;

namespace TECNM.Residencias.Extensions
{
    internal static class DataGridViewExtensions
    {
        public static void DoubleBuffered(this DataGridView dgv, bool value)
        {
            Type type = typeof(DataGridView);
            PropertyInfo? property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

            if (property != null)
            {
                property.SetValue(dgv, value, null);
            }
        }
    }
}
