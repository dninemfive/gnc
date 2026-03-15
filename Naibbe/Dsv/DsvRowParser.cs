namespace Naibbe.Dsv;

public delegate T DsvRowParser<T>(IReadOnlyDictionary<string, string> row);