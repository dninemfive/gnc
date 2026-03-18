namespace d9.gnc.core.Model;

public class TranslationTableRow
{
    public required string Letter { get; init; }
    public required string Unigram { get; init; }
    public required string Prefix { get; init; }
    public required string Suffix { get; init; }
    public TranslationSet Translations => (Unigram, Prefix, Suffix);
}
