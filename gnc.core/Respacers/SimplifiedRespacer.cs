using d9.gnc.core.Extensions;

namespace d9.gnc.core.Respacers;

/// <summary>
/// Chunks text into standard units for mapping with the cipher. In the original Naibbe cipher,
/// this will consist of only unigrams and bigrams.
/// </summary>
public class SimplifiedRespacer(Random? random = null) 
    : ITextRespacer
{
    public readonly Random Random = random ?? new();
    public IEnumerable<RespacedLetter> Respace(string text)
    {
        int index = 0;
        while (index < text.Length)
        {
            int length = Random.Next(1, 3);
            foreach(RespacedLetter letter in RespacedLetter.FromString(text.SubstringSafe(index, length)))
                yield return letter;
            index += length;
        }
    }
}
