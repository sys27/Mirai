namespace Mirai.Emitting.FileFormats
{
    public readonly struct DirectoryEntries
    {
        public DirectoryEntries(
            DirectoryEntry exportTableDirectory,
            DirectoryEntry importTableDirectory,
            DirectoryEntry resourceTableDirectory,
            DirectoryEntry exceptionTableDirectory,
            DirectoryEntry certificateTableDirectory,
            DirectoryEntry baseRelocationTableDirectory,
            DirectoryEntry debugTableDirectory,
            DirectoryEntry copyrightTableDirectory,
            DirectoryEntry globalPointerTableDirectory,
            DirectoryEntry threadLocalStorageTableDirectory,
            DirectoryEntry loadConfigTableDirectory,
            DirectoryEntry boundImportTableDirectory,
            DirectoryEntry importAddressTableDirectory,
            DirectoryEntry delayImportTableDirectory,
            DirectoryEntry corHeaderTableDirectory)
        {
            ExportTableDirectory = exportTableDirectory;
            ImportTableDirectory = importTableDirectory;
            ResourceTableDirectory = resourceTableDirectory;
            ExceptionTableDirectory = exceptionTableDirectory;
            CertificateTableDirectory = certificateTableDirectory;
            BaseRelocationTableDirectory = baseRelocationTableDirectory;
            DebugTableDirectory = debugTableDirectory;
            CopyrightTableDirectory = copyrightTableDirectory;
            GlobalPointerTableDirectory = globalPointerTableDirectory;
            ThreadLocalStorageTableDirectory = threadLocalStorageTableDirectory;
            LoadConfigTableDirectory = loadConfigTableDirectory;
            BoundImportTableDirectory = boundImportTableDirectory;
            ImportAddressTableDirectory = importAddressTableDirectory;
            DelayImportTableDirectory = delayImportTableDirectory;
            CorHeaderTableDirectory = corHeaderTableDirectory;
        }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_EXPORT.
        /// </remarks>
        public DirectoryEntry ExportTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_IMPORT.
        /// </remarks>
        public DirectoryEntry ImportTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_RESOURCE.
        /// </remarks>
        public DirectoryEntry ResourceTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_EXCEPTION.
        /// </remarks>
        public DirectoryEntry ExceptionTableDirectory { get; }

        /// <summary>
        /// The Certificate Table entry points to a table of attribute certificates.
        /// </summary>
        /// <remarks>
        /// These certificates are not loaded into memory as part of the image.
        /// As such, the first field of this entry, which is normally an RVA, is a file pointer instead.
        ///
        /// Aka IMAGE_DIRECTORY_ENTRY_SECURITY.
        /// </remarks>
        public DirectoryEntry CertificateTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_BASERELOC.
        /// </remarks>
        public DirectoryEntry BaseRelocationTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_DEBUG.
        /// </remarks>
        public DirectoryEntry DebugTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_COPYRIGHT or IMAGE_DIRECTORY_ENTRY_ARCHITECTURE.
        /// </remarks>
        public DirectoryEntry CopyrightTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_GLOBALPTR.
        /// </remarks>
        public DirectoryEntry GlobalPointerTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_TLS.
        /// </remarks>
        public DirectoryEntry ThreadLocalStorageTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG.
        /// </remarks>
        public DirectoryEntry LoadConfigTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT.
        /// </remarks>
        public DirectoryEntry BoundImportTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_IAT.
        /// </remarks>
        public DirectoryEntry ImportAddressTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT.
        /// </remarks>
        public DirectoryEntry DelayImportTableDirectory { get; }

        /// <remarks>
        /// Aka IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR.
        /// </remarks>
        public DirectoryEntry CorHeaderTableDirectory { get; }
    }
}