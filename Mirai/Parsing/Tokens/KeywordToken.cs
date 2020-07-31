using System;
using System.Diagnostics;
using Mirai.Parsing.SyntaxNodes;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Keyword: {" + nameof(Keyword) + "}")]
    public class KeywordToken : Token, IEquatable<KeywordToken>
    {
        public KeywordToken(Keywords keyword, SourceReference sourceReference)
            : base(sourceReference)
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
            => $"{Keyword} ({SourceReference.Position})";

        public Keywords Keyword { get; }
    }
}