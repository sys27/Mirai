using System;

namespace Mirai.Parsing.Tokens
{
    public class LiteralToken : Token
    {
        public LiteralToken(
            LiteralType type, // TODO: to types?
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            Type = type;
        }

        public LiteralType Type { get; }
    }
}