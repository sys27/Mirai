using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x18
    public class MethodSemantics : Table
    {
        public MethodSemantics(
            uint recordIndex,
            MethodSemanticsAttributes semantics,
            uint method,
            CodedIndex<HasSemanticsTag> association)
            : base(recordIndex)
        {
            Semantics = semantics;
            Method = method;
            Association = association;
        }

        public override TableType TableType => TableType.MethodSemantics;

        /// <summary>
        /// A 2-byte bitmask of type MethodSemanticsAttributes.
        /// </summary>
        public MethodSemanticsAttributes Semantics { get; }

        /// <summary>
        /// An index into the MethodDef table.
        /// </summary>
        public uint Method { get; }

        /// <summary>
        /// An index into the Event or Property table; more precisely, a HasSemantics coded index.
        /// </summary>
        public CodedIndex<HasSemanticsTag> Association { get; } // TODO: sort column
    }
}