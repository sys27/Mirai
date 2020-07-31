using System;

namespace Mirai.Parsing.Tokens
{
    public class LiteralToken : Token, IEquatable<LiteralToken>
    {
        // TODO: to types?
        public LiteralToken(LiteralType type, SourceReference sourceReference)
            : base(sourceReference)
        {
            Type = type;
        }

        public bool Equals(LiteralToken? other)
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

            return Equals((LiteralToken) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Type);

        public override string ToString()
            => $"{Type} ({SourceReference.Position})";

        public LiteralType Type { get; }
    }
}