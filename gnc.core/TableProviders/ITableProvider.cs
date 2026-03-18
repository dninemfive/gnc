using d9.gnc.core.Model;

namespace d9.gnc.core.TableProviders;

public interface ITableProvider
{
    public TranslationTable NextTable();
}
