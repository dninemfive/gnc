namespace d9.gnc.core.Normalizers;

public class DictionaryNormalizer(params IEnumerable<(char k, char v)> replacements)
    : ITextNormalizer
{
    private IReadOnlyDictionary<char, char> _dict = replacements.ToDictionary();
    public async Task<char?> NormalizeAsync(char c)
        => _dict.TryGetValue(c, out char o) ? o : c;
}
