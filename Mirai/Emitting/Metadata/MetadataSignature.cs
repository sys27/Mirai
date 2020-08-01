using Mirai.Emitting.Metadata.Signatures;

namespace Mirai.Emitting.Metadata
{
    public readonly struct MetadataSignature
    {
        public MetadataSignature(uint offset, Signature signature)
        {
            Offset = offset;
            Signature = signature;
        }

        public uint Offset { get; }
        public Signature Signature { get; }
    }
}