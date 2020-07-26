using System.Diagnostics;

namespace Mirai.Tokens
{
    [DebuggerDisplay("Symbol: {" + nameof(symbol) + "}")]
    public class SymbolToken : IToken
    {
        private readonly char symbol; // TODO:

        private SymbolToken(char symbol)
        {
            this.symbol = symbol;
        }

        public static SymbolToken Whitespace { get; } = new SymbolToken(' ');

        public static SymbolToken NewLine { get; } = new SymbolToken('\n');

        public static SymbolToken OpenParenthesis { get; } = new SymbolToken('(');

        public static SymbolToken CloseParenthesis { get; } = new SymbolToken(')');

        public static SymbolToken OpenBrace { get; } = new SymbolToken('{');

        public static SymbolToken CloseBrace { get; } = new SymbolToken('}');

        public static SymbolToken OpenSquare { get; } = new SymbolToken('[');

        public static SymbolToken CloseSquare { get; } = new SymbolToken(']');

        public static SymbolToken Dot { get; } = new SymbolToken('.');

        public static SymbolToken Comma { get; } = new SymbolToken(',');

        public static SymbolToken SemiColon { get; } = new SymbolToken(';');

        public static SymbolToken Plus { get; } = new SymbolToken('+');

        public static SymbolToken Minus { get; } = new SymbolToken('-');

        public static SymbolToken Assign { get; } = new SymbolToken('=');
    }
}