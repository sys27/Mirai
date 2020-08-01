namespace Mirai.Emitting.Metadata.Signatures
{
    // RetType ::= CustomMod* ( VOID | TYPEDBYREF | [BYREF] Type )
    public class RetType
    {
        public RetType(CustomMod? customMod, Type? type)
        {
            CustomMod = customMod;
            Type = type;
        }

        public CustomMod? CustomMod { get; }
        public Type? Type { get; }
    }
}