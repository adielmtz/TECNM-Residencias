namespace TECNM.Residencias.Data.Extensions;

using System.Text;

/// <summary>
/// Provides extension methods for the <see cref="StringBuilder"/> class.
/// </summary>
public static class StringBuilderExtensions
{
    /// <summary>
    /// Trims leading and trailing whitespace characters from the <see cref="StringBuilder"/>.
    /// </summary>
    /// <param name="sb">The <see cref="StringBuilder"/> instance to trim.</param>
    /// <returns>The same <see cref="StringBuilder"/> instance.</returns>
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
