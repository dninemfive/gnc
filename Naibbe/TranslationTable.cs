using d9.utl.types;
using Naibbe.Respacers;
using System.ComponentModel.DataAnnotations;

namespace Naibbe;

public class TranslationTable
{
    [Key]
    public required string Name { get; set; }
    public required List<TranslationTableRow> Data { get; set; }
    private DefaultDictionary<string, TranslationTableRow> _cache
    {
        get
        {
            field ??= new(k => Data.Where(x => x.Letter.Equals(k, StringComparison.InvariantCultureIgnoreCase)).First());
            return field;
        }
    }
    public TranslationTableRow this[string key]
        => _cache[key];
}