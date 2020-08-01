namespace Mirai.Emitting.Metadata.Signatures
{
    // LocalVarSig ::= LOCAL_SIG Count (TYPEDBYREF | ([CustomMod] [Constraint])* [BYREF] Type)+
    public class LocalVarSig : Signature
    {
        public LocalVarSig(CompressedUInt count, LocalVarSigItem[] items)
            : base(CallingConvention.LocalSig)
        {
            Count = count;
            Items = items;
        }

        public CompressedUInt Count { get; }
        public LocalVarSigItem[] Items { get; }

        // TODO: !!!
    }
}