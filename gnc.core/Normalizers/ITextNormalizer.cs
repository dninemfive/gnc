namespace d9.gnc.core.Normalizers;

public interface ITextNormalizer
{
    public Task<char?> NormalizeAsync(char c);
    public async IAsyncEnumerable<char> NormalizeAsync(string text)
    {
        foreach (char c in text)
            if (await NormalizeAsync(c) is char d)
                yield return d;
    }
}
