using d9.gnc.core.Types.Abstract;

namespace d9.gnc.core.Types;

public class EncipheredWord(params IEnumerable<EncipheredLetter> letters)
    : Word<EncipheredLetter>(letters)
{
}
