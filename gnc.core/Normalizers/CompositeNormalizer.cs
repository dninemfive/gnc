namespace d9.gnc.core.Normalizers;

public class CompositeNormalizer(params IEnumerable<ITextNormalizer> normalizers)
    : ITextNormalizer
{
    public IEnumerable<ITextNormalizer> Components => normalizers;
    public async Task<string> NormalizeAsync(string text)
    {
        foreach(ITextNormalizer normalizer in Components)
            text = await normalizer.NormalizeAsync(text);
        return text;
    }
}
