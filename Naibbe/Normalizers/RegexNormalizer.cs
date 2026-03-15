using System.Text;
using System.Text.RegularExpressions;

namespace Naibbe.Normalizers;

public class RegexNormalizer(Regex regex, string replacement = "")
    : ITextNormalizer
{
    public string Normalize(string text)
        => regex.Replace(text, replacement);
}
