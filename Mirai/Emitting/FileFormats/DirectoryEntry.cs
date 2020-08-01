namespace Mirai.Emitting.FileFormats
{
    public readonly struct DirectoryEntry
    {
        public DirectoryEntry(uint relativeVirtualAddress, uint size)
        {
            RelativeVirtualAddress = relativeVirtualAddress;
            Size = size;
        }

        public uint RelativeVirtualAddress { get; }
        public uint Size { get; }
    }
}