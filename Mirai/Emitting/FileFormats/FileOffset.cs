namespace Mirai.Emitting.FileFormats
{
    public readonly struct FileOffset
    {
        public FileOffset(uint offset)
        {
            Offset = offset;
        }

        public uint Offset { get; }
    }
}