using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Symbol: {" + nameof(Symbol) + "}")]
    public class SymbolToken : Token
    {
        public SymbolToken(
            Symbols symbol,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            Symbol = symbol;
        }

        public Symbols Symbol { get; }
    }
}