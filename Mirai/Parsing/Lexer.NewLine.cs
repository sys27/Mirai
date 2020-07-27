using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateNewLine(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            if (!IsNewLine(span))
                return null;

            var token = Symbol.NewLine.AsToken(position.AddLine(1), sourceCode[..1]);

            sourceCode = sourceCode[1..];

            return token;
        }

        // \x000D - carriage return
        // \x000A - line feed
        // \x000D \x000A
        // \x0085 - next line
        // \x2028 - line separator
        // \x2029 - paragraph separator
        private static bool IsNewLine(ReadOnlySpan<char> span)
        {
            return span[0] == '\x000A' ||
                   span[0] == '\x000D' ||
                   (span.Length > 1 && span[0] == '\x000D' && span[1] == '\x000A') ||
                   span[0] == '\x0085' ||
                   span[0] == '\x2028' ||
                   span[0] == '\x2029';
        }
    }
}