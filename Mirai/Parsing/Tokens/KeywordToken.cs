using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Keyword: {" + nameof(Keyword) + "}")]
    public class KeywordToken : Token, IEquatable<KeywordToken>
    {
        public KeywordToken(
            Keywords keyword,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            Keyword = keyword;
        }

        public bool Equals(KeywordToken? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Keyword == other.Keyword && base.Equals(other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((KeywordToken) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Keyword);

        public override string ToString()
            => Keyword.ToString();

        public Keywords Keyword { get; }
    }
}