namespace Mirai.Emitting.Metadata.Signatures
{
    // MethodDefSig ::= [[HASTHIS] [EXPLICITTHIS]] (DEFAULT|VARARG|GENERIC GenParamCount) ParamCount RetType Param*
    public class MethodDefSig : Signature
    {
        public MethodDefSig(
            CallingConvention callingConvention,
            CompressedUInt genParamCount,
            CompressedUInt paramCount,
            RetType retType,
            Param[] param) // TODO: DEFAULT|VARARG|GENERIC
            : base(callingConvention)
        {
            GenParamCount = genParamCount;
            ParamCount = paramCount;
            RetType = retType;
            Param = param;
        }

        public CompressedUInt GenParamCount { get; }
        public CompressedUInt ParamCount { get; }
        public RetType RetType { get; }
        public Param[] Param { get; }
    }
}