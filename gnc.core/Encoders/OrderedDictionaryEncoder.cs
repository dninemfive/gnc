namespace d9.gnc.core.Encoders;

/// <summary>
/// Encodes strings starting with the longest inputs first to avoid collisions. Not very robust but
/// it's all i need atm.
/// </summary>
/// <param name="dict">The list of inputs to encode to the outputs. inputs SHOULD be unique.</param>
public class OrderedDictionaryEncoder(params IEnumerable<(string input, string output)> dict)
    : IEncoder
{
    public static OrderedDictionaryEncoder VoynichEveEncoder
        => new(
            ("cfh", "\U000FF40C\U000FF428\U000FF40F"),
            ("cph", "\U000FF40C\U000FF429\U000FF40F"),
            ("ckh", "\U000FF40C\U000FF42A\U000FF40F"),
            ("cth", "\U000FF40C\U000FF42B\U000FF40F"),
            ("ch", "\U000FF40C\U000FF40F"),
            ("sh", "\U000FF40D\U000FF40F"),
            ("a", "\U000ff410"),
            ("d", "\U000ff409"),
            ("e", "\U000ff406"),
            ("g", "\U000ff40b"),
            ("i", "\U000ff400"),
            ("l", "\U000ff41a"),
            ("m", "\U000ff404"),
            ("n", "\U000ff401"),
            ("o", "\U000ff414"),
            ("q", "\U000ff41d"),
            ("x", "\U000ff41c"),
            ("y", "\U000ff417"),
            ("r", "\U000ff403"),
            ("s", "\U000ff40a"),
            ("h", "\U000ff40f"),
            ("f", "\U000FF420"),
            ("p", "\U000FF421"),
            ("k", "\U000FF422"),
            ("t", "\U000FF423")
        );
    public string Encode(string text)
    {
        foreach((string input, string output) in dict.OrderBy(x => x.input.Length))
            text = text.Replace(input, output);
        return text;
    }
}
