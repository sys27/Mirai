using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateString(ref SourceReference reference)
        {
            var span = reference.Span;

            if (span[0] != '"')
                return null;

            var endIndex = 1;
            while (endIndex < span.Length && span[endIndex] != '"')
                endIndex++;

            endIndex++;

            // TODO: string?
            var token = LiteralType.String.AsToken(reference.ForToken(endIndex));

            reference = reference.AdvanceColumnTo(endIndex);

            return token;
        }
    }
}