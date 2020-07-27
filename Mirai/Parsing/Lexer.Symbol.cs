using System;
using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.Symbols;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateSymbol(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            // TODO: generate? dictionary?
            Symbols? symbol = sourceCode.Span[0] switch
            {
                '(' => OpenParenthesis,
                ')' => CloseParenthesis,
                '{' => OpenBrace,
                '}' => CloseBrace,
                '.' => Dot,
                ',' => Comma,
                ';' => SemiColon,
                '[' => OpenSquare,
                ']' => CloseSquare,
                '+' => Plus,
                '-' => Minus,
                '*' => Mul,
                '/' => Div,
                '=' => Assign,
                _ => null,
            };

            if (symbol == null)
                return null;

            var result = symbol.Value.AsToken(position.AddColumn(1), sourceCode[..1]);

            sourceCode = sourceCode[1..];

            return result;
        }
    }
}