using System;

namespace Mirai.Parsing.Tokens
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