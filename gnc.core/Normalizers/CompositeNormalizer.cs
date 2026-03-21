namespace d9.gnc.core.Normalizers;

public class CompositeNormalizer(params IEnumerable<ITextNormalizer> normalizers)
    : ITextNormalizer
{
    public async Task<string> NormalizeAsync(string text)
    {
        foreach(ITextNormalizer normalizer in normalizers)
            text = await normalizer.NormalizeAsync(text);
        return text;
    }
}
