using d9.utl;

namespace d9.gnc.core.Normalizers;

public class DictionaryNormalizer(params IEnumerable<(char k, char v)> replacements)
    : ITextNormalizer
{
    // todo: fix the duplicate method in utl
    private IReadOnlyDictionary<char, char> _dict = replacements.Select(x => new KeyValuePair<char, char>(x.k, x.v)).ToDictionary();
    public async Task<string> NormalizeAsync(string s)
        => s.Select(x => _dict.TryGetValue(x, out char c) ?  c : x).Join();
}
