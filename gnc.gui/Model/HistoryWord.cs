using d9.gnc.core.Encoders;
using d9.gnc.core.Types;
using d9.gnc.core.Types.Abstract;
using d9.utl;

namespace d9.gnc.gui.Model;

public class HistoryWord(params IEnumerable<LetterHistory> letters)
    : Word<LetterHistory>(letters)
{
    public static HistoryWord FromWord(RespacedWord respaced, EncipheredWord enciphered, IEncoder encoder)
    {
        List<LetterHistory> letters = [];
        for(int i = 0; i < respaced.Count(); i++)
        {
            string letter = respaced[i].Value;
            string latin = enciphered[i].Value;
            string voynich = encoder.Encode(latin);
            LetterType type = respaced[i].Type;
            letters.Add(new(letter, latin, voynich, type));
        }
        return new(letters);
    }
    public string VoynichText
        => letters.Select(x => x.Voynich).Join();
}