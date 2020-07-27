using System;

namespace Mirai.Parsing.Tokens
{
    public enum LiteralType
    {
        Integer,
        Real,
        Character,
        String
    }

    public static class LiteralTypeExtensions
    {
        // TODO: to static factory methods?
        public static LiteralToken AsToken(
            this LiteralType keyword,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            => new LiteralToken(keyword, sourcePosition, sourceCode);
    }
}