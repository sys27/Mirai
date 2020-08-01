using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Emitting.FileFormats;
using File = System.IO.File;

namespace Mirai.Emitting
{
    public class Reader
    {
        public async Task<ExecutableFile> Load(
            string filePath,
            CancellationToken cancellationToken = default)
        {
            // TODO: pipelines?

            await using var file = File.OpenRead(filePath);
            await using var buffered = new BufferedStream(file);
            using var reader = new BinaryReader(buffered);

            MsDosHeader(reader);
            var coffHeader = GetCoffHeader(reader);
            var optionalHeader = GetPeHeader(reader, coffHeader.OptionalHeaderSize);
            var sectionHeaders = GetSectionHeaders(reader, coffHeader.NumberOfSections);
            var corHeader = GetCorHeader(reader, optionalHeader.DirectoryEntries.CorHeaderTableDirectory, sectionHeaders);
            var metadataRoot = Metadata(reader, corHeader, sectionHeaders);

            var stringsStream = new StringsStreamReader(reader, metadataRoot);
            var guidStream = new GuidStreamReader(reader, metadataRoot);
            var blobStream = new BlobStreamReader(reader, metadataRoot);

            var tablesStream = new TablesStreamReader(
                    reader,
                    metadataRoot,
                    stringsStream,
                    guidStream,
                    blobStream)
                .GetTablesStream();

            return new ExecutableFile(
                coffHeader,
                optionalHeader,
                sectionHeaders,
                corHeader,
                metadataRoot,
                tablesStream);
        }

        private void MsDosHeader(BinaryReader reader)
        {
            var mz = reader.ReadUInt16();
            if (mz != FileFormats.MsDosHeader.Signature)
                throw new Exception();

            reader.BaseStream.Seek(FileFormats.MsDosHeader.PeSignatureOffset, SeekOrigin.Begin);

            var peSignatureOffset = reader.ReadUInt32();
            reader.BaseStream.Seek(peSignatureOffset, SeekOrigin.Begin);
        }

        private CoffHeader GetCoffHeader(BinaryReader reader)
        {
            var peSignature = reader.ReadUInt32();
            if (peSignature != CoffHeader.CommonSignature)
                throw new Exception();

            var machine = (Machine) reader.ReadUInt16(); // TODO: validate
            var numberOfSections = reader.ReadUInt16();
            var timeDateStamp = reader.ReadUInt32();
            var pointerToSymbolTable = reader.ReadUInt32();
            var numberOfSymbols = reader.ReadUInt32();
            var optionalHeaderSize = reader.ReadUInt16();
            var characteristics = (CharacteristicsFlags) reader.ReadUInt16(); // TODO: validate

            return new CoffHeader(
                machine,
                numberOfSections,
                timeDateStamp,
                pointerToSymbolTable,
                numberOfSymbols,
                optionalHeaderSize,
                characteristics);
        }

        private OptionalHeader GetPeHeader(BinaryReader reader, ushort optionalHeaderSize)
        {
            // TODO: validate size
            // Note that the size of the optional header is not fixed. The SizeOfOptionalHeader field in the COFF header must be used to validate that a probe into the file for a particular data directory does not go beyond SizeOfOptionalHeader. For more information, see COFF File Header (Object and Image).
            // The NumberOfRvaAndSizes field of the optional header should also be used to ensure that no probe for a particular data directory entry goes beyond the optional header. In addition, it is important to validate the optional header magic number for format compatibility.

            var standardFields = GetStandardFields(reader);
            var windowsSpecificFields = GetWindowsSpecificFields(reader, standardFields.Magic);
            var directoryEntries = GetDirectoryEntries(reader, windowsSpecificFields.NumberOfRvaAndSizes);

            return new OptionalHeader(standardFields, windowsSpecificFields, directoryEntries);
        }

        private StandardFields GetStandardFields(BinaryReader reader)
        {
            var magic = (PeMagic) reader.ReadUInt16(); // TODO: validate
            var majorLinkerVersion = reader.ReadByte();
            var minorLinkerVersion = reader.ReadByte();
            var sizeOfCode = reader.ReadInt32();
            var sizeOfInitializedData = reader.ReadInt32();
            var sizeOfUninitializedData = reader.ReadInt32();
            var addressOfEntryPoint = reader.ReadInt32();
            var baseOfCode = reader.ReadInt32();

            int? baseOfData = null;
            if (magic == PeMagic.PE32)
                baseOfData = reader.ReadInt32();

            return new StandardFields(
                magic,
                majorLinkerVersion,
                minorLinkerVersion,
                sizeOfCode,
                sizeOfInitializedData,
                sizeOfUninitializedData,
                addressOfEntryPoint,
                baseOfCode,
                baseOfData);
        }

