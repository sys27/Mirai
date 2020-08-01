namespace Mirai.Emitting.FileFormats
{
    public enum Subsystem : ushort
    {
        /// <summary>
        /// Unknown subsystem.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Image doesn't require a subsystem.
        /// </summary>
        Native = 1,

        /// <summary>
        /// Image runs in the Windows GUI subsystem.
        /// </summary>
        WindowsGui = 2,

        /// <summary>
        /// Image runs in the Windows character subsystem.
        /// </summary>
        WindowsCui = 3,

        /// <summary>
        /// image runs in the OS/2 character subsystem.
        /// </summary>
        OS2Cui = 5,

        /// <summary>
        /// image runs in the Posix character subsystem.
        /// </summary>
        PosixCui = 7,

        /// <summary>
        /// image is a native Win9x driver.
        /// </summary>
        NativeWindows = 8,

        /// <summary>
        /// Image runs in the Windows CE subsystem.
        /// </summary>
        WindowsCEGui = 9,

        /// <summary>
        /// Extensible Firmware Interface (EFI) application.
        /// </summary>
        EfiApplication = 10,

        /// <summary>
        /// EFI driver with boot services.
        /// </summary>
        EfiBootServiceDriver = 11,

        /// <summary>
        /// EFI driver with run-time services.
        /// </summary>
        EfiRuntimeDriver = 12,

        /// <summary>
        /// EFI ROM image.
        /// </summary>
        EfiRom = 13,

        /// <summary>
        /// XBox system.
        /// </summary>
        Xbox = 14,

        /// <summary>
        /// Boot application.
        /// </summary>
        WindowsBootApplication = 16
    }
}