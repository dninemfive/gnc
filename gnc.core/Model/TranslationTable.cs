using CsvHelper;
using d9.utl.types;
using System.Globalization;

namespace d9.gnc.core.Model;

public class TranslationTable(IReadOnlyDictionary<string, TranslationSet> data)
{
    public IReadOnlyDictionary<string, TranslationSet> Data { get; init; } = data;
    public TranslationTable(IEnumerable<TranslationTableRow> data)
        : this(data.Select(x => (x.Letter, x.Translations)).ToDictionary()) { }
    public TranslationSet this[string key]
        => Data[key.ToUpper()];
    public static async Task<TranslationTable> ParseCsvAsync(string csv)
    {
        using CsvReader reader = new(new StringReader(csv), CultureInfo.InvariantCulture);
        return new(await Task.Run(() => reader.GetRecordsAsync<TranslationTableRow>().ToBlockingEnumerable()));
    }
}