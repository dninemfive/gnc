using Naibbe.Model;

namespace Naibbe.TableProviders;

public interface ITableProvider
{
    public TranslationTable NextTable();
}
