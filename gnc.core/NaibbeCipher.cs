using d9.gnc.core.Model;
using d9.gnc.core.Normalizers;
using d9.gnc.core.Properties;
using d9.gnc.core.Respacers;
using d9.gnc.core.TableProviders;
using d9.gnc.core.Types;

namespace d9.gnc.core;
// todo: permit non-encipherable text (e.g. punctuation, digits)
public class NaibbeCipher(ITextNormalizer normalizer, ITextRespacer respacer, ITableProvider tableProvider)
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
    public IEnumerable<RespacedWord> Prepare(string text)
        => respacer.Respace(normalizer.Normalize(text));
    public EncipheredLetter Encipher(RespacedLetter letter)
    {
        (string key, LetterType type) = letter;
        return (tableProvider.NextTable()[key][type], type);
    }
    public EncipheredWord Encipher(RespacedWord word)
        => new(word.Select(Encipher));
    public IEnumerable<EncipheredWord> Encipher(IEnumerable<RespacedWord> text)
    {
        foreach (RespacedWord word in text)
            yield return Encipher(word);
    }
    public async IAsyncEnumerable<EncipheredWord> EncipherAsync(IAsyncEnumerable<RespacedWord> text)
    {
        await foreach (RespacedWord word in text)
            yield return Encipher(word);
    }
}