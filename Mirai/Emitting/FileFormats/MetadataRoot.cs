using System.Collections.Immutable;

namespace Mirai.Emitting.FileFormats
{
    public class MetadataRoot
    {
        /// <summary>
        /// 0x424A5342
        /// </summary>
        public const uint Signature = 0x424A5342;

        public MetadataRoot(
            FileOffset fileOffset,
            ushort majorVersion,
            ushort minorVersion,
            uint length,
            string version,
            ushort flags,
            ushort streams,
            ImmutableArray<StreamHeader> streamHeaders)
        {
            FileOffset = fileOffset;
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            Length = length;
            Version = version;
            Flags = flags;
            Streams = streams;
            StreamHeaders = streamHeaders;
        }

        public FileOffset FileOffset { get; }

        /// <summary>
        /// Major version.
        /// </summary>
        public ushort MajorVersion { get; }

        /// <summary>
        /// Minor version.
        /// </summary>
        public ushort MinorVersion { get; }

        /// <summary>
        /// Number of bytes allocated to hold version string (including null terminator), call this x.
        /// Call the length of the string (including the terminator) m (we require m <= 255); the length x is m rounded up to a multiple of four.
        /// </summary>
        public uint Length { get; }

        /// <summary>
        /// UTF8-encoded null-terminated version string of length m (see above).
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Reserved, always 0.
        /// </summary>
        public ushort Flags { get; }

        /// <summary>
        /// Number of streams, say n.
        /// </summary>
        public ushort Streams { get; }

        /// <summary>
        /// Array of n <see cref="StreamHeader"/> structures.
        /// </summary>
        public ImmutableArray<StreamHeader> StreamHeaders { get; }
    }
}