namespace Mirai.Emitting.IL
{
    public enum StackBehaviourPush
    {
        /// <summary>
        /// No output value.
        /// </summary>
        Push0,

        /// <summary>
        /// One output value, type defined by data flow.
        /// </summary>
        Push1,

        /// <summary>
        /// Push one native integer or pointer.
        /// </summary>
        PushI,

        /// <summary>
        /// Push one object reference.
        /// </summary>
        PushRef,

        /// <summary>
        /// Push one 8-byte integer.
        /// </summary>
        PushI8,

        /// <summary>
        /// Push one 4-byte floating point number.
        /// </summary>
        PushR4,

        /// <summary>
        /// Push one 8-byte floating point number.
        /// </summary>
        PushR8,

        /// <summary>
        /// Two output values, type defined by data flow.
        /// </summary>
        Push1_Push1,

        /// <summary>
        /// Variable number of items pushed.
        /// </summary>
        VarPush,
    }
}