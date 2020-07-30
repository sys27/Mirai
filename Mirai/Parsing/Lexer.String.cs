using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateString(
            ref ReadOnlyMemory<char> sourceCode,
            ref SourcePosition position)
        {
            var span = sourceCode.Span;

            if (span[0] != '"')
                return null;

            var endIndex = 1;
            while (endIndex < span.Length && span[endIndex] != '"')
                endIndex++;

            endIndex++;

            // TODO: string?
            var token = LiteralType.String.AsToken(position, sourceCode[..endIndex]);

            position = position.AdvanceColumnTo(endIndex);
            sourceCode = sourceCode[endIndex..];

            return token;
        }
    }
}