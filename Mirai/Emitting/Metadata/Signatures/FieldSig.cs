namespace Mirai.Emitting.Metadata.Signatures
{
    // FieldSig ::= FIELD CustomMod* Type
    public class FieldSig : Signature
    {
        public FieldSig(CustomMod? customMod, Type type)
            : base(CallingConvention.Field)
        {
            CustomMod = customMod;
            Type = type;
        }

        public CustomMod? CustomMod { get; }
        public Type Type { get; }
    }
}