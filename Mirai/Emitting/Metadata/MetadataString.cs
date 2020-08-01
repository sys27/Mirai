namespace Mirai.Emitting.Metadata
{
    public readonly struct MetadataString
    {
        public MetadataString(uint offset, string value)
        {
            Offset = offset;
            Value = value;
        }

        public static implicit operator string(MetadataString metadataString)
            => metadataString.Value;

        public uint Offset { get; }
        public string Value { get; }
    }
}