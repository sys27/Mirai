using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x1C
    public class ImplMap : Table
    {
        public ImplMap(
            uint recordIndex,
            PInvokeAttributes mappingFlags,
            CodedIndex<MemberForwardedTag> memberForwarded,
            MetadataString importName,
            uint importScope)
            : base(recordIndex)
        {
            MappingFlags = mappingFlags;
            MemberForwarded = memberForwarded;
            ImportName = importName;
            ImportScope = importScope;
        }

        public override TableType TableType => TableType.ImplMap;

        /// <summary>
        /// A 2-byte bitmask of type PInvokeAttributes.
        /// </summary>
        public PInvokeAttributes MappingFlags { get; }

        /// <summary>
        /// An index into the Field or MethodDef table; more precisely, a MemberForwarded coded index.
        /// </summary>
        public CodedIndex<MemberForwardedTag> MemberForwarded { get; } // TODO: sort column

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString ImportName { get; }

        /// <summary>
        /// An index into the ModuleRef table.
        /// </summary>
        public uint ImportScope { get; }
    }
}