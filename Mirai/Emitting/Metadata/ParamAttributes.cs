using System;

namespace Mirai.Emitting.Metadata
{
    [Flags]
    public enum ParamAttributes : ushort
    {
        /// <summary>
        /// No flag is specified.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Param is [In].
        /// </summary>
        In = 0x0001,

        /// <summary>
        /// Param is [Out].
        /// </summary>
        Out = 0x0002,

        /// <summary>
        /// Param is [lcid].
        /// </summary>
        Lcid = 0x0004,

        /// <summary>
        /// Param is [Retval]
        /// </summary>
        Retval = 0x0008,

        /// <summary>
        /// Param is optional.
        /// </summary>
        Optional = 0x0010,

        /// <summary>
        /// Param has default value.
        /// </summary>
        HasDefault = 0x1000,

        /// <summary>
        /// Param has FieldMarshal.
        /// </summary>
        HasFieldMarshal = 0x2000,
    }
}