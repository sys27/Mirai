namespace Mirai.Emitting.Metadata
{
    public enum EventAttributes : ushort
    {
        /// <summary>
        /// Event is special.
        /// </summary>
        SpecialName = 0x0200,

        /// <summary>
        /// CLI provides 'special' behavior, depending upon the name of the event.
        /// </summary>
        RTSpecialName = 0x0400,
    }
}