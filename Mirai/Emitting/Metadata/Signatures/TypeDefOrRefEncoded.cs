using Mirai.Emitting.Metadata.CodedIndexes;

namespace Mirai.Emitting.Metadata.Signatures
{
    // TypeDefOrRefEncoded ::= TypeDefEncoded | TypeRefEncoded
    // TypeDefEncoded ::= 32-bit-3-part-encoding-for-typedefs-and-typerefs
    // TypeRefEncoded ::= 32-bit-3-part-encoding-for-typedefs-and-typerefs
    public class TypeDefOrRefEncoded
    {
        public TypeDefOrRefEncoded(CodedIndex<TypeDefOrRefTag> value)
        {
            Value = value;
        }

        public CodedIndex<TypeDefOrRefTag> Value { get; } // TODO: compressed
    }
}