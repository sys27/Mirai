namespace Mirai.Emitting.Metadata
{
    // 0x10
    public class FieldLayout : Table
    {
        public FieldLayout(uint recordIndex, uint offset, uint field)
            : base(recordIndex)
        {
            Offset = offset;
            Field = field;
        }

        public override TableType TableType => TableType.FieldLayout;

        public uint Offset { get; }
        public uint Field { get; } // TODO: sort column
    }
}