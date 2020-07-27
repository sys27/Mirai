using System;

namespace Mirai.Parsing.Tokens
{
    public class StringToken : Token
    {
        public StringToken(
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
        }
    }
}