using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private ITokenWithPosition? Symbol(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            // TODO: generate?
            var symbol = sourceCode.Span[0] switch
            {
                '(' => SymbolToken.OpenParenthesis,
                ')' => SymbolToken.CloseParenthesis,
                '{' => SymbolToken.OpenBrace,
                '}' => SymbolToken.CloseBrace,
                '.' => SymbolToken.Dot,
                ',' => SymbolToken.Comma,
                ';' => SymbolToken.SemiColon,
                '[' => SymbolToken.OpenSquare,
                ']' => SymbolToken.CloseSquare,
                '+' => SymbolToken.Plus,
                '-' => SymbolToken.Minus,
                '*' => SymbolToken.Mul,
                '/' => SymbolToken.Div,
                '=' => SymbolToken.Assign,
                _ => null,
            };

            if (symbol == null)
                return null;

            var result = symbol.Wrap(position.AddColumn(1), sourceCode[..1]);

            sourceCode = sourceCode[1..];

            return result;
        }
    }
}