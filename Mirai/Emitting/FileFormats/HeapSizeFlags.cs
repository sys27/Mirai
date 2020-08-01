using System;

namespace Mirai.Emitting.FileFormats
{
    [Flags]
    public enum HeapSizeFlags : byte
    {
        /// <summary>
        /// If bit 0 is set, indexes into the “#String” heap are 4 bytes wide.
        /// </summary>
        BigString = 0x01,

        /// <summary>
        /// If bit 1 is set, indexes into the “#GUID” heap are 4 bytes wide.
        /// </summary>
        BigGuid = 0x02,

        /// <summary>
        /// If bit 2 is set, indexes into the “#Blob” heap are 4 bytes wide.
        /// </summary>
        BigBlob = 0x04,
    }
}