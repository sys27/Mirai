namespace Mirai.Emitting.Metadata.Signatures
{
    // PTR CustomMod* VOID
    // PTR CustomMod* Type
    public class PtrType : Type
    {
        public PtrType(CustomMod? customMod, Type type)
            : base(ElementType.Ptr)
        {
            CustomMod = customMod;
            Type = type;
        }

        public CustomMod? CustomMod { get; }
        public Type Type { get; }
    }
}