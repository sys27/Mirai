using System;
using System.Runtime.CompilerServices;
using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.Symbols;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateWhitespace(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            var index = 0;
            while (IsWhitespace(span[index]))
                index++;

            if (index <= 0)
                return null;

            var token = Whitespace.AsToken(position.AddColumn(index), sourceCode[..index]);

            sourceCode = sourceCode[index..];

            return token;
        }

        // \x0009 - horizontal tab
        // \x000B - vertical tab
        // \x000C - form feed
        // \x0020 - space
        // \x00A0 - nbsp
        // \x1680 - ogham space mark
        // \x2000 - en quad
        // \x2001 - em quad
        // \x2002 - en space
        // \x2003 - em space
        // \x2004 - three-per-em space
        // \x2005 - four-per-em space
        // \x2006 - six-per-em space
        // \x2007 - figure space
        // \x2008 - punctuation space
        // \x2009 - thin space
        // \x200A - hair space
        // \x202F - nnbsp
        // \x205F - mmsb
        // \x3000 - ideographic space
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsWhitespace(char symbol)
            => symbol == '\x0009' ||
               symbol == '\x000B' ||
               symbol == '\x000C' ||
               symbol == '\x0020' ||
               symbol == '\x00A0' ||
               symbol == '\x1680' ||
               IsInRange(symbol, '\x2000', '\x200A') ||
               symbol == '\x202F' ||
               symbol == '\x205F' ||
               symbol == '\x3000';
    }
}