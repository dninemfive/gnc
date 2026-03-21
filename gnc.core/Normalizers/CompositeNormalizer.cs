namespace d9.gnc.core.Normalizers;

public class CompositeNormalizer(params IEnumerable<ITextNormalizer> normalizers)
    : ITextNormalizer
{
    public Task<char> NormalizeAsync(char c)
    {

    }
    public string Normalize(string text)
    {
        foreach(ITextNormalizer normalizer in normalizers)
            text = normalizer.Normalize(text);
        return text;
    }
}
