using System;
using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.Symbols;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateSymbol(
            ref ReadOnlyMemory<char> sourceCode,
            ref SourcePosition position)
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

            var result = symbol.Value.AsToken(position, sourceCode[..1]);

            position = position.AdvanceColumnTo(1);
            sourceCode = sourceCode[1..];

            return result;
        }
    }
}