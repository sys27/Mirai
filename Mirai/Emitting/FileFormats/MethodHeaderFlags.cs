using System;

namespace Mirai.Emitting.FileFormats
{
    [Flags]
    public enum MethodHeaderFlags
    {
        /// <summary>
        /// Method header is fat.
        /// </summary>
        CorILMethod_TinyFormat = 0x2,

        /// <summary>
        /// Method header is tiny.
        /// </summary>
        CorILMethod_FatFormat = 0x3,

        /// <summary>
        /// More sections follow after this header.
        /// </summary>
        CorILMethod_MoreSects = 0x8,

        /// <summary>
        /// Call default constructor on all local variables.
        /// </summary>
        CorILMethod_InitLocals = 0x10,
    }
}