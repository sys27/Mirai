namespace Mirai.Emitting.Metadata
{
    public readonly struct AssemblyVersion
    {
        public AssemblyVersion(
            ushort majorVersion,
            ushort minorVersion,
            ushort buildNumber,
            ushort revisionNumber)
        {
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            BuildNumber = buildNumber;
            RevisionNumber = revisionNumber;
        }

        public ushort MajorVersion { get; }
        public ushort MinorVersion { get; }
        public ushort BuildNumber { get; }
        public ushort RevisionNumber { get; }
    }
}