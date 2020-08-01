namespace Mirai.Emitting.Metadata.Signatures
{
    // CustomMod ::= ( CMOD_OPT | CMOD_REQD ) ( TypeDefEncoded | TypeRefEncoded )
    public readonly struct CustomMod
    {
        public CustomMod(ElementType elementType, TypeDefOrRefEncoded token)
        {
            ElementType = elementType;
            Token = token;
        }

        public ElementType ElementType { get; } // TODO: ELEMENT_TYPE_CMOD_OPT / ELEMENT_TYPE_CMOD_REQD
        public TypeDefOrRefEncoded Token { get; }
    }
}