namespace Mirai.Emitting.Metadata.Signatures
{
    // Sig ::= MethodDefSig | MethodRefSig | StandAloneMethodSig | FieldSig | PropertySig | LocalVarSig
    public abstract class Signature
    {
        protected Signature(CallingConvention callingConvention)
        {
            CallingConvention = callingConvention;
        }

        public CallingConvention CallingConvention { get; }
    }
}