using System;

namespace Mirai.Tokens
{
    public class StringLiteralToken : LiteralToken
    {
        public StringLiteralToken(
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
        }
    }
}