using System;

namespace Mirai.Emitting.Metadata
{
    [Flags]
    public enum TypeAttributes : uint
    {
        /// <summary>
        /// Use this mask to retrieve visibility information. These 3 bits contain one of the following values:
        /// </summary>
        VisibilityMask = 0x00000007,

        /// <summary>
        /// Class is not public scope.
        /// </summary>
        NotPublic = 0x00000000,

        /// <summary>
        /// Class is public scope.
        /// </summary>
        Public = 0x00000001,

        /// <summary>
        /// Class is nested with public visibility.
        /// </summary>
        NestedPublic = 0x00000002,

        /// <summary>
        /// Class is nested with private visibility.
        /// </summary>
        NestedPrivate = 0x00000003,

        /// <summary>
        /// Class is nested with family visibility.
        /// </summary>
        NestedFamily = 0x00000004,

        /// <summary>
        /// Class is nested with assembly visibility.
        /// </summary>
        NestedAssembly = 0x00000005,

        /// <summary>
        /// Class is nested with family and assembly visibility.
        /// </summary>
        NestedFamANDAssem = 0x00000006,

        /// <summary>
        /// Class is nested with family or assembly visibility.
        /// </summary>
        NestedFamORAssem = 0x00000007,

        /// <summary>
        /// Use this mask to retrieve class layout information. These 2 bits contain one of the following values:
        /// </summary>
        LayoutMask = 0x00000018,

        /// <summary>
        /// Class fields are auto-laid out.
        /// </summary>
        AutoLayout = 0x00000000,

        /// <summary>
        /// Class fields are laid out sequentially.
        /// </summary>
        SequentialLayout = 0x00000008,

        /// <summary>
        /// Layout is supplied explicitly.
        /// </summary>
        ExplicitLayout = 0x00000010,

        /// <summary>
        /// Use this mask to distinguish whether a type declaration is an interface.  (Class vs. ValueType done based on whether it subclasses S.ValueType)
        /// </summary>
        ClassSemanticsMask = 0x00000020,

        /// <summary>
        /// Type is a class (or a value type).
        /// </summary>
        Class = 0x00000000,

        /// <summary>
        /// Type is an interface.
        /// </summary>
        Interface = 0x00000020,

        /// <summary>
        /// Class is abstract.
        /// </summary>
        Abstract = 0x00000080,

        /// <summary>
        /// Class is concrete and may not be extended.
        /// </summary>
        Sealed = 0x00000100,

        /// <summary>
        /// Class name is special. Name describes how.
        /// </summary>
        SpecialName = 0x00000400,

        /// <summary>
        /// Class / interface is imported.
        /// </summary>
        Import = 0x00001000,

        /// <summary>
        /// The class is Serializable.
        /// </summary>
        Serializable = 0x00002000,

        /// <summary>
        /// Type is a Windows Runtime type.
        /// </summary>
        WindowsRuntime = 0x00004000,

        /// <summary>
        /// Use this mask to retrieve string information for native interop. These 2 bits contain one of the following values:
        /// </summary>
        StringFormatMask = 0x00030000,

        /// <summary>
        /// LPTSTR is interpreted as ANSI in this class.
        /// </summary>
        AnsiClass = 0x00000000,

        /// <summary>
        /// LPTSTR is interpreted as UNICODE.
        /// </summary>
        UnicodeClass = 0x00010000,

        /// <summary>
        /// LPTSTR is interpreted automatically
        /// </summary>
        AutoClass = 0x00020000,

        /// <summary>
        /// A non-standard encoding specified by CustomFormatMask.
        /// </summary>
        CustomFormatClass = 0x00030000,

        /// <summary>
        /// Use this mask to retrieve non-standard encoding information for native interop. The meaning of the values of these 2 bits is unspecified.
        /// </summary>
        CustomFormatMask = 0x00C00000,

        /// <summary>
        /// Initialize the class any time before first static field access.
        /// </summary>
        BeforeFieldInit = 0x00100000,

        /// <summary>
        /// Runtime should check name encoding.
        /// </summary>
        RTSpecialName = 0x00000800,

        /// <summary>
        /// Class has security associate with it.
        /// </summary>
        HasSecurity = 0x00040000,

        ReservedMask = 0x00040800,

        /// <summary>
        /// This ExportedType entry is a type forwarder.
        /// </summary>
        IsTypeForwarder = 0x00200000,
    }
}