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
    public static TranslationTable LoadCsv(string basePath, string name)
    {
        using CsvReader reader = new(File.OpenText(Path.Join(basePath, $"{name}.csv")), CultureInfo.InvariantCulture);
        return new(reader.GetRecords<TranslationTableRow>());
    }
    public static async Task<TranslationTable> ParseCsvAsync(string csv)
    {
        using CsvReader reader = new(new StringReader(csv), CultureInfo.InvariantCulture);
        return new(await Task.Run(() => reader.GetRecordsAsync<TranslationTableRow>().ToBlockingEnumerable()));
    }
}