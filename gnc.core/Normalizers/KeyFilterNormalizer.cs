using d9.gnc.core.Extensions;
using d9.gnc.core.TableProviders;
using System.Text;

namespace d9.gnc.core.Normalizers;

public class KeyFilterNormalizer(ITableProvider provider)
    : ITextNormalizer
{
    private IReadOnlySet<char> _keys = provider.Keys.Where(x => x.Length == 1).Select(x => x.First()).ToHashSet();
    public async Task<string> NormalizeAsync(string text)
    {
        StringBuilder result = new();
        foreach(char c in text)
            if (_keys.Contains(c))
                result.Append(c);
        return result.ToString();
    }
}
