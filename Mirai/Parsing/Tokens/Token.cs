using System;

namespace Mirai.Parsing.Tokens
{
    public abstract class Token : IToken
    {
        protected Token(
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
        {
            SourcePosition = sourcePosition;
            SourceCode = sourceCode;
        }

        public SourcePosition SourcePosition { get; }
        public ReadOnlyMemory<char> SourceCode { get; }
    }
}