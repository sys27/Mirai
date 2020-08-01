namespace Mirai.Emitting.Metadata
{
    // 0x1A
    public class ModuleRef : Table
    {
        public ModuleRef(uint recordIndex, MetadataString name)
            : base(recordIndex)
        {
            Name = name;
        }

        public override TableType TableType => TableType.ModuleRef;

        public MetadataString Name { get; }
    }
}