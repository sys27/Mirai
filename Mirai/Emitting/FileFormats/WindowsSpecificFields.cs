namespace Mirai.Emitting.FileFormats
{
    public readonly struct WindowsSpecificFields
    {
        public WindowsSpecificFields(
            ulong imageBase,
            int sectionAlignment,
            int fileAlignment,
            ushort majorOperatingSystemVersion,
            ushort minorOperatingSystemVersion,
            ushort majorImageVersion,
            ushort minorImageVersion,
            ushort majorSubsystemVersion,
            ushort minorSubsystemVersion,
            int sizeOfImage,
            int sizeOfHeaders,
            uint checkSum,
            Subsystem subsystem,
            DllCharacteristicsFlags dllCharacteristics,
            ulong sizeOfStackReserve,
            ulong sizeOfStackCommit,
            ulong sizeOfHeapReserve,
            ulong sizeOfHeapCommit,
            int numberOfRvaAndSizes)
        {
            ImageBase = imageBase;
            SectionAlignment = sectionAlignment;
            FileAlignment = fileAlignment;
            MajorOperatingSystemVersion = majorOperatingSystemVersion;
            MinorOperatingSystemVersion = minorOperatingSystemVersion;
            MajorImageVersion = majorImageVersion;
            MinorImageVersion = minorImageVersion;
            MajorSubsystemVersion = majorSubsystemVersion;
            MinorSubsystemVersion = minorSubsystemVersion;
            SizeOfImage = sizeOfImage;
            SizeOfHeaders = sizeOfHeaders;
            CheckSum = checkSum;
            Subsystem = subsystem;
            DllCharacteristics = dllCharacteristics;
            SizeOfStackReserve = sizeOfStackReserve;
            SizeOfStackCommit = sizeOfStackCommit;
            SizeOfHeapReserve = sizeOfHeapReserve;
            SizeOfHeapCommit = sizeOfHeapCommit;
            NumberOfRvaAndSizes = numberOfRvaAndSizes;
        }

        /// <summary>
        /// The preferred address of the first byte of image when loaded into memory;
        /// must be a multiple of 64K.
        /// </summary>
        public ulong ImageBase { get; }

        /// <summary>
        /// The alignment (in bytes) of sections when they are loaded into memory. It must be greater than or equal to <see cref="FileAlignment"/>.
        /// The default is the page size for the architecture.
        /// </summary>
        public int SectionAlignment { get; }

        /// <summary>
        /// The alignment factor (in bytes) that is used to align the raw data of sections in the image file.
        /// The value should be a power of 2 between 512 and 64K, inclusive. The default is 512.
        /// If the <see cref="SectionAlignment"/> is less than the architecture's page size,
        /// then <see cref="FileAlignment"/> must match <see cref="SectionAlignment"/>.
        /// </summary>
        public int FileAlignment { get; }

        /// <summary>
        /// The major version number of the required operating system.
        /// </summary>
        public ushort MajorOperatingSystemVersion { get; }

        /// <summary>
        /// The minor version number of the required operating system.
        /// </summary>
        public ushort MinorOperatingSystemVersion { get; }

        /// <summary>
        /// The major version number of the image.
        /// </summary>
        public ushort MajorImageVersion { get; }

        /// <summary>
        /// The minor version number of the image.
        /// </summary>
        public ushort MinorImageVersion { get; }

        /// <summary>
        /// The major version number of the subsystem.
        /// </summary>
        public ushort MajorSubsystemVersion { get; }

        /// <summary>
        /// The minor version number of the subsystem.
        /// </summary>
        public ushort MinorSubsystemVersion { get; }

        /// <summary>
        /// The size (in bytes) of the image, including all headers, as the image is loaded in memory.
        /// It must be a multiple of <see cref="SectionAlignment"/>.
        /// </summary>
        public int SizeOfImage { get; }

        /// <summary>
        /// The combined size of an MS DOS stub, PE header, and section headers rounded up to a multiple of FileAlignment.
        /// </summary>
        public int SizeOfHeaders { get; }

        /// <summary>
        /// The image file checksum.
        /// </summary>
        public uint CheckSum { get; }

        /// <summary>
        /// The subsystem that is required to run this image.
        /// </summary>
        public Subsystem Subsystem { get; }

        public DllCharacteristicsFlags DllCharacteristics { get; }

        /// <summary>
        /// The size of the stack to reserve. Only <see cref="SizeOfStackCommit"/> is committed;
        /// the rest is made available one page at a time until the reserve size is reached.
        /// </summary>
        public ulong SizeOfStackReserve { get; }

        /// <summary>
        /// The size of the stack to commit.
        /// </summary>
        public ulong SizeOfStackCommit { get; }

        /// <summary>
        /// The size of the local heap space to reserve. Only <see cref="SizeOfHeapCommit"/> is committed;
        /// the rest is made available one page at a time until the reserve size is reached.
        /// </summary>
        public ulong SizeOfHeapReserve { get; }

        /// <summary>
        /// The size of the local heap space to commit.
        /// </summary>
        public ulong SizeOfHeapCommit { get; }

        /// <summary>
        /// The number of data-directory entries in the remainder of the <see cref="OptionalHeader"/>. Each describes a location and size.
        /// </summary>
        public int NumberOfRvaAndSizes { get; }
    }
}