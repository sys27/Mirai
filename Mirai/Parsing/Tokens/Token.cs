using System;

namespace Mirai.Parsing.Tokens
{
    public abstract class Token : IToken, IEquatable<Token>
    {
        protected Token(SourceReference sourceReference)
        {
            SourceReference = sourceReference;
        }

        public bool Equals(Token? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return SourceReference == other.SourceReference;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((Token) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(SourceReference);

        public SourceReference SourceReference { get; }
    }
}