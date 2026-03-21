using System.Globalization;

namespace d9.gnc.core.Normalizers;

public class LowercaseNormalizer(CultureInfo? culture = null)
    : ITextNormalizer
{
    public async Task<char?> NormalizeAsync(char c)
        => char.ToUpper(c, culture ?? CultureInfo.InvariantCulture);
}
