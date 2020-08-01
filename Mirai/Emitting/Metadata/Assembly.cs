namespace Mirai.Emitting.Metadata
{
    // 0x20
    public class Assembly : Table
    {
        public Assembly(
            uint recordIndex,
            AssemblyHashAlgorithm hashAlgId,
            AssemblyVersion version,
            AssemblyFlags flags,
            MetadataBlob publicKey,
            MetadataString name,
            MetadataString culture)
            : base(recordIndex)
        {
            HashAlgId = hashAlgId;
            Version = version;
            Flags = flags;
            PublicKey = publicKey;
            Name = name;
            Culture = culture;
        }

        public override TableType TableType => TableType.Assembly;

        /// <summary>
        /// A 4-byte constant of type AssemblyHashAlgorithm.
        /// </summary>
        public AssemblyHashAlgorithm HashAlgId { get; }

        /// <summary>
        /// A 8-byte constant.
        /// </summary>
        public AssemblyVersion Version { get; }

        /// <summary>
        /// A 4-byte bitmask of type AssemblyFlags.
        /// </summary>
        public AssemblyFlags Flags { get; }

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataBlob PublicKey { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Name { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Culture { get; }
    }
}