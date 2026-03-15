using d9.gnc.core;
using d9.gnc.core.Encoders;
using d9.utl;

namespace d9.gnc.cli;

internal class Program
{
    static void Main(string[] args)
    {
        NaibbeCipher cipher = NaibbeCipher.MakeDefault(@"C:\Users\dninemfive\Documents\workspaces\misc\Naibbe\data");

        string plaintext = "the quick brown fox jumped over the lazy dog";

        Console.WriteLine(plaintext);
        Console.WriteLine(cipher.Prepare(plaintext).Select(x => x.WithSpace()).Join());
        string ciphertext = cipher.Encipher(plaintext).Join().Replace("<", "").Replace(">", "");
        Console.WriteLine(ciphertext);
        string encoded = OrderedDictionaryEncoder.VoynichEveEncoder.Encode(ciphertext);
        Console.WriteLine(encoded);
    }
}
