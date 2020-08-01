namespace Mirai.Emitting.FileFormats
{
    public class ExceptionClaus
    {
        /// <summary>
        /// Flags.
        /// </summary>
        public ExceptionClausFlags Flags { get; }

        /// <summary>
        /// Offset in bytes of try block from start of method body.
        /// </summary>
        public uint TryOffset { get; }

        /// <summary>
        /// Length in bytes of the try block.
        /// </summary>
        public uint TryLength { get; }

        /// <summary>
        /// Location of the handler for this try block.
        /// </summary>
        public uint HandlerOffset { get; }

        /// <summary>
        /// Size of the handler code in bytes.
        /// </summary>
        public uint HandlerLength { get; }

        /// <summary>
        /// Meta data token for a type-based exception handler.
        /// </summary>
        public uint ClassToken { get; }

        /// <summary>
        /// Offset in method body for filter-based exception handler.
        /// </summary>
        public uint FilterOffset { get; }
    }
}