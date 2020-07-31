using System;

namespace Mirai.Parsing
{
    public readonly struct SourcePosition : IEquatable<SourcePosition>
    {
        public SourcePosition(int line, int column)
        {
            if (line <= 0)
                throw new ArgumentOutOfRangeException(nameof(line));
            if (column <= 0)
                throw new ArgumentOutOfRangeException(nameof(column));

            Line = line;
            Column = column;
        }

        public bool Equals(SourcePosition other)
            => Line == other.Line && Column == other.Column;

        public override bool Equals(object? obj)
            => obj is SourcePosition other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Line, Column);

        public override string ToString()
            => $"{Line}, {Column}";

        public static bool operator ==(SourcePosition left, SourcePosition right)
            => left.Equals(right);

        public static bool operator !=(SourcePosition left, SourcePosition right)
            => !(left == right);

        public SourcePosition AdvanceLineTo(int line)
            => new SourcePosition(this.Line + line, 1);

        public SourcePosition AdvanceColumnTo(int column)
            => new SourcePosition(this.Line, this.Column + column);

        public int Line { get; }
        public int Column { get; }

        public static SourcePosition Default => new SourcePosition(1, 1);
    }
}