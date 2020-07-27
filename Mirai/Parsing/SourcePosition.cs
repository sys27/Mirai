using System;

namespace Mirai.Parsing
{
    public readonly struct SourcePosition
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

        public SourcePosition AddLine(int line)
            => new SourcePosition(this.Line + line, this.Column);

        public SourcePosition AddColumn(int column)
            => new SourcePosition(this.Line, this.Column + column);

        public int Line { get; }
        public int Column { get; }

        public static SourcePosition Default => new SourcePosition(1, 1);
    }
}