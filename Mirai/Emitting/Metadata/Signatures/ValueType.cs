namespace Mirai.Emitting.Metadata.Signatures
{
    // VALUETYPE TypeDefOrRefEncoded
    public class ValueType : Type
    {
        public ValueType(TypeDefOrRefEncoded typeDefOrRefEncoded)
            : base(ElementType.ValueType)
        {
            TypeDefOrRefEncoded = typeDefOrRefEncoded;
        }

        public TypeDefOrRefEncoded TypeDefOrRefEncoded { get; }
    }
}