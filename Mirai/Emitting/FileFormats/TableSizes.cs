using System;
using System.Collections.Immutable;
using Mirai.Emitting.Metadata;
using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.FileFormats
{
    public readonly struct TableSizes
    {
        private readonly ImmutableArray<uint> sizes;

        public TableSizes(ImmutableArray<uint> sizes)
            => this.sizes = sizes;

        public uint this[TableType value]
            => sizes[(int) value];

        public int GetIndexSize(TableType tableType)
        {
            var size = this[tableType];

            return size > ushort.MaxValue ? 4 : 2;
        }

        public int ForCodedIndex<TEnum>(CodedIndexType<TEnum> type) where TEnum : Enum
        {
            var size = uint.MinValue;
            foreach (var table in type.Tables)
            {
                var tableSize = this[table];
                if (tableSize > size)
                    size = tableSize;
            }

            return size << type.Bits > ushort.MaxValue ? 4 : 2;
        }
    }
}