namespace Mirai.Emitting.FileFormats
{
    public class StreamHeader
    {
        public const string TablesName = "#~";
        public const string StringsName = "#Strings";
        public const string UserStringsName = "#US";
        public const string GuidName = "#GUID";
        public const string BlobName = "#Blob";

        public StreamHeader(uint offset, uint size, string name)
        {
            Offset = offset;
            Size = size;
            Name = name;
        }

        /// <summary>
        /// Memory offset to start of this stream from start of the metadata root.
        /// </summary>
        public uint Offset { get; }

        /// <summary>
        /// Size of this stream in bytes, shall be a multiple of 4.
        /// </summary>
        public uint Size { get; }

        /// <summary>
        /// Name of the stream as null-terminated variable length array of ASCII characters, padded to the next 4-byte boundary with \0 characters. The name is limited to 32 characters.
        /// </summary>
        public string Name { get; }
    }
}