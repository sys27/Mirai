using System;

namespace Mirai.Parsing.Tokens
{
    public class CommentToken : Token, IEquatable<CommentToken>
    {
        public CommentToken(CommentType type, SourceReference sourceReference)
            : base(sourceReference)
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

        public override string ToString()
            => $"{Type} ({SourceReference.Position})";

        public CommentType Type { get; }
    }
}