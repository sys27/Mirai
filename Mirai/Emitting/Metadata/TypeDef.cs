using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x02
    public class TypeDef : Table
    {
        public TypeDef(
            uint recordIndex,
            TypeAttributes flags,
            MetadataString typeName,
            MetadataString typeNamespace,
            CodedIndex<TypeDefOrRefTag> extends,
            uint fieldList,
            uint methodList)
            : base(recordIndex)
        {
            Flags = flags;
            TypeName = typeName;
            TypeNamespace = typeNamespace;
            Extends = extends;
            FieldList = fieldList;
            MethodList = methodList;
        }

        public override TableType TableType => TableType.TypeDef;

        /// <summary>
        /// A 4-byte bitmask of type TypeAttributes.
        /// </summary>
        public TypeAttributes Flags { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString TypeName { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString TypeNamespace { get; }

        /// <summary>
        /// An index into the TypeDef, TypeRef, or TypeSpec table; more precisely, a TypeDefOrRef coded index.
        /// </summary>
        public CodedIndex<TypeDefOrRefTag> Extends { get; }

        /// <summary>
        /// An index into the Field table; it marks the first of a contiguous run of Fields owned by this Type.
        /// </summary>
        public uint FieldList { get; }

        /// <summary>
        /// An index into the MethodDef table; it marks the first of a continguous run of Methods owned by this Type.
        /// </summary>
        public uint MethodList { get; }
    }
}