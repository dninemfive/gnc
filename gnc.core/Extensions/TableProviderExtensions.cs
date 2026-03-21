using d9.gnc.core.TableProviders;

namespace d9.gnc.core.Extensions;

public static class TableProviderExtensions
{
    extension(ITableProvider provider)
    {
        public IReadOnlySet<string> Keys
        {
            get => provider.AllTables.SelectMany(x => x.Data.Keys).ToHashSet();
        }
    }
}
