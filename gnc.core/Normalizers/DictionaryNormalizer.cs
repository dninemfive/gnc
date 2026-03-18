namespace d9.gnc.core.Normalizers;

public class DictionaryNormalizer(params IEnumerable<(char k, char v)> replacements)
    : ITextNormalizer
{
    public string Normalize(string text)
    {
        foreach((char k, char v) in replacements)
            text = text.Replace(k, v);
        return text;
    }
}
