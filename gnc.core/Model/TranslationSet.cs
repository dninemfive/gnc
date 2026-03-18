using d9.gnc.core.Respacers;

namespace d9.gnc.core.Model;

public class TranslationSet
{
    public required string Unigram { get; set; }
    public required string Prefix { get; set; }
    public required string Suffix { get; set; }
    public string this[LetterType type]
        => type switch
        {
            LetterType.Unigram => Unigram,
            LetterType.Prefix => Prefix,
            LetterType.Suffix => Suffix,
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    public static implicit operator TranslationSet((string, string, string) tuple)
    {
        (string u, string p, string s) = tuple;
        return new()
        {
            Unigram = u,
            Prefix = p,
            Suffix = s
        };
    }
    public override string ToString()
        => $"{Unigram} {Prefix} {Suffix}";
}
