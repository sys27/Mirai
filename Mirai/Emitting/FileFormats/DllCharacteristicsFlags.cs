using System;

namespace Mirai.Emitting.FileFormats
{
    [Flags]
    public enum DllCharacteristicsFlags : ushort
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        ProcessInit = 0x0001,

        /// <summary>
        /// Reserved.
        /// </summary>
        ProcessTerm = 0x0002,

        /// <summary>
        /// Reserved.
        /// </summary>
        ThreadInit = 0x0004,

        /// <summary>
        /// Reserved.
        /// </summary>
        ThreadTerm = 0x0008,

        /// <summary>
        /// Image can handle a high entropy 64-bit virtual address space.
        /// </summary>
        HighEntropyVirtualAddressSpace = 0x0020,

        /// <summary>
        /// DLL can move.
        /// </summary>
        DynamicBase = 0x0040,

        /// <summary>
        /// Code Integrity checks are enforced.
        /// </summary>
        ForceIntegrity = 0x0080,

        /// <summary>
        /// Image is NX compatible.
        /// </summary>
        NxCompatible = 0x0100,

        /// <summary>
        /// Image understands isolation and doesn't want it.
        /// </summary>
        NoIsolation = 0x0200,

        /// <summary>
        /// Image does not use SEH.  No SE handler may reside in this image.
        /// </summary>
        NoSeh = 0x0400,

        /// <summary>
        /// Do not bind this image.
        /// </summary>
        NoBind = 0x0800,

        /// <summary>
        /// The image must run inside an AppContainer.
        /// </summary>
        AppContainer = 0x1000,

        /// <summary>
        /// Driver uses WDM model.
        /// </summary>
        WdmDriver = 0x2000,

        /// <summary>
        /// Image supports Control Flow Guard.
        /// </summary>
        GuardControlFlow = 0x4000,

        /// <summary>
        /// Terminal Server aware.
        /// </summary>
        TerminalServerAware = 0x8000,
    }
}