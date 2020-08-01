namespace Mirai.Emitting.Metadata
{
    // 0x12
    public class EventMap : Table
    {
        public EventMap(uint recordIndex, uint parent, uint eventList)
            : base(recordIndex)
        {
            Parent = parent;
            EventList = eventList;
        }

        public override TableType TableType => TableType.EventMap;

        public uint Parent { get; }
        public uint EventList { get; }
    }
}