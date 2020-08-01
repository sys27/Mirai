using System;

namespace Mirai.Emitting.Metadata
{
    public readonly struct MetadataGuid
    {
        public MetadataGuid(uint offset, Guid value)
        {
            Offset = offset;
            Value = value;
        }

        public static implicit operator Guid(MetadataGuid metadataGuid)
            => metadataGuid.Value;

        public uint Offset { get; }
        public Guid Value { get; }
    }
}