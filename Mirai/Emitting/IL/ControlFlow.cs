namespace Mirai.Emitting.IL
{
    /// <summary>
    /// Control flow implications of instruction.
    /// </summary>
    public enum ControlFlow
    {
        /// <summary>
        /// Unconditional branch.
        /// </summary>
        Branch,

        Break,

        /// <summary>
        /// Method call.
        /// </summary>
        Call,

        /// <summary>
        /// Conditional branch.
        /// </summary>
        ConditionalBranch,

        /// <summary>
        /// Unused operation or prefix code.
        /// </summary>
        Meta,

        /// <summary>
        /// Control flow unaltered (“fall through”).
        /// </summary>
        Next,

        /// <summary>
        /// Return from method.
        /// </summary>
        Return,

        /// <summary>
        /// Throw or rethrow an exception.
        /// </summary>
        Throw,
    }
}