namespace Mirai.Emitting.Metadata
{
    // 0x1E
    public class ENCLog : Table
    {
       public ENCLog(uint recordIndex, uint token, uint funcCode)
            : base(recordIndex)
        {
            Token = token;
            FuncCode = funcCode;
        }

        public override TableType TableType => TableType.ENCLog;

        public uint Token { get; }
        public uint FuncCode { get; }
    }
}