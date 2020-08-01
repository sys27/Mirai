using System;
using System.Diagnostics;

namespace Mirai.Emitting.Metadata.Signatures
{
    [DebuggerDisplay("Int: {" + nameof(Value) + "}")]
    public readonly struct CompressedInt
    {
        public CompressedInt(int value)
            => Value = value;

        public (int value, byte size) ToCompressed()
        {
            throw new NotImplementedException(); // TODO:
        }

        public int Value { get; }
    }
}