using d9.gnc.core.Types;

namespace d9.gnc.core.Extensions;

public static class LetterTypeExtensions
{
    extension(RespacedLetter? token) {
        public bool ShouldEncode
        {
            get => token is not null && token.Type is not null;
        }
        public bool IsSpace
        {
            get => token is null;
        }
    }
}
