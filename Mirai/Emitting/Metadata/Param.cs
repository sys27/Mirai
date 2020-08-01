namespace Mirai.Emitting.Metadata
{
    // 0x08
    public class Param : Table
    {
        public Param(
            uint recordIndex,
            ParamAttributes flags,
            ushort sequence,
            MetadataString name)
            : base(recordIndex)
        {
            Flags = flags;
            Sequence = sequence;
            Name = name;
        }

        public override TableType TableType => TableType.Param;

        public ParamAttributes Flags { get; }
        public ushort Sequence { get; }
        public MetadataString Name { get; }
    }
}