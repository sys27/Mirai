using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Symbol: {" + nameof(symbol) + "}")]
    public sealed class Symbol
    {
        private readonly char symbol; // TODO:

        private Symbol(char symbol)
        {
            this.symbol = symbol;
        }

        public override string ToString() => symbol.ToString();

        public SymbolToken AsToken(SourcePosition sourcePosition, ReadOnlyMemory<char> sourceCode)
            => new SymbolToken(this, sourcePosition, sourceCode);

        public static Symbol Whitespace { get; } = new Symbol(' ');

        public static Symbol NewLine { get; } = new Symbol('\n');

        public static Symbol OpenParenthesis { get; } = new Symbol('(');

        public static Symbol CloseParenthesis { get; } = new Symbol(')');

        public static Symbol OpenBrace { get; } = new Symbol('{');

        public static Symbol CloseBrace { get; } = new Symbol('}');

        public static Symbol OpenSquare { get; } = new Symbol('[');

        public static Symbol CloseSquare { get; } = new Symbol(']');

        public static Symbol Dot { get; } = new Symbol('.');

        public static Symbol Comma { get; } = new Symbol(',');

        public static Symbol SemiColon { get; } = new Symbol(';');

        public static Symbol Plus { get; } = new Symbol('+');

        public static Symbol Minus { get; } = new Symbol('-');

        public static Symbol Mul { get; } = new Symbol('*');

        public static Symbol Div { get; } = new Symbol('/');

        public static Symbol Assign { get; } = new Symbol('=');
    }
}