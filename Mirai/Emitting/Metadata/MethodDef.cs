namespace Mirai.Emitting.Metadata
{
    // 0x06
    public class MethodDef : Table
    {
        public MethodDef(
            uint recordIndex,
            uint rva,
            MethodImplAttributes implFlags,
            MethodAttributes flags,
            MetadataString name,
            MetadataSignature signature,
            uint paramList)
            : base(recordIndex)
        {
            RVA = rva;
            ImplFlags = implFlags;
            Flags = flags;
            Name = name;
            Signature = signature;
            ParamList = paramList;
        }

        public override TableType TableType => TableType.Method;

        public uint RVA { get; }
        public MethodImplAttributes ImplFlags { get; }
        public MethodAttributes Flags { get; }
        public MetadataString Name { get; }
        public MetadataSignature Signature { get; }
        public uint ParamList { get; }
    }
}