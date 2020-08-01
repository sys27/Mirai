using System;

namespace Mirai.Emitting.Metadata
{
    public readonly struct MetadataToken
    {
        private const uint RECORD_INDEX_MASK = 0x00FFFFFF;
        private const byte TABLE_SHIFT = 24;

        public MetadataToken(TableType tableType, uint recordIndex)
        {
            if (recordIndex > RECORD_INDEX_MASK)
                throw new Exception(); // TODO:

            Value = ((uint) tableType << TABLE_SHIFT) | recordIndex;
        }

        public uint Value { get; }
        public TableType Table => (TableType) (Value >> TABLE_SHIFT);
        public uint RecordIndex => Value & RECORD_INDEX_MASK;
    }
}