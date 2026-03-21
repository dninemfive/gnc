namespace d9.gnc.core.Normalizers;

public interface ITextNormalizer
{
    public Task<string> NormalizeAsync(string text);
}
