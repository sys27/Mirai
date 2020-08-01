namespace Mirai.Emitting.Metadata.Signatures
{
    // PropertySig ::= PROPERTY [HASTHIS] ParamCount CustomMod* Type Param*
    public class PropertySig : Signature
    {
        public PropertySig(
            CallingConvention callingConvention,
            CompressedUInt paramCount,
            CustomMod? customMod,
            Type type,
            Param[] param)
            : base(callingConvention)
        {
            ParamCount = paramCount;
            CustomMod = customMod;
            Type = type;
            Param = param;
        }

        // TODO: prop / hasthis
        public CompressedUInt ParamCount { get; }
        public CustomMod? CustomMod { get; }
        public Type Type { get; }
        public Param[] Param { get; }
    }
}