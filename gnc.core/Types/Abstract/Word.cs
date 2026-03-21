using System.Collections;

namespace d9.gnc.core.Types.Abstract;

public abstract class Word<T>(params IEnumerable<T> letters)
    : IEnumerable<T>
{
    private readonly IReadOnlyList<T> _letters = [.. letters];
    public T this[int i]
        => _letters[i];
    public IEnumerator<T> GetEnumerator()
    {
        return _letters.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_letters).GetEnumerator();
    }
}