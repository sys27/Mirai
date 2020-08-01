using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x28
    public class ManifestResource : Table
    {
        public ManifestResource(
            uint recordIndex,
            uint offset,
            ManifestResourceAttributes flags,
            MetadataString name,
            CodedIndex<ImplementationTag> implementation)
            : base(recordIndex)
        {
            Offset = offset;
            Flags = flags;
            Name = name;
            Implementation = implementation;
        }

        public override TableType TableType => TableType.ManifestResource;

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint Offset { get; }

        /// <summary>
        /// A 4-byte bitmask of type ManifestResourceAttributes.
        /// </summary>
        public ManifestResourceAttributes Flags { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Name { get; }

        /// <summary>
        /// An index into a File table, a AssemblyRef table, or null; more precisely, an Implementation coded index.
        /// </summary>
        public CodedIndex<ImplementationTag> Implementation { get; }
    }
}