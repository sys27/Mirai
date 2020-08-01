namespace Mirai.Emitting.FileFormats
{
    /// <summary>
    /// The “#~” streams contain the actual physical representations of the logical metadata tables.
    /// </summary>
    public class TablesHeap : IHeap
    {
        public TablesHeap(
            StreamHeader streamHeader,
            byte majorVersion,
            byte minorVersion,
            HeapSizeFlags heapSizes,
            ulong valid,
            ulong sorted,
            TableSizes rows,
            Tables tables)
        {
            StreamHeader = streamHeader;
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            HeapSizes = heapSizes;
            Valid = valid;
            Sorted = sorted;
            Rows = rows;
            Tables = tables;
        }

        public StreamHeader StreamHeader { get; }

        /// <summary>
        /// Major version of table schemata; shall be 2.
        /// </summary>
        public byte MajorVersion { get; }

        /// <summary>
        /// Minor version of table schemata; shall be 0.
        /// </summary>
        public byte MinorVersion { get; }

        /// <summary>
        /// Bit vector for heap sizes.
        /// </summary>
        public HeapSizeFlags HeapSizes { get; }

        /// <summary>
        /// Bit vector of present tables.
        /// </summary>
        public ulong Valid { get; } // TODO: to enum flag?

        /// <summary>
        /// Bit vector of sorted tables.
        /// </summary>
        public ulong Sorted { get; }

        /// <summary>
        /// Array of n 4-byte unsigned integers indicating the number of rows for each present table.
        /// </summary>
        public TableSizes Rows { get; }

        public Tables Tables { get; }
    }
}