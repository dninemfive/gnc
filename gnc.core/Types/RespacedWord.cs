using System.Collections;

namespace d9.gnc.core.Types;

public class RespacedWord(params IEnumerable<RespacedLetter> letters)
    : Word<RespacedLetter>(letters)
{
    public static RespacedWord FromUnigramOrBigram(string s)
        => s.Length switch
        {
            1 => new([(s, LetterType.Unigram)]),
            2 => new([(s[0], LetterType.Prefix), (s[1], LetterType.Suffix)]),
            _ => throw new ArgumentException("RespacedLetters can only (currently?) be made from unigrams or bigrams")
        };
}