namespace Mirai.Emitting.Metadata
{
    // 0x17
    public class Property : Table
    {
        public Property(
            uint recordIndex,
            PropertyAttributes flags,
            MetadataString name,
            MetadataBlob type)
            : base(recordIndex)
        {
            Flags = flags;
            Name = name;
            Type = type;
        }

        public override TableType TableType => TableType.Property;

        public PropertyAttributes Flags { get; }
        public MetadataString Name { get; }
        public MetadataBlob Type { get; }
    }
}