using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Id: {" + nameof(Id) + "}")]
    public class IdToken : IToken, IEquatable<IdToken>
    {
        public IdToken(SourcePosition sourcePosition, ReadOnlyMemory<char> id)
        {
            SourcePosition = sourcePosition;
            Id = id;
        }

        public bool Equals(IdToken? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return SourcePosition == other.SourcePosition &&
                   SourceCode.Span.SequenceEqual(other.SourceCode.Span);
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
            => HashCode.Combine(Id, SourcePosition);

        public override string ToString()
            => Id.ToString();

        public ReadOnlyMemory<char> Id { get; }
        public SourcePosition SourcePosition { get; }
        public ReadOnlyMemory<char> SourceCode => Id;
    }
}