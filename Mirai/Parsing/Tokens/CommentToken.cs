using System;

namespace Mirai.Parsing.Tokens
{
    public class CommentToken : Token
    {
        public CommentToken(
            CommentType type,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            Type = type;
        }

        public CommentType Type { get; }
    }
}