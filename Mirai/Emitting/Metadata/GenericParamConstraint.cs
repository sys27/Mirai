using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x2C
    public class GenericParamConstraint : Table
    {
        public GenericParamConstraint(
            uint recordIndex,
            uint owner,
            CodedIndex<TypeDefOrRefTag> constraint)
            : base(recordIndex)
        {
            Owner = owner;
            Constraint = constraint;
        }

        public override TableType TableType => TableType.GenericParamConstraint;

        /// <summary>
        /// An index into the GenericParam table, specifying to which generic parameter this row refers.
        /// </summary>
        public uint Owner { get; } // TODO: sort column

        /// <summary>
        /// An index into the TypeDef, TypeRef, or TypeSpec tables, specifying from which class this generic parameter is constrained to derive; or which interface this generic parameter is constrained to implement; more precisely, a TypeDefOrRef coded index.
        /// </summary>
        public CodedIndex<TypeDefOrRefTag> Constraint { get; }
    }
}