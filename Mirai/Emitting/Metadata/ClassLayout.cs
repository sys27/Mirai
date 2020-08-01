namespace Mirai.Emitting.Metadata
{
    // 0x0F
    public class ClassLayout : Table
    {
        public ClassLayout(uint recordIndex, ushort packingSize, uint classSize, uint parent)
            : base(recordIndex)
        {
            PackingSize = packingSize;
            ClassSize = classSize;
            Parent = parent;
        }

        public override TableType TableType => TableType.ClassLayout;

        /// <summary>
        /// A 2-byte constant.
        /// </summary>
        public ushort PackingSize { get; }

        /// <summary>
        /// A 4-byte constant.
        /// </summary>
        public uint ClassSize { get; }

        /// <summary>
        /// An index into the TypeDef table.
        /// </summary>
        public uint Parent { get; } // TODO: sort column
    }
}