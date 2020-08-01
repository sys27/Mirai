using System.Collections.Immutable;

namespace Mirai.Emitting.FileFormats
{
    public class ExecutableFile
    {
        public ExecutableFile(
            CoffHeader coffHeader,
            OptionalHeader optionalHeader,
            ImmutableArray<SectionHeader> sectionHeaders,
            CorHeader corHeader,
            MetadataRoot metadata,
            TablesHeap tablesStream)
        {
            CoffHeader = coffHeader;
            OptionalHeader = optionalHeader;
            SectionHeaders = sectionHeaders;
            CorHeader = corHeader;
            Metadata = metadata;
            TablesStream = tablesStream;
        }

        public CoffHeader CoffHeader { get; }
        public OptionalHeader OptionalHeader { get; }
        public ImmutableArray<SectionHeader> SectionHeaders { get; }
        public CorHeader CorHeader { get; }
        public MetadataRoot Metadata { get; }

        public TablesHeap TablesStream { get; }
    }
}