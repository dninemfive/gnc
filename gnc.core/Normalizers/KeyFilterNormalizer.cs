using d9.gnc.core.Extensions;
using d9.gnc.core.TableProviders;

namespace d9.gnc.core.Normalizers;

public class KeyFilterNormalizer(ITableProvider provider)
    : ITextNormalizer
{
    private IReadOnlySet<string> _keys = provider.Keys;
    public async Task<string> NormalizeAsync(string text)
    {
        foreach (string key in _keys)
            text = text.Replace(key, "");
        return text;
    }
}
