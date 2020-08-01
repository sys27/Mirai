namespace Mirai.Emitting.Metadata
{
    // 0x16
    public class PropertyPtr : Table
    {
        public PropertyPtr(uint recordIndex, uint property)
            : base(recordIndex)
        {
            Property = property;
        }

        public override TableType TableType => TableType.PropertyPtr;

        public uint Property { get; }
    }
}