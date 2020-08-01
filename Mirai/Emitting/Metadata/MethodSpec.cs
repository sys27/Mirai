using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x2B
    public class MethodSpec : Table
    {
        public MethodSpec(
            uint recordIndex,
            CodedIndex<MethodDefOrRefTag> method,
            MetadataBlob instantiation)
            : base(recordIndex)
        {
            Method = method;
            Instantiation = instantiation;
        }

        public override TableType TableType => TableType.MethodSpec;

        /// <summary>
        /// An index into the MethodDef or MemberRef table, specifying to which generic method this row refers; that is, which generic method this row is an instantiation of; more precisely, a MethodDefOrRef coded index.
        /// </summary>
        public CodedIndex<MethodDefOrRefTag> Method { get; }

        /// <summary>
        /// An index into the Blob heap, holding the signature of this instantiation.
        /// </summary>
        public MetadataBlob Instantiation { get; }
    }
}