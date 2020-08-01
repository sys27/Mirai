using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x2A
    public class GenericParam : Table
    {
        public GenericParam(
            uint recordIndex,
            ushort number,
            GenericParamAttributes flags,
            CodedIndex<TypeOrMethodDefTag> owner,
            MetadataString name)
            : base(recordIndex)
        {
            Number = number;
            Flags = flags;
            Owner = owner;
            Name = name;
        }

        public override TableType TableType => TableType.GenericParam;

        /// <summary>
        /// The 2-byte index of the generic parameter, numbered left-to-right, from zero.
        /// </summary>
        public ushort Number { get; } // TODO: second sort key

        /// <summary>
        /// A 2-byte bitmask of type GenericParamAttributes.
        /// </summary>
        public GenericParamAttributes Flags { get; }

        /// <summary>
        /// An index into the TypeDef or MethodDef table, specifying the Type or Method to which this generic parameter applies; more precisely, a TypeOrMethodDef coded index.
        /// </summary>
        public CodedIndex<TypeOrMethodDefTag> Owner { get; } // TODO: sort column

        /// <summary>
        /// A non-null index into the String heap, giving the name for the generic parameter. This is purely descriptive and is used only by source language compilers and by Reflection.
        /// </summary>
        public MetadataString Name { get; }
    }
}