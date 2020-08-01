namespace Mirai.Emitting.Metadata
{
    // 0x33
    public class LocalVariable : Table
    {
        public LocalVariable(
            uint recordIndex,
            ushort attributes,
            ushort index,
            MetadataString name) : base(recordIndex)
        {
            Attributes = attributes;
            Index = index;
            Name = name;
        }

        public override TableType TableType => TableType.LocalVariable;

        public ushort Attributes { get; }
        public ushort Index { get; }
        public MetadataString Name { get; }
    }
}