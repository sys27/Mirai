namespace Mirai.Emitting.Metadata.Signatures
{
    public class ByRefType : Type
    {
        public ByRefType(Type type)
            : base(ElementType.ByRef)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}