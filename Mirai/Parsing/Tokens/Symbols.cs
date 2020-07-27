using System;

namespace Mirai.Parsing.Tokens
{
    public enum Symbols
    {
        Whitespace,
        NewLine,
        OpenParenthesis,
        CloseParenthesis,
        OpenBrace,
        CloseBrace,
        OpenSquare,
        CloseSquare,
        Dot,
        Comma,
        SemiColon,
        Plus,
        Minus,
        Mul,
        Div,
        Assign,
    }

    public static class SymbolsExtensions
    {
        public static SymbolToken AsToken(
            this Symbols symbol,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            => new SymbolToken(symbol, sourcePosition, sourceCode);
    }
}