using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x0E
    public class DeclSecurity : Table
    {
        public DeclSecurity(
            uint recordIndex,
            ushort action,
            CodedIndex<HasDeclSecurityTag> parent,
            MetadataBlob permissionSet)
            : base(recordIndex)
        {
            Action = action;
            Parent = parent;
            PermissionSet = permissionSet;
        }

        public override TableType TableType => TableType.DeclSecurity;

        /// <summary>
        /// A 2-byte value.
        /// </summary>
        public ushort Action { get; }

        /// <summary>
        /// An index into the TypeDef, MethodDef, or Assembly table; more precisely, a HasDeclSecurity coded index.
        /// </summary>
        public CodedIndex<HasDeclSecurityTag> Parent { get; } // TODO: sort column

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataBlob PermissionSet { get; }
    }
}