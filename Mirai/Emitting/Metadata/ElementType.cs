namespace Mirai.Emitting.Metadata
{
    public enum ElementType : byte
    {
        /// <summary>
        /// Marks end of a list.
        /// </summary>
        End = 0x00,
        Void = 0x01,
        Boolean = 0x02,
        Char = 0x03,
        I1 = 0x04,
        U1 = 0x05,
        I2 = 0x06,
        U2 = 0x07,
        I4 = 0x08,
        U4 = 0x09,
        I8 = 0x0A,
        U8 = 0x0B,
        R4 = 0x0C,
        R8 = 0x0D,
        String = 0x0E,

        /// <summary>
        /// Followed by type.
        /// </summary>
        Ptr = 0x0F,

        /// <summary>
        /// Followed by type.
        /// </summary>
        ByRef = 0x10,

        /// <summary>
        /// Followed by TypeDef or TypeRef token.
        /// </summary>
        ValueType = 0x11,

        /// <summary>
        /// Followed by TypeDef or TypeRef token.
        /// </summary>
        Class = 0x12,

        /// <summary>
        /// Generic parameter in a generic type definition, represented as number (compressed unsigned integer).
        /// </summary>
        Var = 0x13,

        /// <summary>
        /// type rank boundsCount bound1 ...
        /// loCount lo1 ...
        /// </summary>
        Array = 0x14,

        /// <summary>
        /// Generic type instantiation. Followed by type type-arg-count type-1 ... type-n
        /// </summary>
        GenericInst = 0x15,
        TypedByRef = 0x16,

        /// <summary>
        /// System.IntPtr
        /// </summary>
        ELEMENT_TYPE_I = 0x18,

        /// <summary>
        /// System.UIntPtr
        /// </summary>
        ELEMENT_TYPE_U = 0x19,

        /// <summary>
        /// Followed by full method signature.
        /// </summary>
        FnPtr = 0x1B,

        /// <summary>
        /// System.Object
        /// </summary>
        Object = 0x1C,

        /// <summary>
        /// Single-dim array with 0 lower bound.
        /// </summary>
        SzArray = 0x1D,

        /// <summary>
        /// Generic parameter in a generic method definition, represented as number (compressed unsigned integer).
        /// </summary>
        MVar = 0x1E,

        /// <summary>
        /// Required modifier: followed by a TypeDef or TypeRef token.
        /// </summary>
        Reqd = 0x1F,

        /// <summary>
        /// Optional modifier: followed by a TypeDef or TypeRef token.
        /// </summary>
        CModOpt = 0x20,

        /// <summary>
        /// Implemented within the CLI.
        /// </summary>
        Internal = 0x21,
        Max = 0x22,

        /// <summary>
        /// Or’d with following element types.
        /// </summary>
        Modifier = 0x40,
        Sentinel = 0x41,

        /// <summary>
        /// Denotes a local variable that points at a pinned object.
        /// </summary>
        Pinned = 0x45,
    }
}