namespace Mirai.Emitting.Metadata
{
    // 0x24
    // TODO: remove?
    public class AssemblyRefProcessor : Table
    {
        public AssemblyRefProcessor(uint recordIndex, uint processor, uint assemblyRef)
            : base(recordIndex)
        {
            Processor = processor;
            AssemblyRef = assemblyRef;
        }

        public override TableType TableType => TableType.AssemblyRefProcessor;

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint Processor { get; }

        /// <summary>
        /// An index into the AssemblyRef table.
        /// </summary>
        public uint AssemblyRef { get; }
    }
}