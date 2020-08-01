using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x0D
    public class FieldMarshal : Table
    {
        public FieldMarshal(
            uint recordIndex,
            CodedIndex<HasFieldMarshallTag> parent,
            MetadataBlob nativeType)
            : base(recordIndex)
        {
            Parent = parent;
            NativeType = nativeType;
        }

        public override TableType TableType => TableType.FieldMarshal;

        /// <summary>
        /// An index into Field or Param table; more precisely, a HasFieldMarshal coded index.
        /// </summary>
        public CodedIndex<HasFieldMarshallTag> Parent { get; } // TODO: sort column

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataBlob NativeType { get; }
    }
}