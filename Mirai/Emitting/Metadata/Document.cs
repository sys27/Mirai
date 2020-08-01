namespace Mirai.Emitting.Metadata
{
    // 0x30
    public class Document : Table
    {
        public Document(
            uint recordIndex,
            MetadataString name,
            MetadataGuid hashAlgorithm,
            MetadataBlob hash,
            MetadataBlob language)
            : base(recordIndex)
        {
            Name = name;
            HashAlgorithm = hashAlgorithm;
            Hash = hash;
            Language = language;
        }

        public override TableType TableType => TableType.Document;

        public MetadataString Name { get; }
        public MetadataGuid HashAlgorithm { get; }
        public MetadataBlob Hash { get; }
        public MetadataBlob Language { get; }
    }
}