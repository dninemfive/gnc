using d9.utl;
using CsvHelper;
using Naibbe;
using System.Globalization;
using Naibbe.Extensions;
using Naibbe.Normalizers;
using Naibbe.Respacers;
using Naibbe.TableProviders;
using System.Text;

string basePath = @"C:\Users\dninemfive\Documents\workspaces\misc\Naibbe\";
TranslationTable readTable(string name)
{
    using CsvReader reader = new(File.OpenText(Path.Join(basePath, $"{name}.csv")), CultureInfo.InvariantCulture);
    return new()
    {
        Name = name,
        Data = [.. reader.GetRecords<TranslationTableRow>()]
    };
}
TranslationTable alpha   = readTable("alpha");
TranslationTable beta_1  = readTable("beta_1");
TranslationTable beta_2  = readTable("beta_2");
TranslationTable beta_3  = readTable("beta_3");
TranslationTable gamma_1 = readTable("gamma_1");
TranslationTable gamma_2 = readTable("gamma_2");

CompositeNormalizer normalizer = new(new LowercaseNormalizer(), new RegexNormalizer(new("[^a-z]+")));

Random random = new(0xd9);
NaibbeCipher cipher = new(
    new CompositeNormalizer(
        new LowercaseNormalizer(),
        new RegexNormalizer(new("[^a-z]+")),
        new DictionaryNormalizer(('k', 'c'), ('j', 'i'), ('w', 'u'))
    ),
    new SimplifiedRespacer(random),
    new SimpleTableProvider(random,
        (alpha, 5),
        (beta_1, 2), (beta_2, 2), (beta_3, 2),
        (gamma_1, 1), (gamma_2, 1)
    )
);
string plaintext = "the quick brown fox jumped over the lazy dog";

Console.WriteLine(plaintext);
Console.WriteLine(cipher.Prepare(plaintext).Select(x => x.WithSpace()).Join());
string ciphertext = cipher.Encipher(plaintext).Join().Replace("<", "").Replace(">", "");
Console.WriteLine(ciphertext);

List<(string input, string output)> asdf = [
    ("cfh", "\U000FF40C\U000FF428\U000FF40F"),
    ("cph", "\U000FF40C\U000FF429\U000FF40F"),
    ("ckh", "\U000FF40C\U000FF42A\U000FF40F"),
    ("cth", "\U000FF40C\U000FF42B\U000FF40F"),
    ("ch",  "\U000FF40C\U000FF40F"),
    ("sh",  "\U000FF40D\U000FF40F"),
    ("a",   "\U000ff410"),
    ("d",   "\U000ff409"),
    ("e",   "\U000ff406"),
    ("g",   "\U000ff40b"),
    ("i",   "\U000ff400"),
    ("l",   "\U000ff41a"),
    ("m",   "\U000ff404"),
    ("n",   "\U000ff401"),
    ("o",   "\U000ff414"),
    ("q",   "\U000ff41d"),
    ("x",   "\U000ff41c"),
    ("y",   "\U000ff417"),
    ("r",   "\U000ff403"),
    ("s",   "\U000ff40a"),
    ("h",   "\U000ff40f"),
    ("f",   "\U000FF420"),
    ("p",   "\U000FF421"),
    ("k",   "\U000FF422"),
    ("t",   "\U000FF423"),
    ("<", ""),
    (">", ""),
];

foreach((string input, string output) in asdf)
    ciphertext = ciphertext.Replace(input, output);
Console.WriteLine(ciphertext);