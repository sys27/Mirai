namespace Mirai.Emitting.Metadata
{
    // 0x25
    // TODO: remove?
    public class AssemblyRefOS : Table
    {
        public AssemblyRefOS(
            uint recordIndex,
            uint osPlatformId,
            uint osMajorVersion,
            uint osMinorVersion,
            uint assemblyRef)
            : base(recordIndex)
        {
            OSPlatformId = osPlatformId;
            OSMajorVersion = osMajorVersion;
            OSMinorVersion = osMinorVersion;
            AssemblyRef = assemblyRef;
        }

        public override TableType TableType => TableType.AssemblyRefOS;

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint OSPlatformId { get; }

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint OSMajorVersion { get; }

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint OSMinorVersion { get; }

        /// <summary>
        /// An index into the AssemblyRef table.
        /// </summary>
        public uint AssemblyRef { get; }
    }
}