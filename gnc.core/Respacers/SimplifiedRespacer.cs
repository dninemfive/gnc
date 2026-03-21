using d9.gnc.core.Extensions;
using d9.gnc.core.Types;

namespace d9.gnc.core.Respacers;

/// <summary>
/// Chunks text into standard units for mapping with the cipher. In the original Naibbe cipher,
/// this will consist of only unigrams and bigrams.
/// </summary>
public class SimplifiedRespacer(Random? random = null) 
    : ITextRespacer
{
    public readonly Random Random = random ?? new();
    public async IAsyncEnumerable<RespacedWord> Respace(string text)
    {
        int index = 0;
        while (index < text.Length)
        {
            int length = Random.Next(1, 3);
            yield return RespacedWord.FromUnigramOrBigram(text.SubstringSafe(index, length));
            index += length;
        }
    }
}
