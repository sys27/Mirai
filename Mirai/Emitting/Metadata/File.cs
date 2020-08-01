namespace Mirai.Emitting.Metadata
{
    // 0x26
    public class File : Table
    {
        public File(uint recordIndex, FileAttributes flags, MetadataString name, MetadataBlob hashValue)
            : base(recordIndex)
        {
            Flags = flags;
            Name = name;
            HashValue = hashValue;
        }

        public override TableType TableType => TableType.File;

        public FileAttributes Flags { get; }
        public MetadataString Name { get; }
        public MetadataBlob HashValue { get; }
    }
}