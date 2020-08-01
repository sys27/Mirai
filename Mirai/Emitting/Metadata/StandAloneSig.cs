namespace Mirai.Emitting.Metadata
{
    // 0x11
    public class StandAloneSig : Table
    {
        public StandAloneSig(uint recordIndex, MetadataSignature signature)
            : base(recordIndex)
        {
            Signature = signature;
        }

        public override TableType TableType => TableType.StandAloneSig;

        /// <summary>
        /// An index into the Blob heap.
        /// </summary>
        public MetadataSignature Signature { get; }
    }
}