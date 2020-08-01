using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x0C
    public class CustomAttribute : Table
    {
        public CustomAttribute(
            uint recordIndex,
            CodedIndex<HasCustomAttributeTag> parent,
            CodedIndex<CustomAttributeTypeTag> type,
            MetadataBlob value)
            : base(recordIndex)
        {
            Parent = parent;
            Type = type;
            Value = value;
        }

        public override TableType TableType => TableType.CustomAttribute;

        /// <summary>
        /// An index into a metadata table that has an associated HasCustomAttribute coded index.
        /// </summary>
        public CodedIndex<HasCustomAttributeTag> Parent { get; } // TODO: sort column

        /// <summary>
        /// An index into the MethodDef or MemberRef table; more precisely, a CustomAttributeType coded index.
        /// </summary>
        public CodedIndex<CustomAttributeTypeTag> Type { get; }

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataBlob Value { get; }
    }
}