namespace Mirai.Emitting.Metadata
{
    // 0x1D
    public class FieldRVA : Table
    {
        public FieldRVA(uint recordIndex, uint rva, uint field)
            : base(recordIndex)
        {
            RVA = rva;
            Field = field;
        }

        public override TableType TableType => TableType.FieldRVA;

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint RVA { get; }

        /// <summary>
        /// An index into Field table.
        /// </summary>
        public uint Field { get; } // TODO: sort column
    }
}