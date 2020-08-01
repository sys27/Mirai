namespace Mirai.Emitting.Metadata.Signatures
{
    public class PinnedType : Type
    {
        public PinnedType(Type type) : base(ElementType.Pinned)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}