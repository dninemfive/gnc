using System.Globalization;

namespace d9.gnc.core.Normalizers;

public class UppercaseNormalizer(CultureInfo? culture = null)
    : ITextNormalizer
{
    public async Task<char?> NormalizeAsync(char c)
        => char.ToLower(c, culture ?? CultureInfo.InvariantCulture);
}
