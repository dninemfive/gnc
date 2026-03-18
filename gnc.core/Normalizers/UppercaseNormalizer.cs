using System.Globalization;

namespace d9.gnc.core.Normalizers;

public class UppercaseNormalizer(CultureInfo? culture = null)
    : ITextNormalizer
{
    public string Normalize(string text)
        => text.ToUpper(culture);
}
