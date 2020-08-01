namespace Mirai.Emitting.Metadata.Signatures
{
    // VAR Number
    public class VarType : Type
    {
        public VarType(CompressedUInt number) : base(ElementType.Var)
        {
            Number = number;
        }

        public CompressedUInt Number { get; } // TODO: ??
    }
}