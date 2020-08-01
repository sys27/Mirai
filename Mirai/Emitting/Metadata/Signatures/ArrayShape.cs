namespace Mirai.Emitting.Metadata.Signatures
{
    // ArrayShape ::= Rank NumSizes Size* NumLoBounds LoBound*
    public class ArrayShape
    {
        public ArrayShape(
            CompressedUInt rank,
            CompressedUInt numSizes,
            CompressedUInt[] size,
            CompressedUInt numLoBounds,
            CompressedUInt[] loBound)
        {
            Rank = rank;
            NumSizes = numSizes;
            Size = size;
            NumLoBounds = numLoBounds;
            LoBound = loBound;
        }

        public CompressedUInt Rank { get; }
        public CompressedUInt NumSizes { get; }
        public CompressedUInt[] Size { get; }
        public CompressedUInt NumLoBounds { get; }
        public CompressedUInt[] LoBound { get; }
    }
}