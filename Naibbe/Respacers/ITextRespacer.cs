using System;
using System.Collections.Generic;
using System.Text;

namespace Naibbe.Respacers;

/// <summary>
/// Chunks text into standard units for mapping with the cipher. In the original Naibbe cipher,
/// this will consist of only unigrams and bigrams.
/// </summary>
public interface ITextRespacer
{
    public IEnumerable<RespacedLetter> Respace(string text);
}
