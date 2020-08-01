namespace Mirai.Emitting.FileFormats
{
    public enum HeapSizes : byte
    {
        /// <summary>
        /// 4 byte uint indexes used for string heap offsets.
        /// </summary>
        StringHeapLarge = 0x01,

        /// <summary>
        /// 4 byte uint indexes used for GUID heap offsets.
        /// </summary>
        GuidHeapLarge = 0x02,

        /// <summary>
        /// 4 byte uint indexes used for Blob heap offsets
        /// </summary>
        BlobHeapLarge = 0x04,

        /// <summary>
        /// Indicates that there is an extra 4 bytes of data immediately after the row counts.
        /// </summary>
        ExtraData = 0x40,
    }
}