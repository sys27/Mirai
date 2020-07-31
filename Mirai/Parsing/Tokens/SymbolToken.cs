using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Symbol: {" + nameof(Symbol) + "}")]
    public class SymbolToken : Token, IEquatable<SymbolToken>
    {
        public SymbolToken(Symbols symbol, SourceReference sourceReference)
            : base(sourceReference)
        {
            Symbol = symbol;
        }

        public bool Equals(SymbolToken? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Symbol == other.Symbol && base.Equals(other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((SymbolToken) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Symbol);

        public override string ToString()
            => $"{Symbol} ({SourceReference.Position})";

        public Symbols Symbol { get; }
    }
}