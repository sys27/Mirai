namespace Mirai.Emitting.Metadata.Signatures
{
    // Type ::= ( BOOLEAN | CHAR | I1 | U1 | I2 | U2 | I4 | U4 | I8 | U8 | R4 | R8 | I | U |
    //         | VALUETYPE TypeDefOrRefEncoded
    //         | CLASS TypeDefOrRefEncoded
    //         | STRING
    //         | OBJECT
    //         | PTR CustomMod* VOID
    //         | PTR CustomMod* Type
    //         | FNPTR MethodDefSig
    //         | FNPTR MethodRefSig
    //         | ARRAY Type ArrayShape
    //         | SZARRAY CustomMod* Type
    //         | GENERICINST (CLASS | VALUETYPE) TypeDefOrRefEncoded GenArgCount Type*
    //         | VAR Number
    //         | MVAR Number
    public class Type
    {
        public Type(ElementType elementType)
        {
            ElementType = elementType;
        }

        public ElementType ElementType { get; }
    }
}