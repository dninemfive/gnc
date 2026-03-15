using System.Text;
using System.Text.RegularExpressions;

namespace Naibbe.Normalizers;

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
