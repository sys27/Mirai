using System;

namespace Mirai.Parsing
{
    public readonly struct SourceReference : IEquatable<SourceReference>
    {
        public SourceReference(ReadOnlyMemory<char> sourceCode)
            : this(sourceCode, SourcePosition.Default)
        {
        }

        public SourceReference(ReadOnlyMemory<char> sourceCode, int line, int column)
            : this(sourceCode, new SourcePosition(line, column))
        {
        }

        public SourceReference(ReadOnlyMemory<char> sourceCode, SourcePosition position)
        {
            SourceCode = sourceCode;
            Position = position;
        }

        public bool Equals(SourceReference other)
            => SourceCode.Span.SequenceEqual(other.SourceCode.Span) && Position == other.Position;

        public override bool Equals(object? obj)
            => obj is SourceReference other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(SourceCode, Position);

        public static bool operator ==(SourceReference left, SourceReference right)
            => left.Equals(right);

        public static bool operator !=(SourceReference left, SourceReference right)
            => !(left == right);

        // TODO:
        public SourceReference ForToken(int count)
            => new SourceReference(SourceCode[..count], Position);

        public SourceReference AdvanceLineTo(int lineCount)
            => new SourceReference(SourceCode[lineCount..], Position.AdvanceLineTo(lineCount));

        public SourceReference AdvanceColumnTo(int columnCount)
            => new SourceReference(SourceCode[columnCount..], Position.AdvanceColumnTo(columnCount));

        public ReadOnlyMemory<char> SourceCode { get; }
        public ReadOnlySpan<char> Span => SourceCode.Span;
        public bool IsEmpty => SourceCode.IsEmpty;
        public SourcePosition Position { get; }
    }
}