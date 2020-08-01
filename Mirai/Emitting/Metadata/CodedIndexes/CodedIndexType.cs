using System;
using System.Runtime.CompilerServices;

namespace Mirai.Emitting.Metadata.CodedIndexes
{
    public sealed class CodedIndexType<TEnum> where TEnum : Enum
    {
        public byte Bits { get; }
        // TODO: to flag?
        public TableType[] Tables { get; }

        public CodedIndexType(byte bits, TableType[] tables)
        {
            Bits = bits;
            Tables = tables;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint GetMask()
            => ~(uint.MaxValue << Bits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TEnum ToEnum(uint value)
            => Unsafe.As<uint, TEnum>(ref value);

        public CodedIndex<TEnum> Create(uint value)
            => new CodedIndex<TEnum>(value >> Bits, ToEnum(value & GetMask()));
    }
}