        private WindowsSpecificFields GetWindowsSpecificFields(BinaryReader reader, PeMagic peMagic)
        {
            var imageBase = peMagic == PeMagic.PE32 ? reader.ReadUInt32() : reader.ReadUInt64();
            var sectionAlignment = reader.ReadInt32();
            var fileAlignment = reader.ReadInt32();
            var majorOperatingSystemVersion = reader.ReadUInt16();
            var minorOperatingSystemVersion = reader.ReadUInt16();
            var majorImageVersion = reader.ReadUInt16();
            var minorImageVersion = reader.ReadUInt16();
            var majorSubsystemVersion = reader.ReadUInt16();
            var minorSubsystemVersion = reader.ReadUInt16();

            // reserved
            reader.BaseStream.Seek(4, SeekOrigin.Current);

            var sizeOfImage = reader.ReadInt32();
            var sizeOfHeaders = reader.ReadInt32();
            var checkSum = reader.ReadUInt32();
            var subsystem = (Subsystem) reader.ReadUInt16(); // TODO: validate
            var dllCharacteristicsFlags = (DllCharacteristicsFlags) reader.ReadUInt16();

            ulong sizeOfStackReserve;
            ulong sizeOfStackCommit;
            ulong sizeOfHeapReserve;
            ulong sizeOfHeapCommit;

            if (peMagic == PeMagic.PE32)
            {
                sizeOfStackReserve = reader.ReadUInt32();
                sizeOfStackCommit = reader.ReadUInt32();
                sizeOfHeapReserve = reader.ReadUInt32();
                sizeOfHeapCommit = reader.ReadUInt32();
            }
            else
            {
                sizeOfStackReserve = reader.ReadUInt64();
                sizeOfStackCommit = reader.ReadUInt64();
                sizeOfHeapReserve = reader.ReadUInt64();
                sizeOfHeapCommit = reader.ReadUInt64();
            }

            // reserved
            reader.ReadUInt32();

            var numberOfRvaAndSizes = reader.ReadInt32();

            return new WindowsSpecificFields(
                imageBase,
                sectionAlignment,
                fileAlignment,
                majorOperatingSystemVersion,
                minorOperatingSystemVersion,
                majorImageVersion,
                minorImageVersion,
                majorSubsystemVersion,
                minorSubsystemVersion,
                sizeOfImage,
                sizeOfHeaders,
                checkSum,
                subsystem,
                dllCharacteristicsFlags,
                sizeOfStackReserve,
                sizeOfStackCommit,
                sizeOfHeapReserve,
                sizeOfHeapCommit,
                numberOfRvaAndSizes);
        }

        private DirectoryEntries GetDirectoryEntries(BinaryReader reader, int numberOfRvaAndSizes)
        {
            // TODO: num

            var exportTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var importTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var resourceTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var exceptionTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var certificateTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var baseRelocationTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var debugTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var copyrightTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var globalPointerTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var threadLocalStorageTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var loadConfigTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var boundImportTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var importAddressTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var delayImportTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var corHeaderTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());

            // TODO: reserved
            reader.ReadUInt64();

            return new DirectoryEntries(
                exportTableDirectory,
                importTableDirectory,
                resourceTableDirectory,
                exceptionTableDirectory,
                certificateTableDirectory,
                baseRelocationTableDirectory,
                debugTableDirectory,
                copyrightTableDirectory,
                globalPointerTableDirectory,
                threadLocalStorageTableDirectory,
                loadConfigTableDirectory,
                boundImportTableDirectory,
                importAddressTableDirectory,
                delayImportTableDirectory,
                corHeaderTableDirectory);
        }

        private ImmutableArray<SectionHeader> GetSectionHeaders(BinaryReader reader, ushort numberOfSections)
        {
            var builder = ImmutableArray.CreateBuilder<SectionHeader>();

            for (var i = 0; i < numberOfSections; i++)
            {
                var name = Encoding.UTF8.GetString(reader.ReadBytes(8)).Trim('\0');
                var virtualSize = reader.ReadUInt32();
                var virtualAddress = reader.ReadUInt32();
                var sizeOfRawData = reader.ReadUInt32();
                var pointerToRawData = reader.ReadUInt32();
                var pointerToRelocations = reader.ReadUInt32();
                var pointerToLineNumbers = reader.ReadUInt32();
                var numberOfRelocations = reader.ReadUInt16();
                var numberOfLineNumbers = reader.ReadUInt16();
                var sectionCharacteristics = (SectionCharacteristicsFlags) reader.ReadUInt32();

                var sectionHeader = new SectionHeader(
                    name,
                    virtualSize,
                    virtualAddress,
                    sizeOfRawData,
                    pointerToRawData,
                    pointerToRelocations,
                    pointerToLineNumbers,
                    numberOfRelocations,
                    numberOfLineNumbers,
                    sectionCharacteristics);

                builder.Add(sectionHeader);
            }

            return builder.ToImmutableArray();
        }

