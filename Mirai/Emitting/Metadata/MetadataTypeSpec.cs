using Mirai.Emitting.Metadata.Signatures;

namespace Mirai.Emitting.Metadata
{
    public readonly struct MetadataTypeSpec
    {
        public MetadataTypeSpec(uint offset, Type type)
        {
            Offset = offset;
            Type = type;
        }

        public uint Offset { get; }
        public Type Type { get; }
    }
}