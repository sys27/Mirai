using System;

namespace Mirai.Emitting.Metadata
{
    [Flags]
    public enum MethodSemanticsAttributes : ushort
    {
        /// <summary>
        /// Setter for property.
        /// </summary>
        Setter = 0x0001,

        /// <summary>
        /// Getter for property.
        /// </summary>
        Getter = 0x0002,

        /// <summary>
        /// Other method for property or event.
        /// </summary>
        Other = 0x0004,

        /// <summary>
        /// AddOn method for event. This refers to the required add_ method for events.
        /// </summary>
        AddOn = 0x0008,

        /// <summary>
        /// RemoveOn method for event. This refers to the required remove_ method for events.
        /// </summary>
        RemoveOn = 0x0010,

        /// <summary>
        /// Fire method for event. This refers to the optional raise_ method for events.
        /// </summary>
        Fire = 0x0020,
    }
}