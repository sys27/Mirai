namespace Mirai.Emitting.Metadata
{
    // 0x07
    public class ParamPtr : Table
    {
        public ParamPtr(uint recordIndex, uint param)
            : base(recordIndex)
        {
            Param = param;
        }

        public override TableType TableType => TableType.ParamPtr;

        public uint Param { get; }
    }
}