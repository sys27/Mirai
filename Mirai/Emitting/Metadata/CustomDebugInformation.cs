namespace Mirai.Emitting.Metadata
{
    // 0x37
    public class CustomDebugInformation : Table
    {
        public CustomDebugInformation(
            uint recordIndex,
            uint parent,
            MetadataGuid kind,
            MetadataString value)
            : base(recordIndex)
        {
            Parent = parent;
            Kind = kind;
            Value = value;
        }

        public override TableType TableType => TableType.CustomDebugInformation;

        public uint Parent { get; }
        public MetadataGuid Kind { get; }
        public MetadataString Value { get; }
    }
}