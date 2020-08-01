namespace Mirai.Emitting.FileFormats
{
    public class MethodBody
    {
        public ushort Header { get; } // TODO: Flags and Size
        public ushort Flags => (ushort) (Header & 0x0FFF);
        public byte Size => (byte) (Header >> 12);

        /// <summary>
        /// Maximum number of items on the operand stack.
        /// </summary>
        public ushort MaxStack { get; }

        /// <summary>
        /// Size in bytes of the actual method body.
        /// </summary>
        public uint CodeSize { get; }

        /// <summary>
        /// Meta Data token for a signature describing the layout of the local variables for the method. 0 means there are no local variables present.
        /// </summary>
        public uint LocalVarSigTok { get; }

        public byte[] Body { get; }

        public ExceptionRegion[] ExtraSections { get; }
    }
}