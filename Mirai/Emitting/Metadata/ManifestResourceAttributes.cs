using System;

namespace Mirai.Emitting.Metadata
{
    [Flags]
    public enum ManifestResourceAttributes : uint
    {
        /// <summary>
        /// These 3 bits contain one of the following values:
        /// </summary>
        VisibilityMask = 0x0007,

        /// <summary>
        /// The Resource is exported from the Assembly.
        /// </summary>
        Public = 0x0001,

        /// <summary>
        /// The Resource is private to the Assembly.
        /// </summary>
        Private = 0x0002,
    }
}