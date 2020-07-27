using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateSymbol(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            // TODO: generate?
            var symbol = sourceCode.Span[0] switch
            {
                '(' => Symbol.OpenParenthesis,
                ')' => Symbol.CloseParenthesis,
                '{' => Symbol.OpenBrace,
                '}' => Symbol.CloseBrace,
                '.' => Symbol.Dot,
                ',' => Symbol.Comma,
                ';' => Symbol.SemiColon,
                '[' => Symbol.OpenSquare,
                ']' => Symbol.CloseSquare,
                '+' => Symbol.Plus,
                '-' => Symbol.Minus,
                '*' => Symbol.Mul,
                '/' => Symbol.Div,
                '=' => Symbol.Assign,
                _ => null,
            };

            if (symbol == null)
                return null;

            var result = symbol.AsToken(position.AddColumn(1), sourceCode[..1]);

            sourceCode = sourceCode[1..];

            return result;
        }
    }
}