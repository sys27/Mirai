using System;

namespace Mirai.Emitting.FileFormats
{
    [Flags]
    public enum ExceptionRegionFlags : byte
    {
        /// <summary>
        /// Exception handling data.
        /// </summary>
        CorILMethod_Sect_EHTable = 0x1,
        /// <summary>
        /// Reserved, shall be 0.
        /// </summary>
        CorILMethod_Sect_OptILTable = 0x2,
        /// <summary>
        /// Data format is of the fat variety, meaning there is a 3- byte length least-significant byte first format. If not set, the header is small with a 1-byte length.
        /// </summary>
        CorILMethod_Sect_FatFormat = 0x40,
        /// <summary>
        /// Another data section occurs after this current section.
        /// </summary>
        CorILMethod_Sect_MoreSects = 0x80,
    }
}