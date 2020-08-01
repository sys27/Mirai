namespace Mirai.Emitting.Metadata
{
    // 0x04
    public class Field : Table
    {
        public Field(
            uint recordIndex,
            FieldAttributes flags,
            MetadataString name,
            MetadataSignature signature)
            : base(recordIndex)
        {
            Flags = flags;
            Name = name;
            Signature = signature;
        }

        public override TableType TableType => TableType.Field;

        public FieldAttributes Flags { get; }
        public MetadataString Name { get; }
        public MetadataSignature Signature { get; }
    }
}