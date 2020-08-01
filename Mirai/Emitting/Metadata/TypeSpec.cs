namespace Mirai.Emitting.Metadata
{
    // 0x1B
    public class TypeSpec : Table
    {
        public TypeSpec(uint recordIndex, MetadataTypeSpec signature)
            : base(recordIndex)
        {
            Signature = signature;
        }

        public override TableType TableType => TableType.TypeSpec;

        public MetadataTypeSpec Signature { get; }
    }
}