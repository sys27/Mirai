using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x0A
    public class MemberRef : Table
    {
        public MemberRef(
            uint recordIndex,
            CodedIndex<MemberRefParentTag> @class,
            MetadataString name,
            MetadataSignature signature)
            : base(recordIndex)
        {
            Class = @class;
            Name = name;
            Signature = signature;
        }

        public override TableType TableType => TableType.MemberRef;

        /// <summary>
        /// An index into the MethodDef, ModuleRef,TypeDef, TypeRef, or TypeSpec tables; more precisely, a MemberRefParent coded index.
        /// </summary>
        public CodedIndex<MemberRefParentTag> Class { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Name { get; }

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataSignature Signature { get; }
    }
}