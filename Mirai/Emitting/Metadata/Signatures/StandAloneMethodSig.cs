namespace Mirai.Emitting.Metadata.Signatures
{
    // StandAloneMethodSig ::= [[HASTHIS] [EXPLICITTHIS]] (DEFAULT|VARARG|C|STDCALL|THISCALL|FASTCALL)
    //                         ParamCount RetType Param* [SENTINEL Param+]
    public class StandAloneMethodSig : Signature
    {
        public StandAloneMethodSig(CallingConvention callingConvention)
            : base(callingConvention)
        {
        }

        public CompressedUInt ParamCount { get; }
        public RetType RetType { get; }
        public Param[] Params { get; }
        public ElementType Sentinel { get; } // TODO: remove
        public Param Param { get; }
    }
}