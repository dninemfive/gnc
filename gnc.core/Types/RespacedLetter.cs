using d9.gnc.core.Types.Abstract;

namespace d9.gnc.core.Types;

public class RespacedLetter(string s, LetterType t)
    : Letter<string>(s, t)
{
    public RespacedLetter(char c, LetterType type)
        : this("" + c, type) { }
    public static implicit operator RespacedLetter((char c, LetterType t) tuple)
        => new(tuple.c, tuple.t);
    public static implicit operator RespacedLetter((string s, LetterType t) tuple)
        => new(tuple.s, tuple.t);
}
