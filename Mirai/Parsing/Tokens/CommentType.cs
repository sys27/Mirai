using System;

namespace Mirai.Parsing.Tokens
{
    public enum CommentType
    {
        SingleLine,
        MultiLine,
        XmlDoc
    }

    public static class CommentTypeExtensions
    {
        // TODO: to static factory methods?
        public static CommentToken AsToken(
            this CommentType type,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            => new CommentToken(type, sourcePosition, sourceCode);
    }
}