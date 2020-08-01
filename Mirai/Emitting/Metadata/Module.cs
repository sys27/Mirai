namespace Mirai.Emitting.Metadata
{
    // 0x00
    public class Module : Table
    {
        public Module(
            uint recordIndex,
            ushort generation,
            MetadataString name,
            MetadataGuid mvid,
            uint encId,
            uint encBaseId)
            : base(recordIndex)
        {
            Generation = generation;
            Name = name;
            Mvid = mvid;
            EncId = encId;
            EncBaseId = encBaseId;
        }

        public override TableType TableType => TableType.Module;

        /// <summary>
        /// A 2-byte value, reserved, shall be zero.
        /// </summary>
        public ushort Generation { get; }

        /// <summary>
        /// An index into the String heap.
        /// </summary>
        public MetadataString Name { get; }

        /// <summary>
        /// An index into the Guid heap; simply a Guid used to distinguish between two versions of the same module.
        /// </summary>
        public MetadataGuid Mvid { get; }

        /// <summary>
        /// An index into the Guid heap; reserved, shall be zero.
        /// </summary>
        public uint EncId { get; }

        /// <summary>
        /// An index into the Guid heap; reserved, shall be zero.
        /// </summary>
        public uint EncBaseId { get; }
    }
}