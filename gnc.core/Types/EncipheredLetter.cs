using d9.gnc.core.Types.Abstract;

namespace d9.gnc.core.Types;

public class EncipheredLetter(string s, LetterType t)
    : Letter<string>(s, t)
{
    public static implicit operator EncipheredLetter((string s, LetterType t) tuple)
        => new(tuple.s, tuple.t);
}
