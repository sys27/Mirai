using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.Symbols;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateSymbol(ref SourceReference reference)
        {
            // TODO: generate? dictionary?
            Symbols? symbol = reference.Span[0] switch
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

            var result = symbol.Value.AsToken(reference.ForToken(1));

            reference = reference.AdvanceColumnTo(1);

            return result;
        }
    }
}