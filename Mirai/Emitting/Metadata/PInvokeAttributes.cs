using System;

namespace Mirai.Emitting.Metadata
{
    [Flags]
    public enum PInvokeAttributes : ushort
    {
        /// <summary>
        /// PInvoke is to use the member name as specified.
        /// </summary>
        NoMangle = 0x0001,

        /// <summary>
        /// This is a resource file or other non-metadata-containing file. These 2 bits contain one of the following values:
        /// </summary>
        CharSetMask = 0x0006,
        CharSetNotSpec = 0x0000,
        CharSetAnsi = 0x0002,
        CharSetUnicode = 0x0004,
        CharSetAuto = 0x0006,

        /// <summary>
        /// Information about target function. Not relevant for fields.
        /// </summary>
        SupportsLastError = 0x0040,

        /// <summary>
        /// These 3 bits contain one of the following values:
        /// </summary>
        CallConvMask = 0x0700,
        CallConvPlatformapi = 0x0100,
        CallConvCdecl = 0x0200,
        CallConvStdcall = 0x0300,
        CallConvThiscall = 0x0400,
        CallConvFastcall = 0x0500,
    }
}