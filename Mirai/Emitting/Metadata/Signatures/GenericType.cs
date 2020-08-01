namespace Mirai.Emitting.Metadata.Signatures
{
    // GENERICINST (CLASS | VALUETYPE) TypeDefOrRefEncoded GenArgCount Type*
    public class GenericType : Type
    {
        public GenericType(
            ElementType classOrValueType,
            TypeDefOrRefEncoded typeDefOrRefEncoded,
            CompressedUInt genArgCount,
            Type[] type)
            : base(ElementType.GenericInst)
        {
            ClassOrValueType = classOrValueType;
            TypeDefOrRefEncoded = typeDefOrRefEncoded;
            GenArgCount = genArgCount;
            Type = type;
        }

        public ElementType ClassOrValueType { get; } // TODO: CLASS | VALUETYPE
        public TypeDefOrRefEncoded TypeDefOrRefEncoded { get; }
        public CompressedUInt GenArgCount { get; }
        public Type[] Type { get; }
    }
}