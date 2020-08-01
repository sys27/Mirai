using System;

namespace Mirai.Emitting.FileFormats
{
    [Flags]
    public enum CorFlags : uint
    {
        /// <summary>
        /// Shall be 1.
        /// </summary>
        ILOnly = 0x00000001,

        /// <summary>
        /// Image can only be loaded into a 32-bit process, for instance if there are 32-bit vtablefixups, or casts from native integers to int32. CLI implementations that have 64-bit native integers shall refuse loading binaries with this flag set.
        /// </summary>
        Requires32Bit = 0x00000002,
        ILLibrary = 0x00000004,

        /// <summary>
        /// Image has a strong name signature.
        /// </summary>
        StrongNameSigned = 0x00000008,

        /// <summary>
        /// Shall be 0.
        /// </summary>
        NativeEntryPoint = 0x00000010,

        /// <summary>
        /// Should be 0.
        /// </summary>
        TrackDebugData = 0x00010000,
        Prefers32Bit = 0x00020000,
    }
}