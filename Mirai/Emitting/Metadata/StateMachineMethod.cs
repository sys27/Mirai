namespace Mirai.Emitting.Metadata
{
    // 0x36
    public class StateMachineMethod : Table
    {
        public StateMachineMethod(uint recordIndex, uint moveNextMethod, uint kickoffMethod)
            : base(recordIndex)
        {
            MoveNextMethod = moveNextMethod;
            KickoffMethod = kickoffMethod;
        }

        public override TableType TableType => TableType.StateMachineMethod;

        public uint MoveNextMethod { get; }
        public uint KickoffMethod { get; }
    }
}