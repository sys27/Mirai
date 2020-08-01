namespace Mirai.Emitting.Metadata
{
    // 0x03
    public class FieldPtr : Table
    {
        public FieldPtr(uint recordIndex, uint field)
            : base(recordIndex)
        {
            Field = field;
        }

        public override TableType TableType => TableType.FieldPtr;

        public uint Field { get; }
    }
}