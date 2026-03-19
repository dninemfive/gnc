using d9.gnc.core.Model;
using d9.utl;

namespace d9.gnc.core.TableProviders;

public class SimpleTableProvider(Random? random = null, params IEnumerable<(TranslationTable table, double weight)> weights)
    : ITableProvider
{
    public TranslationTable NextTable()
        => weights.WeightedRandomElement(x => x.weight, random: random).table;
}
