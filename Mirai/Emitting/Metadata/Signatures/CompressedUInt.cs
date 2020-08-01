using System;
using System.Diagnostics;

namespace Mirai.Emitting.Metadata.Signatures
{
    [DebuggerDisplay("UInt: {" + nameof(Value) + "}")]
    public readonly struct CompressedUInt
    {
        public CompressedUInt(uint value)
            => Value = value;

        public static implicit operator uint(CompressedUInt compressed)
            => compressed.Value;

        public static CompressedUInt FromCompressed(ref ReadOnlySpan<byte> bytes)
        {
            if (bytes.Length == 0)
                throw new Exception();

            var b = bytes[0];

            if ((b & 0b10000000) == 0)
            {
                bytes = bytes[1..];

                return new CompressedUInt(b);
            }

            if ((b & 0b11000000) == 0b10000000)
            {
                if (bytes.Length < 2)
                    throw new Exception();

                var x = bytes[1];
                var value = (uint) (((b & 0b00111111) << 8) + x);

                bytes = bytes[2..];

                return new CompressedUInt(value);
            }

            if ((b & 0b11100000) == 0b11000000)
            {
                if (bytes.Length < 4)
                    throw new Exception();

                var x = bytes[1];
                var y = bytes[2];
                var z = bytes[3];
                var value = (uint) (((b & 0b00011111) << 24) + (x << 16) + (y << 8) + z);

                bytes = bytes[4..];

                return new CompressedUInt(value);
            }

            throw new Exception();
        }

        public (uint value, byte size) ToCompressed()
        {
            throw new NotImplementedException(); // TODO:
        }

        public uint Value { get; }
    }
}