namespace Mirai.Emitting.Metadata
{
    // 0x29
    public class NestedClass : Table
    {
        public NestedClass(uint recordIndex, uint nestedClass, uint enclosingClass)
            : base(recordIndex)
        {
            NestedClass_ = nestedClass;
            EnclosingClass = enclosingClass;
        }

        public override TableType TableType => TableType.NestedClass;

        /// <summary>
        /// An index into the TypeDef table.
        /// </summary>
        public uint NestedClass_ { get; } // TODO: sort column

        /// <summary>
        /// An index into the TypeDef table.
        /// </summary>
        public uint EnclosingClass { get; }
    }
}