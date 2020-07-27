using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Value: {" + nameof(SourceCode) + "}")]
    public abstract class LiteralToken : ITokenWithPosition
    {
        protected LiteralToken(
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
        {
            SourcePosition = sourcePosition;
            SourceCode = sourceCode;
        }

        public override string ToString() => SourceCode.ToString();

        public SourcePosition SourcePosition { get; }
        public ReadOnlyMemory<char> SourceCode { get; }
    }
}