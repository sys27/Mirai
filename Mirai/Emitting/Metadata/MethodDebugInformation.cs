namespace Mirai.Emitting.Metadata
{
    // 0x31
    public class MethodDebugInformation : Table
    {
        public MethodDebugInformation(uint recordIndex, uint document, MetadataBlob sequencePoints)
            : base(recordIndex)
        {
            Document = document;
            SequencePoints = sequencePoints;
        }

        public override TableType TableType => TableType.MethodDebugInformation;

        public uint Document { get; }
        public MetadataBlob SequencePoints { get; }
    }
}