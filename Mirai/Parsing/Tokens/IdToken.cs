using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    public class IdToken : Token, IEquatable<IdToken>
    {
        public IdToken(SourceReference sourceReference)
            : base(sourceReference)
        {
        }

        public bool Equals(IdToken? other)
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

            return Equals((IdToken) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(SourceReference);

        public override string ToString()
            => $"{Id} ({SourceReference.Position})";

        public ReadOnlyMemory<char> Id => SourceReference.SourceCode;
    }
}