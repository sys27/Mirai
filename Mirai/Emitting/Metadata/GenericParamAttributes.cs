using System;

namespace Mirai.Emitting.Metadata
{
    [Flags]
    public enum GenericParamAttributes : ushort
    {
        /// <summary>
        /// These 2 bits contain one of the following values:
        /// </summary>
        VarianceMask = 0x0003,

        /// <summary>
        /// The generic parameter is non-variant and has no special constraints.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// The generic parameter is covariant.
        /// </summary>
        Covariant = 0x0001,

        /// <summary>
        /// The generic parameter is contravariant.
        /// </summary>
        Contravariant = 0x0002,

        /// <summary>
        /// These 3 bits contain one of the following values:
        /// </summary>
        SpecialConstraintMask = 0x001C,

        /// <summary>
        /// The generic parameter has the class special constraint.
        /// </summary>
        ReferenceTypeConstraint = 0x0004,

        /// <summary>
        /// The generic parameter has the valuetype special constraint.
        /// </summary>
        NotNullableValueTypeConstraint = 0x0008,

        /// <summary>
        /// The generic parameter has the .ctor special constraint.
        /// </summary>
        DefaultConstructorConstraint = 0x0010,
    }
}