        private CorHeader GetCorHeader(
            BinaryReader reader,
            DirectoryEntry corHeaderTableDirectory,
            ImmutableArray<SectionHeader> sectionHeaders)
        {
            var corRva = corHeaderTableDirectory.RelativeVirtualAddress;
            var section = sectionHeaders.First(x => corRva >= x.VirtualAddress && corRva < x.VirtualAddress + x.VirtualSize); // TODO:
            var offset = corRva - section.VirtualAddress + section.PointerToRawData;
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            var cb = reader.ReadUInt32();
            var majorRuntimeVersion = reader.ReadUInt16();
            var minorRuntimeVersion = reader.ReadUInt16();
            var metadataDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var flags = (CorFlags) reader.ReadUInt32();
            var entryPointTokenOrRelativeVirtualAddress = reader.ReadInt32();
            var resourcesDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var strongNameSignatureDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var codeManagerTableDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var vtableFixupsDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var exportAddressTableJumpsDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());
            var managedNativeHeaderDirectory = new DirectoryEntry(reader.ReadUInt32(), reader.ReadUInt32());

            return new CorHeader(
                cb,
                majorRuntimeVersion,
                minorRuntimeVersion,
                metadataDirectory,
                flags,
                entryPointTokenOrRelativeVirtualAddress,
                resourcesDirectory,
                strongNameSignatureDirectory,
                codeManagerTableDirectory,
                vtableFixupsDirectory,
                exportAddressTableJumpsDirectory,
                managedNativeHeaderDirectory);
        }

        private MetadataRoot Metadata(
            BinaryReader reader,
            CorHeader corHeader,
            ImmutableArray<SectionHeader> sectionHeaders)
        {
            var metadataRva = corHeader.MetadataDirectory.RelativeVirtualAddress;
            var section = sectionHeaders.First(x => metadataRva >= x.VirtualAddress && metadataRva < x.VirtualAddress + x.VirtualSize); // TODO:
            var offset = metadataRva - section.VirtualAddress + section.PointerToRawData;
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            var signature = reader.ReadUInt32();
            if (signature != MetadataRoot.Signature)
                throw new Exception();

            var majorVersion = reader.ReadUInt16();
            Debug.Assert(majorVersion == 1, "Should be 1.");

            var minorVersion = reader.ReadUInt16();
            Debug.Assert(minorVersion == 1, "Should be 1.");

            var reserved = reader.ReadUInt32();
            Debug.Assert(reserved == 0, "Reserved. Should be 0.");

            var length = reader.ReadUInt32();
            if (length > 255)
                throw new Exception();

            var version = Encoding.UTF8
                .GetString(reader.ReadBytes((int) length))
                .Trim('\0'); // padding

            var flags = reader.ReadUInt16();
            Debug.Assert(flags == 0, "Flags. Should be 0.");

            var streams = reader.ReadUInt16();
            var streamHeaders = GetStreamHeaders(reader, streams);

            return new MetadataRoot(
                new FileOffset(offset),
                majorVersion,
                minorVersion,
                length,
                version,
                flags,
                streams,
                streamHeaders);
        }

        private ImmutableArray<StreamHeader> GetStreamHeaders(BinaryReader reader, ushort streams)
        {
            var builder = ImmutableArray.CreateBuilder<StreamHeader>();

            for (var i = 0; i < streams; i++)
            {
                var offset = reader.ReadUInt32();
                var size = reader.ReadUInt32();
                var name = ReadString(reader, 32);

                var streamHeader = new StreamHeader(offset, size, name);

                builder.Add(streamHeader);
            }

            return builder.ToImmutableArray();
        }

        private string ReadString(BinaryReader reader, int maxLength)
        {
            Span<byte> bytes = stackalloc byte[maxLength]; // TODO: pool / stack?

            var i = 0;
            for (; i < maxLength; i++)
            {
                bytes[i] = reader.ReadByte();
                if (bytes[i] == 0)
                    break;
            }

            var str = Encoding.UTF8.GetString(bytes[..i]);

            var remainder = reader.BaseStream.Position % 4;
            if (remainder > 0)
            {
                var padding = 4 - remainder;
                if (padding > 0)
                    reader.BaseStream.Seek(padding, SeekOrigin.Current);
            }

            return str;
        }
    }
}