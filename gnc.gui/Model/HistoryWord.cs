using d9.gnc.core.Types.Abstract;

namespace d9.gnc.gui.Model;

public class HistoryWord(params IEnumerable<LetterHistory> letters)
    : Word<LetterHistory>(letters)
{

}