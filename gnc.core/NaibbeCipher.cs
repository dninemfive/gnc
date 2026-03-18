using d9.gnc.core.Model;
using d9.gnc.core.Normalizers;
using d9.gnc.core.Properties;
using d9.gnc.core.Respacers;
using d9.gnc.core.TableProviders;

namespace d9.gnc.core;

public class NaibbeCipher(ITextNormalizer normalizer, ITextRespacer respacer, ITableProvider tableProvider, string space = " ")
{
    public static async Task<NaibbeCipher> MakeDefault(string basePath, int seed = 0xd9)
    {
        TranslationTable alpha   = await TranslationTable.ParseCsvAsync(Resources.TranslationTable_Alpha);
        TranslationTable beta_1  = await TranslationTable.ParseCsvAsync(Resources.TranslationTable_Beta1);
        TranslationTable beta_2  = await TranslationTable.ParseCsvAsync(Resources.TranslationTable_Beta2);
        TranslationTable beta_3  = await TranslationTable.ParseCsvAsync(Resources.TranslationTable_Beta3);
        TranslationTable gamma_1 = await TranslationTable.ParseCsvAsync(Resources.TranslationTable_Gamma1);
        TranslationTable gamma_2 = await TranslationTable.ParseCsvAsync(Resources.TranslationTable_Gamma2);

        Random random = new(seed);
        NaibbeCipher result = new(
            new CompositeNormalizer(
                new UppercaseNormalizer(),
                new RegexNormalizer(new("[^A-Z]+")),
                new DictionaryNormalizer(('K', 'C'), ('J', 'I'), ('W', 'U'))
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