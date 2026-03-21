using System.Globalization;

namespace d9.gnc.core.Normalizers;

public class LowercaseNormalizer(CultureInfo? culture = null)
    : ITextNormalizer
{
    public async Task<string> NormalizeAsync(string s)
        => s.ToLower(culture);
}
