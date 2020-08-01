using System;

namespace Mirai.Emitting.FileFormats
{
    [Flags]
    public enum ExceptionClausFlags : uint
    {
        /// <summary>
        /// A typed exception clause.
        /// </summary>
        COR_ILEXCEPTION_CLAUSE_EXCEPTION = 0x0000,

        /// <summary>
        /// An exception filter and handler clause.
        /// </summary>
        COR_ILEXCEPTION_CLAUSE_FILTER = 0x0001,

        /// <summary>
        /// A finally clause.
        /// </summary>
        COR_ILEXCEPTION_CLAUSE_FINALLY = 0x0002,

        /// <summary>
        /// Fault clause (finally that is called on exception only).
        /// </summary>
        COR_ILEXCEPTION_CLAUSE_FAULT = 0x0004,
    }
}