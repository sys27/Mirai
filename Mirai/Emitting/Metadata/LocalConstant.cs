namespace Mirai.Emitting.Metadata
{
    // 0x34
    public class LocalConstant : Table
    {
        public LocalConstant(uint recordIndex, MetadataString name, MetadataSignature signature)
            : base(recordIndex)
        {
            Name = name;
            Signature = signature;
        }

        public override TableType TableType => TableType.LocalConstant;

        public MetadataString Name { get; }
        public MetadataSignature Signature { get; }
    }
}