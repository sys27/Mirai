namespace Mirai.Emitting.Metadata.Signatures
{
    // MethodRefSig ::= [[HASTHIS] [EXPLICITTHIS]] VARARG ParamCount RetType Param* [SENTINEL Param+]
    public class MethodRefSig : Signature
    {
        public MethodRefSig(CallingConvention callingConvention) : base(callingConvention)
        {
        }

        public CompressedUInt ParamCount { get; }
        public RetType RetType { get; }
        public ElementType Sentinel { get; } // TODO: remove
        public Param[] Param { get; }
    }
}