using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x0B
    public class Constant : Table
    {
        public Constant(
            uint recordIndex,
            ElementType type,
            CodedIndex<HasConstantTag> parent,
            MetadataBlob value)
            : base(recordIndex)
        {
            Type = type;
            Parent = parent;
            Value = value;
        }

        public override TableType TableType => TableType.Constant;

        /// <summary>
        /// A 1-byte constant, followed by a 1-byte padding zero.
        /// </summary>
        public ElementType Type { get; }

        /// <summary>
        /// An index into the Param, Field, or Property table; more precisely, a HasConstant coded index.
        /// </summary>
        public CodedIndex<HasConstantTag> Parent { get; } // TODO: sort column

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataBlob Value { get; }
    }
}