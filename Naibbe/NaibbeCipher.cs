using Naibbe.Normalizers;
using Naibbe.Respacers;
using Naibbe.TableProviders;

namespace Naibbe;

public class NaibbeCipher(ITextNormalizer normalizer, ITextRespacer respacer, ITableProvider tableProvider, string space = " ")
{
    public IEnumerable<RespacedLetter> Prepare(string text)
        => respacer.Respace(normalizer.Normalize(text));
    public IEnumerable<string> Encipher(RespacedLetter letter)
    {
        (string key, LetterType type) = letter;
        yield return tableProvider.NextTable()[key][type];
        if (type is LetterType.Unigram or LetterType.Suffix)
            yield return space;
    }
    public IEnumerable<string> Encipher(string text)
    {
        foreach (RespacedLetter letter in Prepare(text))
            foreach (string part in Encipher(letter))
                yield return part;
    }
    public async IAsyncEnumerable<string> EncipherAsync(string text)
    {
        foreach (RespacedLetter letter in Prepare(text))
            foreach (string part in Encipher(text))
                yield return part;
    }
}