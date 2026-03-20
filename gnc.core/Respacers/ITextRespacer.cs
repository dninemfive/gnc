using d9.gnc.core.Types;

namespace d9.gnc.core.Respacers;

/// <summary>
/// Chunks text into standard units for mapping with the cipher. In the original Naibbe cipher,
/// this will consist of only unigrams and bigrams.
/// </summary>
public interface ITextRespacer
{
    public IEnumerable<RespacedWord> Respace(string text);
}
