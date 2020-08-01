namespace Mirai.Emitting.Metadata.Signatures
{
    // ARRAY Type ArrayShape
    public class ArrayType : Type
    {
        public ArrayType(Type type, ArrayShape arrayShape) : base(ElementType.Array)
        {
            Type = type;
            ArrayShape = arrayShape;
        }

        public Type Type { get; }
        public ArrayShape ArrayShape { get; }
    }
}