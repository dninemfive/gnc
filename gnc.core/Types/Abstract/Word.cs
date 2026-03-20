using System.Collections;

namespace d9.gnc.core.Types.Abstract;

public abstract class Word<T>(params IEnumerable<T> letters)
    : IEnumerable<T>
{
    private readonly IReadOnlyCollection<T> _letters = [.. letters];
    public IEnumerator<T> GetEnumerator()
    {
        return _letters.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_letters).GetEnumerator();
    }
}