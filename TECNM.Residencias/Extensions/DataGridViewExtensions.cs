namespace TECNM.Residencias.Extensions;

using System;
using System.Reflection;
using System.Windows.Forms;

internal static class DataGridViewExtensions
{
    public static void DoubleBuffered(this DataGridView dgv, bool value)
    {
        Type type = typeof(DataGridView);
        PropertyInfo? property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        property?.SetValue(dgv, value, null);
    }

    public static void ResetSort(this DataGridView dgv)
    {
        if (dgv.SortedColumn is DataGridViewColumn column)
        {
            column.HeaderCell.SortGlyphDirection = SortOrder.None;
        }
    }
}
