namespace d9.gnc.core.Types.Abstract;

public class Letter<T>(T v, LetterType t)
{
    public T Value { get; init; } = v;
    public LetterType Type { get; init; } = t;
    public static implicit operator Letter<T>((T v, LetterType t) tuple)
        => new(tuple.v, tuple.t);
    public void Deconstruct(out T value, out LetterType type)
    {
        value = Value;
        type = Type;
    }
}
