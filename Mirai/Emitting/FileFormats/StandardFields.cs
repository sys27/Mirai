namespace Mirai.Emitting.FileFormats
{
    public readonly struct StandardFields
    {
        public StandardFields(
            PeMagic magic,
            byte majorLinkerVersion,
            byte minorLinkerVersion,
            int sizeOfCode,
            int sizeOfInitializedData,
            int sizeOfUninitializedData,
            int addressOfEntryPoint,
            int baseOfCode,
            int? baseOfData)
        {
            Magic = magic;
            MajorLinkerVersion = majorLinkerVersion;
            MinorLinkerVersion = minorLinkerVersion;
            SizeOfCode = sizeOfCode;
            SizeOfInitializedData = sizeOfInitializedData;
            SizeOfUninitializedData = sizeOfUninitializedData;
            AddressOfEntryPoint = addressOfEntryPoint;
            BaseOfCode = baseOfCode;
            BaseOfData = baseOfData;
        }

        /// <summary>
        /// Identifies the format of the image file.
        /// </summary>
        public PeMagic Magic { get; }

        /// <summary>
        /// The linker major version number.
        /// </summary>
        public byte MajorLinkerVersion { get; }

        /// <summary>
        /// The linker minor version number.
        /// </summary>
        public byte MinorLinkerVersion { get; }

        /// <summary>
        /// The size of the code (text) section, or the sum of all code sections if there are multiple sections.
        /// </summary>
        public int SizeOfCode { get; }

        /// <summary>
        /// The size of the initialized data section, or the sum of all such sections if there are multiple data sections.
        /// </summary>
        public int SizeOfInitializedData { get; }

        /// <summary>
        /// The size of the uninitialized data section (BSS), or the sum of all such sections if there are multiple BSS sections.
        /// </summary>
        public int SizeOfUninitializedData { get; }

        /// <summary>
        /// The address of the entry point relative to the image base when the PE file is loaded into memory.
        /// For program images, this is the starting address. For device drivers, this is the address of the initialization function.
        /// An entry point is optional for DLLs. When no entry point is present, this field must be zero.
        /// </summary>
        public int AddressOfEntryPoint { get; }

        /// <summary>
        /// The address that is relative to the image base of the beginning-of-code section when it is loaded into memory.
        /// </summary>
        public int BaseOfCode { get; }

        /// <summary>
        /// The address that is relative to the image base of the beginning-of-data section when it is loaded into memory. BaseOfData is absent in PE32+.
        /// </summary>
        public int? BaseOfData { get; }
    }
}