using System;

namespace Mirai.Emitting.FileFormats
{
    [Flags]
    public enum CharacteristicsFlags : ushort
    {
        /// <summary>
        /// Relocation info stripped from file.
        /// </summary>
        RelocsStripped = 0x0001,

        /// <summary>
        /// File is executable  (i.e. no unresolved external references).
        /// </summary>
        ExecutableImage = 0x0002,

        /// <summary>
        /// Line numbers stripped from file.
        /// </summary>
        LineNumsStripped = 0x0004,

        /// <summary>
        /// Local symbols stripped from file.
        /// </summary>
        LocalSymsStripped = 0x0008,

        /// <summary>
        /// Aggressively trim working set.
        /// </summary>
        AggressiveWSTrim = 0x0010,

        /// <summary>
        /// App can handle >2gb addresses.
        /// </summary>
        LargeAddressAware = 0x0020,

        /// <summary>
        /// Bytes of machine word are reversed.
        /// </summary>
        BytesReversedLo = 0x0080,

        /// <summary>
        /// 32 bit word machine.
        /// </summary>
        Bit32Machine = 0x0100,

        /// <summary>
        /// Debugging info stripped from file in .DBG file.
        /// </summary>
        DebugStripped = 0x0200,

        /// <summary>
        /// If Image is on removable media, copy and run from the swap file.
        /// </summary>
        RemovableRunFromSwap = 0x0400,

        /// <summary>
        /// If Image is on Net, copy and run from the swap file.
        /// </summary>
        NetRunFromSwap = 0x0800,

        /// <summary>
        /// System File.
        /// </summary>
        System = 0x1000,

        /// <summary>
        /// File is a DLL.
        /// </summary>
        Dll = 0x2000,

        /// <summary>
        /// File should only be run on a UP machine
        /// </summary>
        UpSystemOnly = 0x4000,

        /// <summary>
        /// Bytes of machine word are reversed.
        /// </summary>
        BytesReversedHi = 0x8000,
    }
}