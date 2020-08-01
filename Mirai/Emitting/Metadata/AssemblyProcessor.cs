namespace Mirai.Emitting.Metadata
{
    // 0x21
    // TODO: ignored by CLI, remove?
    public class AssemblyProcessor : Table
    {
        public AssemblyProcessor(uint recordIndex, uint processor) : base(recordIndex)
        {
            Processor = processor;
        }

        public override TableType TableType => TableType.AssemblyProcessor;

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint Processor { get; }
    }
}