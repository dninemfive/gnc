using System.Collections;

namespace d9.gnc.core.Respacers;

public class RespacedWord(params IEnumerable<RespacedLetter> letters)
    : IEnumerable<RespacedLetter>
{
    private readonly IReadOnlyCollection<RespacedLetter> _letters = [.. letters];
    public static RespacedWord FromUnigramOrBigram(string s)
        => s.Length switch
        {
            1 => new([(s, LetterType.Unigram)]),
            2 => new([(s[0], LetterType.Prefix), (s[1], LetterType.Suffix)]),
            _ => throw new ArgumentException("RespacedLetters can only (currently?) be made from unigrams or bigrams")
        };
    public IEnumerator<RespacedLetter> GetEnumerator()
    {
        return _letters.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_letters).GetEnumerator();
    }
}