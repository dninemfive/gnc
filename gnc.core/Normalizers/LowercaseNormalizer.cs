using System.Globalization;

namespace Naibbe.Normalizers;

public class LowercaseNormalizer(CultureInfo? culture = null)
    : ITextNormalizer
{
    public string Normalize(string text)
        => text.ToLower(culture);
}
