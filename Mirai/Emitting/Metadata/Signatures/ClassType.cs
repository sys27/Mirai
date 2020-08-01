namespace Mirai.Emitting.Metadata.Signatures
{
    // CLASS TypeDefOrRefEncoded
    public class ClassType : Type
    {
        public ClassType(TypeDefOrRefEncoded typeDefOrRefEncoded)
            : base(ElementType.Class)
        {
            TypeDefOrRefEncoded = typeDefOrRefEncoded;
        }

        public TypeDefOrRefEncoded TypeDefOrRefEncoded { get; }
    }
}