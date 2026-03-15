using d9.utl;
using Naibbe.Model;

namespace Naibbe.TableProviders;

public class SimpleTableProvider(Random? random = null, params IEnumerable<(TranslationTable table, double weight)> weights)
    : ITableProvider
{
    public Random Random => random ?? new();
    public TranslationTable NextTable()
        => weights.WeightedRandomElement(x => x.weight).table;
}
