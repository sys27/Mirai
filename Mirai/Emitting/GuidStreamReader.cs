using System;
using System.IO;
using System.Linq;
using Mirai.Emitting.FileFormats;

namespace Mirai.Emitting
{
    public readonly struct GuidStreamReader
    {
        private readonly BinaryReader reader;
        private readonly MetadataRoot metadataRoot;
        private readonly StreamHeader streamHeader;

        public GuidStreamReader(BinaryReader reader, MetadataRoot metadataRoot)
        {
            this.reader = reader;
            this.metadataRoot = metadataRoot;
            this.streamHeader = metadataRoot.StreamHeaders.First(x => x.Name == StreamHeader.GuidName);
        }

        public Guid ReadGuid(uint guidOffset)
        {
            guidOffset -= 1;

            var previousOffset = reader.BaseStream.Position;

            var metadataRootOffset = metadataRoot.FileOffset;
            var streamOffset = metadataRootOffset.Offset + streamHeader.Offset;
            var offset = streamOffset + guidOffset;
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            Span<byte> buffer = stackalloc byte[16];
            var count = reader.Read(buffer);
            if (count != 16)
                throw new Exception();

            var guid = new Guid(buffer);

            reader.BaseStream.Seek(previousOffset, SeekOrigin.Begin);

            return guid;
        }
    }
}