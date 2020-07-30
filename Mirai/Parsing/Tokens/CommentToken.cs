using System;

namespace Mirai.Parsing.Tokens
{
    public class CommentToken : Token, IEquatable<CommentToken>
    {
        public CommentToken(
            CommentType type,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            Type = type;
        }

        public bool Equals(CommentToken? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Type == other.Type && base.Equals(other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((CommentToken) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Type);

        public CommentType Type { get; }
    }
}