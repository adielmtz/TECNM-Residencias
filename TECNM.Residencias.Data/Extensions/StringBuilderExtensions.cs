namespace TECNM.Residencias.Data.Extensions;

using System.Text;

internal static class StringBuilderExtensions
{
    public static StringBuilder Trim(this StringBuilder sb)
    {
        int start = 0;
        int end = sb.Length;

        while (start != end)
        {
            char c = sb[start];
            if (char.IsWhiteSpace(c))
            {
                start++;
            }
            else
            {
                break;
            }
        }

        while (start != end)
        {
            char c = sb[end - 1];
            if (char.IsWhiteSpace(c))
            {
                end--;
            }
            else
            {
                break;
            }
        }

        sb.Remove(0, start);
        sb.Length = end - start;
        return sb;
    }
}
