using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x01
    public class TypeRef : Table
    {
        public TypeRef(
            uint recordIndex,
            CodedIndex<ResolutionScopeTag>? resolutionScope,
            MetadataString typeName,
            MetadataString typeNamespace)
            : base(recordIndex)
        {
            ResolutionScope = resolutionScope;
            TypeName = typeName;
            TypeNamespace = typeNamespace;
        }

        public override TableType TableType => TableType.TypeRef;

        /// <summary>
        /// An index into a Module, ModuleRef, AssemblyRef or TypeRef table, or null; more precisely, a ResolutionScope coded index.
        /// </summary>
        public CodedIndex<ResolutionScopeTag>? ResolutionScope { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString TypeName { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString TypeNamespace { get; }
    }
}