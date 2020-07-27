using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateString(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            if (span[0] != '"')
                return null;

            var endIndex = 1;
            while (endIndex < span.Length && span[endIndex] != '"')
                endIndex++;

            endIndex++;

            // TODO: string?
            // TODO: handle position
            var token = new StringToken(position, sourceCode[..endIndex]);

            sourceCode = sourceCode[endIndex..];

            return token;
        }
    }
}