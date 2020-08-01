using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Mirai.Emitting.FileFormats;

namespace Mirai.Emitting
{
    public readonly struct StringsStreamReader
    {
        private readonly BinaryReader reader;
        private readonly MetadataRoot metadataRoot;
        private readonly StreamHeader streamHeader;

        public StringsStreamReader(BinaryReader reader, MetadataRoot metadataRoot)
        {
            this.reader = reader;
            this.metadataRoot = metadataRoot;
            this.streamHeader = metadataRoot.StreamHeaders.First(x => x.Name == StreamHeader.StringsName);
        }

        public string ReadString(uint stringOffset)
        {
            var previousOffset = reader.BaseStream.Position;

            var metadataRootOffset = metadataRoot.FileOffset;
            var streamOffset = metadataRootOffset.Offset + streamHeader.Offset;
            var offset = streamOffset + stringOffset;
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            // TODO:
            var list = new List<byte>(8);
            while (true)
            {
                var b = reader.ReadByte();
                if (b == 0)
                    break;

                list.Add(b);
            }

            reader.BaseStream.Seek(previousOffset, SeekOrigin.Begin);

            return Encoding.UTF8.GetString(list.ToArray());
        }
    }
}