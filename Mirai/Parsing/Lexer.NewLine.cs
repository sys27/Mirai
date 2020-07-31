using System;
using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.Symbols;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateNewLine(ref SourceReference reference)
        {
            var span = reference.Span;
            var (found, length) = IsNewLine(span);
            if (!found)
                return null;

            var token = NewLine.AsToken(reference.ForToken(length));

            reference = reference.AdvanceLineTo(length);

            return token;
        }

        // \x000D - carriage return
        // \x000A - line feed
        // \x000D \x000A
        // \x0085 - next line
        // \x2028 - line separator
        // \x2029 - paragraph separator
        private static (bool found, int length) IsNewLine(ReadOnlySpan<char> span)
        {
            if (span[0] == '\x000A' ||
                span[0] == '\x000D' ||
                span[0] == '\x0085' ||
                span[0] == '\x2028' ||
                span[0] == '\x2029')
                return (true, 1);

            if (span.Length > 1 && span[0] == '\x000D' && span[1] == '\x000A')
                return (true, 2);

            return (false, 0);
        }
    }
}