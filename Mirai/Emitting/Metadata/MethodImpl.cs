using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x19
    public class MethodImpl : Table
    {
        public MethodImpl(
            uint recordIndex,
            uint @class,
            CodedIndex<MethodDefOrRefTag> methodBody,
            CodedIndex<MethodDefOrRefTag> methodDeclaration)
            : base(recordIndex)
        {
            Class = @class;
            MethodBody = methodBody;
            MethodDeclaration = methodDeclaration;
        }

        public override TableType TableType => TableType.MethodImpl;

        /// <summary>
        /// An index into the TypeDef table.
        /// </summary>
        public uint Class { get; } // TODO: sort column

        /// <summary>
        /// An index into the MethodDef or MemberRef table; more precisely, a MethodDefOrRef coded index.
        /// </summary>
        public CodedIndex<MethodDefOrRefTag> MethodBody { get; }

        /// <summary>
        /// An index into the MethodDef or MemberRef table; more precisely, a MethodDefOrRef coded index
        /// </summary>
        public CodedIndex<MethodDefOrRefTag> MethodDeclaration { get; }
    }
}