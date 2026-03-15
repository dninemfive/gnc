using d9.utl;

namespace Naibbe.Respacers;

public record RespacedLetter(string Letter, LetterType Type)
{
    public RespacedLetter(char c, LetterType type)
        : this("" + c, type) { }
    public static IEnumerable<RespacedLetter> FromString(string s)
        => s.Length switch
        {
            1 => [(s, LetterType.Unigram)],
            2 => [(s[0], LetterType.Prefix), (s[1], LetterType.Suffix)],
            _ => throw new ArgumentException("RespacedLetters can only be made from unigrams or bigrams")
        };
    public static implicit operator RespacedLetter((char c, LetterType t) tuple)
        => new(tuple.c, tuple.t);
    public static implicit operator RespacedLetter((string s, LetterType t) tuple)
        => new(tuple.s, tuple.t);
    public string WithSpace()
        => $"{Letter}{(Type is LetterType.Unigram or LetterType.Suffix ? " " : "")}";
}
