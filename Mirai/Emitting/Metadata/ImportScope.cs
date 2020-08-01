namespace Mirai.Emitting.Metadata
{
    // 0x35
    public class ImportScope : Table
    {
        public ImportScope(uint recordIndex, uint parent, MetadataBlob imports)
            : base(recordIndex)
        {
            Parent = parent;
            Imports = imports;
        }

        public override TableType TableType => TableType.ImportScope;

        public uint Parent { get; }
        public MetadataBlob Imports { get; }
    }
}