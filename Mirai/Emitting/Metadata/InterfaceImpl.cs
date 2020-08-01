using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x09
    public class InterfaceImpl : Table
    {
        public InterfaceImpl(uint recordIndex, uint @class, CodedIndex<TypeDefOrRefTag> @interface)
            : base(recordIndex)
        {
            Class = @class;
            Interface = @interface;
        }

        public override TableType TableType => TableType.InterfaceImpl;

        /// <summary>
        /// An index into the TypeDef table.
        /// </summary>
        public uint Class { get; } // TODO: sort column

        /// <summary>
        /// An index into the TypeDef, TypeRef, or TypeSpec table; more precisely, a TypeDefOrRef coded index.
        /// </summary>
        public CodedIndex<TypeDefOrRefTag> Interface { get; } // TODO: second sort column
    }
}