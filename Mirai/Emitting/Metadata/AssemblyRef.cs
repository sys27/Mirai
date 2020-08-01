namespace Mirai.Emitting.Metadata
{
    // 0x23
    // remove?
    public class AssemblyRef : Table
    {
        public AssemblyRef(
            uint recordIndex,
            AssemblyVersion version,
            AssemblyFlags flags,
            MetadataBlob publicKeyOrToken,
            MetadataString name,
            MetadataString culture,
            MetadataBlob hashValue)
            : base(recordIndex)
        {
            Version = version;
            Flags = flags;
            PublicKeyOrToken = publicKeyOrToken;
            Name = name;
            Culture = culture;
            HashValue = hashValue;
        }

        public override TableType TableType => TableType.AssemblyRef;

        /// <summary>
        /// A 8-byte constants.
        /// </summary>
        public AssemblyVersion Version { get; }

        /// <summary>
        /// A 4-byte bitmask of type AssemblyFlag.
        /// </summary>
        public AssemblyFlags Flags { get; } // TODO: should be only PublicKey Flag

        /// <summary>
        /// An index into the Blob heap, indicating the public key or token that identifies the author of this Assembly.
        /// </summary>
        public MetadataBlob PublicKeyOrToken { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Name { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Culture { get; }

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataBlob HashValue { get; }
    }
}