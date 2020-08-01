namespace Mirai.Emitting.Metadata
{
    // 0x13
    public class EventPtr : Table
    {
        public EventPtr(uint recordIndex, uint @event) : base(recordIndex)
        {
            Event = @event;
        }

        public override TableType TableType => TableType.EventPtr;

        public uint Event { get; }
    }
}