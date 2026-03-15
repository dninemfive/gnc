using Naibbe.Model;
using Naibbe.Normalizers;
using Naibbe.Respacers;
using Naibbe.TableProviders;

namespace d9.gnc.core;

public class NaibbeCipher(ITextNormalizer normalizer, ITextRespacer respacer, ITableProvider tableProvider, string space = " ")
{
    public static NaibbeCipher MakeDefault(string basePath, int seed = 0xd9)
    {
        TranslationTable alpha   = TranslationTable.LoadCsv(basePath, "alpha");
        TranslationTable beta_1  = TranslationTable.LoadCsv(basePath, "beta_1");
        TranslationTable beta_2  = TranslationTable.LoadCsv(basePath, "beta_2");
        TranslationTable beta_3  = TranslationTable.LoadCsv(basePath, "beta_3");
        TranslationTable gamma_1 = TranslationTable.LoadCsv(basePath, "gamma_1");
        TranslationTable gamma_2 = TranslationTable.LoadCsv(basePath, "gamma_2");

        Random random = new(seed);
        NaibbeCipher result = new(
            new CompositeNormalizer(
                new LowercaseNormalizer(),
                new RegexNormalizer(new("[^a-z]+")),
                new DictionaryNormalizer(('k', 'c'), ('j', 'i'), ('w', 'u'))
            ),
            new SimplifiedRespacer(random),
            new SimpleTableProvider(random,
                (alpha, 5),
                (beta_1, 2), (beta_2, 2), (beta_3, 2),
                (gamma_1, 1), (gamma_2, 1)
            )
        );

        return result;
    }
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