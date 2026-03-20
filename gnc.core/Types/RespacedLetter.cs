namespace d9.gnc.core.Respacers;

public record RespacedLetter(string Letter, LetterType Type)
{
    public RespacedLetter(char c, LetterType type)
        : this("" + c, type) { }
    public static implicit operator RespacedLetter((char c, LetterType t) tuple)
        => new(tuple.c, tuple.t);
    public static implicit operator RespacedLetter((string s, LetterType t) tuple)
        => new(tuple.s, tuple.t);
    public string WithSpace()
        => $"{Letter}{(Type is LetterType.Unigram or LetterType.Suffix ? " " : "")}";
}
