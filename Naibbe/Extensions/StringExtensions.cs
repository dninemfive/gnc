using System.Text;

namespace Naibbe.Extensions;

public static class StringExtensions
{
    public static string SubstringSafe(this string s, int start, int length)
    {
        StringBuilder result = new();
        for (int i = start; i < start + length; i++)
            if (i >= 0 && i < s.Length)
                result.Append(s[i]);
        return result.ToString();
    }
}
