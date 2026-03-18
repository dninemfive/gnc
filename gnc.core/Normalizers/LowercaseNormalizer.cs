using System.Globalization;

namespace d9.gnc.core.Normalizers;

public class LowercaseNormalizer(CultureInfo? culture = null)
    : ITextNormalizer
{
    public string Normalize(string text)
        => text.ToLower(culture);
}
