using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.LiteralType;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateCharacter(ref SourceReference reference)
        {
            var span = reference.Span;
            var index = 0;
            if (span[index] != '\'')
                return null;

            index++;

            while (span[index] != '\'')
                index++;

            index++;

            var token = Character.AsToken(reference.ForToken(index));

            reference = reference.AdvanceColumnTo(index);

            return token;
        }
    }
}