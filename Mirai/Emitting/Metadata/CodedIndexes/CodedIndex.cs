using System;
using System.Diagnostics;

namespace Mirai.Emitting.Metadata.CodedIndexes
{
    [DebuggerDisplay("Value: {" + nameof(Index) + "}, Table: {" + nameof(TableType) + "}")]
    public readonly struct CodedIndex<TEnum> where TEnum : Enum
    {
        public CodedIndex(uint index, TEnum tableType)
        {
            Index = index;
            TableType = tableType;
        }

        public uint Index { get; }
        public TEnum TableType { get; }
    }
}