namespace Mirai.Emitting.Metadata.Signatures
{
    // MVAR Number
    public class MVarType : Type
    {
        public MVarType(CompressedUInt number) : base(ElementType.MVar)
        {
            Number = number;
        }

        public CompressedUInt Number { get; } // TODO: ??
    }
}