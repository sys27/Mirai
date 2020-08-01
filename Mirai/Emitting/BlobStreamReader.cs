using System;
using System.IO;
using System.Linq;
using Mirai.Emitting.FileFormats;

namespace Mirai.Emitting
{
    public readonly struct BlobStreamReader
    {
        private readonly BinaryReader reader;
        private readonly MetadataRoot metadataRoot;
        private readonly StreamHeader streamHeader;

        public BlobStreamReader(BinaryReader reader, MetadataRoot metadataRoot)
        {
            this.reader = reader;
            this.metadataRoot = metadataRoot;
            this.streamHeader = metadataRoot.StreamHeaders.First(x => x.Name == StreamHeader.BlobName);
        }

        private int GetLength()
        {
            var b = reader.ReadByte();

            // first bit is zero (eg. 0b0xxxxxxx)
            if ((b & 0b10000000) == 0)
            {
                return b;
            }

            // first two bits is 10 (eg. 0b10xxxxxx)
            if ((b & 0b11000000) == 0b10000000)
            {
                var x = reader.ReadByte();
                var size = ((b & 0b00111111) << 8) + x;

                return size;
            }

            // first three bits is 110 (eg. 0b11000000)
            if ((b & 0b11100000) == 0b11000000)
            {
                var x = reader.ReadByte();
                var y = reader.ReadByte();
                var z = reader.ReadByte();
                var size = ((b & 0b00011111) << 24) + (x << 16) + (y << 8) + z;

                return size;
            }

            throw new Exception();
        }

        public byte[] ReadBlob(uint blobOffset)
        {
            var previousOffset = reader.BaseStream.Position;

            var metadataRootOffset = metadataRoot.FileOffset;
            var streamOffset = metadataRootOffset.Offset + streamHeader.Offset;
            var offset = streamOffset + blobOffset;
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            var length = GetLength();
            var bytes = reader.ReadBytes(length);

            reader.BaseStream.Seek(previousOffset, SeekOrigin.Begin);

            return bytes;
        }
    }
}