namespace Mirai.Emitting.Metadata.Signatures
{
    // Param ::= CustomMod* ( TYPEDBYREF | [BYREF] Type )
    public class Param
    {
        public Param(CustomMod? customMod, Type type)
        {
            CustomMod = customMod;
            Type = type;
        }

        public CustomMod? CustomMod { get; }
        public Type Type { get; }
    }
}