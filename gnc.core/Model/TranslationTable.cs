using CsvHelper;
using d9.utl.types;
using Naibbe.Respacers;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Naibbe.Model;

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
    public static TranslationTable LoadCsv(string basePath, string name)
    {
        using CsvReader reader = new(File.OpenText(Path.Join(basePath, $"{name}.csv")), CultureInfo.InvariantCulture);
        return new()
        {
            Name = name,
            Data = [.. reader.GetRecords<TranslationTableRow>()]
        };
    }
}