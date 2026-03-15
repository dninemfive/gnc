using d9.utl;
using System.Reflection;
using DsvRow = System.Collections.Generic.IReadOnlyDictionary<string, string>;

namespace Naibbe.Dsv;
/// <summary>
/// Extensions to handle Delimiter-Separated Values files (e.g. csv, tsv)
/// </summary>
public static class DsvExtensions
{
    public static IEnumerable<DsvRow> ParseDsvWithHeader(this IEnumerable<string> rows, string delimiter = ",")
    {
        if (rows.Count() < 2)
            yield break;
        string[] header = rows.First().Split(delimiter);
        foreach(string row in rows.Skip(1))
        {
            Dictionary<string, string> item = new();
            string[] split = row.Split(delimiter);
            if (split.Length != header.Length)
                throw new Exception($"Length of data row `{row}` ({split.Length}) did not match length of header `{header}` ({header.Length})");
            for (int i = 0; i < header.Length; i++)
                item[header[i]] = split[i];
            yield return item;
        }
    }
    public static T ParseWith<T>(this DsvRow row, DsvRowParser<T> parse)
        => parse(row);
    public static IEnumerable<T> Parse<T>(this IEnumerable<DsvRow> rows, DsvRowParser<T> parse)
        => rows.Select(x => parse(x));
    public static IEnumerable<T> ParseDsvTo<T>(this IEnumerable<string> rows, DsvRowParser<T>? parse = null, string delimiter = ",")
        => rows.ParseDsvWithHeader(delimiter).Parse(parse ?? DefaultParser<T>());
    public static DsvRowParser<T> DefaultParser<T>()
    {
        static T parse(DsvRow row)
        {
            T item = Activator.CreateInstance<T>();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (!row.ContainsKey(property.Name))
                    throw new Exception($"Could not find key {property.Name} in row {row.ListNotation(brackets: ("{", "}"))}");
                Type propType = property.PropertyType;
                if (propType.IsAssignableFrom(typeof(string))) 
                {
                    property.SetValue(item, row[property.Name]);
                }
                else if (propType.GetParseMethod() is MethodInfo parse)
                {
                    property.SetValue(item, parse.Invoke(null, [row[property.Name], null]));
                }
                else
                {
                    throw new Exception($"Type {property.PropertyType} does not implement IParsable");
                }
            }
            return item;
        }
        return parse;
    }
    // https://stackoverflow.com/a/74502465
    public static bool IsParsable(this Type t)
        => t.GetInterfaces().Any(x => x.IsGenericType
                                   && x.GetGenericTypeDefinition() == typeof(IParsable<>));
    public static bool SignatureMatches(this MethodInfo info, string name, Type returnType, params Type[] paramTypes)
    {
        if (info.Name != name)
            return false;
        if(!info.ReturnType.IsAssignableTo(returnType)) 
            return false;
        return info.ParametersMatch(paramTypes);
    } 
    public static bool ParametersMatch(this MethodInfo method, params Type[] types)
        => method.GetParameters().Match(types);
    public static bool Match(this ParameterInfo[]? parameters, params Type[] types)
    {
        if (parameters is null)
            return types.Length == 0;
        if (parameters.Length != types.Length)
            return false;
        for (int i = 0; i < parameters.Length; i++)
            if (parameters[i].ParameterType != types[i])
                return false;
        return true;
    }
    public static MethodInfo? GetParseMethod(this Type t)
    {
        if (!t.IsParsable())
            return null;
        return t.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(x => x.SignatureMatches("Parse", t, typeof(string), typeof(IFormatProvider)));
    }

}
