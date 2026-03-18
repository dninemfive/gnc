using System.Text.RegularExpressions;

namespace d9.gnc.core.Normalizers;

public class RegexNormalizer(Regex regex, string replacement = "")
    : ITextNormalizer
{
    public string Normalize(string text)
        => regex.Replace(text, replacement);
}
