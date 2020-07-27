using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Symbol: {" + nameof(symbol) + "}")]
    public class SymbolToken : Token
    {
        private readonly Symbol symbol;

        public SymbolToken(
            Symbol symbol,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            this.symbol = symbol;
        }
    }
}