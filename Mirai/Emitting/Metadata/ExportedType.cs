using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x27
    public class ExportedType : Table
    {
        public ExportedType(
            uint recordIndex,
            TypeAttributes flags,
            uint typeDefId,
            MetadataString typeName,
            MetadataString typeNamespace,
            CodedIndex<ImplementationTag> implementation)
            : base(recordIndex)
        {
            Flags = flags;
            TypeDefId = typeDefId;
            TypeName = typeName;
            TypeNamespace = typeNamespace;
            Implementation = implementation;
        }

        public override TableType TableType => TableType.ExportedType;

        /// <summary>
        /// A 4-byte bitmask of type TypeAttributes.
        /// </summary>
        public TypeAttributes Flags { get; }

        /// <summary>
        /// A 4-byte index into a TypeDef table of another module in this Assembly.
        /// </summary>
        public uint TypeDefId { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString TypeName { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString TypeNamespace { get; }

        public CodedIndex<ImplementationTag> Implementation { get; }
    }
}