namespace Mirai.Emitting.Metadata
{
    // 0x1F
    public class ENCMap : Table
    {
        public ENCMap(uint recordIndex, uint token)
            : base(recordIndex)
        {
            Token = token;
        }

        public override TableType TableType => TableType.ENCMap;

        public uint Token { get; }
    }
}