using System;

namespace Mirai.Parsing.Tokens
{
    public class PreprocessorDirectiveToken : Token, IEquatable<PreprocessorDirectiveToken>
    {
        public PreprocessorDirectiveToken(
            PreprocessorDirectives directive,
            SourceReference sourceReference)
            : base(sourceReference)
        {
            Directive = directive;
        }

        public bool Equals(PreprocessorDirectiveToken? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Directive == other.Directive && base.Equals(other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((PreprocessorDirectiveToken) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Directive);

        public override string ToString()
            => $"{Directive} ({SourceReference.Position})";

        public PreprocessorDirectives Directive { get; }
    }
}