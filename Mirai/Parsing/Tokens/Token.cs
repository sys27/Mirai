using System;

namespace Mirai.Parsing.Tokens
{
    public abstract class Token : IToken, IEquatable<Token>
    {
        protected Token(
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
        {
            SourcePosition = sourcePosition;
            SourceCode = sourceCode;
        }

        public bool Equals(Token? other)
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

            return Equals((Token) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(SourcePosition, SourceCode);

        public SourcePosition SourcePosition { get; }
        public ReadOnlyMemory<char> SourceCode { get; }
    }
}