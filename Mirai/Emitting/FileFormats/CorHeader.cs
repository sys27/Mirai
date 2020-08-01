namespace Mirai.Emitting.FileFormats
{
    public class CorHeader
    {
        public CorHeader(
            uint cb,
            ushort majorRuntimeVersion,
            ushort minorRuntimeVersion,
            DirectoryEntry metadataDirectory,
            CorFlags flags,
            int entryPointTokenOrRelativeVirtualAddress,
            DirectoryEntry resourcesDirectory,
            DirectoryEntry strongNameSignatureDirectory,
            DirectoryEntry codeManagerTableDirectory,
            DirectoryEntry vtableFixupsDirectory,
            DirectoryEntry exportAddressTableJumpsDirectory,
            DirectoryEntry managedNativeHeaderDirectory)
        {
            Cb = cb;
            MajorRuntimeVersion = majorRuntimeVersion;
            MinorRuntimeVersion = minorRuntimeVersion;
            MetadataDirectory = metadataDirectory;
            Flags = flags;
            EntryPointTokenOrRelativeVirtualAddress = entryPointTokenOrRelativeVirtualAddress;
            ResourcesDirectory = resourcesDirectory;
            StrongNameSignatureDirectory = strongNameSignatureDirectory;
            CodeManagerTableDirectory = codeManagerTableDirectory;
            VtableFixupsDirectory = vtableFixupsDirectory;
            ExportAddressTableJumpsDirectory = exportAddressTableJumpsDirectory;
            ManagedNativeHeaderDirectory = managedNativeHeaderDirectory;
        }

        /// <summary>
        /// Size of the header in bytes.
        /// </summary>
        public uint Cb { get; }

        /// <summary>
        /// The minimum version of the runtime required to run this program, currently 2.
        /// </summary>
        public ushort MajorRuntimeVersion { get; }

        /// <summary>
        /// The minor portion of the version, currently 0.
        /// </summary>
        public ushort MinorRuntimeVersion { get; }

        /// <summary>
        /// RVA and size of the physical metadata.
        /// </summary>
        public DirectoryEntry MetadataDirectory { get; }

        /// <summary>
        /// Flags describing this runtime image.
        /// </summary>
        public CorFlags Flags { get; }

        /// <summary>
        /// Token for the MethodDef or File of the entry point for the image.
        /// </summary>
        public int EntryPointTokenOrRelativeVirtualAddress { get; }

        /// <summary>
        /// RVA and size of implementation-specific resources.
        /// </summary>
        public DirectoryEntry ResourcesDirectory { get; }

        /// <summary>
        /// RVA of the hash data for this PE file used by the CLI loader for binding and versioning.
        /// </summary>
        public DirectoryEntry StrongNameSignatureDirectory { get; }

        /// <summary>
        /// Always 0.
        /// </summary>
        public DirectoryEntry CodeManagerTableDirectory { get; }

        /// <summary>
        /// RVA of an array of locations in the file that contain an array of function pointers (e.g., vtable slots), see below.
        /// </summary>
        public DirectoryEntry VtableFixupsDirectory { get; }

        /// <summary>
        /// Always 0.
        /// </summary>
        public DirectoryEntry ExportAddressTableJumpsDirectory { get; }

        /// <summary>
        /// Always 0.
        /// </summary>
        public DirectoryEntry ManagedNativeHeaderDirectory { get; }
    }
}