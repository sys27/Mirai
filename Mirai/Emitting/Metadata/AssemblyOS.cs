namespace Mirai.Emitting.Metadata
{
    // 0x22
    // TODO: ignored by CLI, remove?
    public class AssemblyOS : Table
    {
        public AssemblyOS(
            uint recordIndex,
            uint osPlatformId,
            uint osMajorVersion,
            uint osMinorVersion)
            : base(recordIndex)
        {
            OSPlatformID = osPlatformId;
            OSMajorVersion = osMajorVersion;
            OSMinorVersion = osMinorVersion;
        }

        public override TableType TableType => TableType.AssemblyOS;

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint OSPlatformID { get; }

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint OSMajorVersion { get; }

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint OSMinorVersion { get; }
    }
}