namespace Mirai.Emitting.Metadata
{
    // 0x05
    public class MethodPtr : Table
    {
        public MethodPtr(uint recordIndex, uint method)
            : base(recordIndex)
        {
            Method = method;
        }

        public override TableType TableType => TableType.MethodPtr;

        public uint Method { get; }
    }
}