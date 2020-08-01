namespace Mirai.Emitting.Metadata
{
    public readonly struct MetadataBlob
    {
        public MetadataBlob(uint offset, byte[] value)
        {
            Offset = offset;
            Value = value;
        }

        public static implicit operator byte[](MetadataBlob metadataBlob)
            => metadataBlob.Value;

        public uint Offset { get; }
        public byte[] Value { get; }
    }
}