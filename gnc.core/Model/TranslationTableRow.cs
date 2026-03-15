using Naibbe.Respacers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Naibbe.Model;

public class TranslationTableRow
{
    [Key]
    public required string Letter { get; set;  }
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

    public static implicit operator TranslationTableRow((string, string, string, string) tuple)
    {
        (string l, string u, string p, string s) = tuple;
        return new()
        {
            Letter = l,
            Unigram = u,
            Prefix = p,
            Suffix = s
        };
    }
    public override string ToString()
        => $"{Letter} {Unigram} {Prefix} {Suffix}";
}
