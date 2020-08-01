using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata
{
    // 0x14
    public class Event : Table
    {
        public Event(
            uint recordIndex,
            EventAttributes eventFlags,
            MetadataString name,
            CodedIndex<TypeDefOrRefTag> eventType)
            : base(recordIndex)
        {
            EventFlags = eventFlags;
            Name = name;
            EventType = eventType;
        }

        public override TableType TableType => TableType.Event;

        /// <summary>
        /// A 2-byte bitmask of type EventAttributes.
        /// </summary>
        public EventAttributes EventFlags { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Name { get; }

        /// <summary>
        /// An index into a TypeDef, a TypeRef, or TypeSpec table; more precisely, a TypeDefOrRef coded index.
        /// </summary>
        public CodedIndex<TypeDefOrRefTag> EventType { get; }
    }
}