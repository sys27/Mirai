namespace Mirai.Emitting.FileFormats
{
    public class CoffHeader
    {
        public const uint CommonSignature = 0x00004550;

        public CoffHeader(
            Machine machine,
            ushort numberOfSections,
            uint timeDateStamp,
            uint pointerToSymbolTable,
            uint numberOfSymbols,
            ushort optionalHeaderSize,
            CharacteristicsFlags characteristics)
        {
            Machine = machine;
            NumberOfSections = numberOfSections;
            TimeDateStamp = timeDateStamp;
            PointerToSymbolTable = pointerToSymbolTable;
            NumberOfSymbols = numberOfSymbols;
            OptionalHeaderSize = optionalHeaderSize;
            Characteristics = characteristics;
        }

        // public uint Signature { get; } // TODO:

        /// <summary>
        /// The type of target machine.
        /// </summary>
        public Machine Machine { get; }

        /// <summary>
        /// Number of sections; indicates size of the Section Table, which immediately follows the headers.
        /// </summary>
        public ushort NumberOfSections { get; }

        /// <summary>
        /// Time and date the file was created in seconds since January 1st 1970 00:00:00 or 0.
        /// </summary>
        public uint TimeDateStamp { get; }

        /// <summary>
        /// Always 0.
        /// </summary>
        public uint PointerToSymbolTable { get; }

        /// <summary>
        /// Always 0.
        /// </summary>
        public uint NumberOfSymbols { get; }

        /// <summary>
        /// Size of the optional header, the format is described below.
        /// </summary>
        public ushort OptionalHeaderSize { get; }

        /// <summary>
        /// Flags indicating attributes of the file.
        /// </summary>
        public CharacteristicsFlags Characteristics { get; }
    }
}