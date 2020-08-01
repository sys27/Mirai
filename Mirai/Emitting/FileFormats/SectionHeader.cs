namespace Mirai.Emitting.FileFormats
{
    public readonly struct SectionHeader
    {
        public SectionHeader(
            string name,
            uint virtualSize,
            uint virtualAddress,
            uint sizeOfRawData,
            uint pointerToRawData,
            uint pointerToRelocations,
            uint pointerToLineNumbers,
            ushort numberOfRelocations,
            ushort numberOfLineNumbers,
            SectionCharacteristicsFlags sectionCharacteristics)
        {
            Name = name;
            VirtualSize = virtualSize;
            VirtualAddress = virtualAddress;
            SizeOfRawData = sizeOfRawData;
            PointerToRawData = pointerToRawData;
            PointerToRelocations = pointerToRelocations;
            PointerToLineNumbers = pointerToLineNumbers;
            NumberOfRelocations = numberOfRelocations;
            NumberOfLineNumbers = numberOfLineNumbers;
            SectionCharacteristics = sectionCharacteristics;
        }

        /// <summary>
        /// The name of the section.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The total size of the section when loaded into memory.
        /// If this value is greater than <see cref="SizeOfRawData"/>, the section is zero-padded.
        /// This field is valid only for PE images and should be set to zero for object files.
        /// </summary>
        public uint VirtualSize { get; }

        /// <summary>
        /// For PE images, the address of the first byte of the section relative to the image base when the
        /// section is loaded into memory. For object files, this field is the address of the first byte before
        /// relocation is applied; for simplicity, compilers should set this to zero. Otherwise,
        /// it is an arbitrary value that is subtracted from offsets during relocation.
        /// </summary>
        public uint VirtualAddress { get; }

        /// <summary>
        /// The size of the section (for object files) or the size of the initialized data on disk (for image files).
        /// For PE images, this must be a multiple of <see cref="PEHeader.FileAlignment"/>.
        /// If this is less than <see cref="VirtualSize"/>, the remainder of the section is zero-filled.
        /// Because the <see cref="SizeOfRawData"/> field is rounded but the <see cref="VirtualSize"/> field is not,
        /// it is possible for <see cref="SizeOfRawData"/> to be greater than <see cref="VirtualSize"/> as well.
        ///  When a section contains only uninitialized data, this field should be zero.
        /// </summary>
        public uint SizeOfRawData { get; }

        /// <summary>
        /// The file pointer to the first page of the section within the COFF file.
        /// For PE images, this must be a multiple of <see cref="PEHeader.FileAlignment"/>.
        /// For object files, the value should be aligned on a 4 byte boundary for best performance.
        /// When a section contains only uninitialized data, this field should be zero.
        /// </summary>
        public uint PointerToRawData { get; }

        /// <summary>
        /// The file pointer to the beginning of relocation entries for the section.
        /// This is set to zero for PE images or if there are no relocations.
        /// </summary>
        public uint PointerToRelocations { get; }

        /// <summary>
        /// The file pointer to the beginning of line-number entries for the section.
        /// This is set to zero if there are no COFF line numbers.
        /// This value should be zero for an image because COFF debugging information is deprecated.
        /// </summary>
        public uint PointerToLineNumbers { get; }

        /// <summary>
        /// The number of relocation entries for the section. This is set to zero for PE images.
        /// </summary>
        public ushort NumberOfRelocations { get; }

        /// <summary>
        /// The number of line-number entries for the section.
        ///  This value should be zero for an image because COFF debugging information is deprecated.
        /// </summary>
        public ushort NumberOfLineNumbers { get; }

        /// <summary>
        /// The flags that describe the characteristics of the section.
        /// </summary>
        public SectionCharacteristicsFlags SectionCharacteristics { get; }
    }
}