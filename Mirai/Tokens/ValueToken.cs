using System;
using System.Diagnostics;

namespace Mirai.Tokens
{
    [DebuggerDisplay("Value: {" + nameof(Value) + "}")]
    public class ValueToken<T> : ITokenWithPosition
    {
        public ValueToken(
            T value,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            SourcePosition = sourcePosition;
            SourceCode = sourceCode;
        }

        public T Value { get; }
        public SourcePosition SourcePosition { get; }
        public ReadOnlyMemory<char> SourceCode { get; }
    }
}