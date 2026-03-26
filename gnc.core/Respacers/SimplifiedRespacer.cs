using d9.gnc.core.Extensions;
using d9.gnc.core.Types;

namespace d9.gnc.core.Respacers;

/// <summary>
/// Chunks text into standard units for mapping with the cipher. In the original Naibbe cipher,
/// this will consist of only unigrams and bigrams.
/// </summary>
public class SimplifiedRespacer(double unigramProportion = 0.5, Random? random = null) 
    : ITextRespacer
{
    public readonly Random Random = random ?? new();
    public double UnigramProportion { get; set; } = unigramProportion;
    public async IAsyncEnumerable<RespacedWord> RespaceAsync(string text)
    {
        int index = 0;
        while (index < text.Length)
        {
            int length = Random.NextDouble() < UnigramProportion ? 1 : 2; 
            yield return RespacedWord.FromUnigramOrBigram(text.SubstringSafe(index, length));
            index += length;
        }
    }
}
