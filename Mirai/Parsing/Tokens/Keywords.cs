using System;

namespace Mirai.Parsing.Tokens
{
    public enum Keywords
    {
        Case,
        Class,
        Else,
        Enum,
        If,
        Internal,
        Namespace,
        Private,
        Protected,
        Public,
        Static,
        Struct,
        Switch,
        Using,
        Var,
        Void
    }

    public static class KeywordsExtensions
    {
        public static KeywordToken AsToken(
            this Keywords keyword,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            => new KeywordToken(keyword, sourcePosition, sourceCode);
    }
}