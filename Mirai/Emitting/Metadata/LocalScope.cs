namespace Mirai.Emitting.Metadata
{
    // 0x32
    public class LocalScope : Table
    {
        public LocalScope(
            uint recordIndex,
            uint method,
            uint importScope,
            uint variableList,
            uint constantList,
            uint startOffset,
            uint length)
            : base(recordIndex)
        {
            Method = method;
            ImportScope = importScope;
            VariableList = variableList;
            ConstantList = constantList;
            StartOffset = startOffset;
            Length = length;
        }

        public override TableType TableType => TableType.LocalScope;

        public uint Method { get; }
        public uint ImportScope { get; }
        public uint VariableList { get; }
        public uint ConstantList { get; }
        public uint StartOffset { get; }
        public uint Length { get; }
    }
}