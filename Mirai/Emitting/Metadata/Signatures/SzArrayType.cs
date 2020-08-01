namespace Mirai.Emitting.Metadata.Signatures
{
    // SZARRAY CustomMod* Type
    public class SzArrayType : Type
    {
        public SzArrayType(CustomMod? customMod, Type type)
            : base(ElementType.SzArray)
        {
            CustomMod = customMod;
            Type = type;
        }

        public CustomMod? CustomMod { get; }
        public Type Type { get; }
    }
}