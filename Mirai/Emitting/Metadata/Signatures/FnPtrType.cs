namespace Mirai.Emitting.Metadata.Signatures
{
    // FNPTR MethodDefSig
    // FNPTR MethodRefSig
    public class FnPtrType : Type
    {
        public FnPtrType() : base(ElementType.FnPtr)
        {
        }

        public MethodDefSig? MethodDefSig { get; } // TODO:
        public MethodRefSig? MethodRefSig { get; }
    }
}