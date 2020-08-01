using System;

namespace Mirai.Emitting.Metadata
{
    [Flags]
    public enum AssemblyFlags : uint
    {
        /// <summary>
        /// The assembly reference holds the full (unhashed) public key.
        /// Not applicable on assembly definition.
        /// </summary>
        PublicKey = 0x00000001,

        /// <summary>
        /// The implementation of the referenced assembly used at runtime is not expected to match the version seen at compile time.
        /// </summary>
        Retargetable = 0x00000100,

        /// <summary>
        /// The assembly contains Windows Runtime code.
        /// </summary>
        WindowsRuntime = 0x00000200,

        /// <summary>
        /// Content type mask. Masked bits correspond to values of <see cref="System.Reflection.AssemblyContentType"/>.
        /// </summary>
        ContentTypeMask = 0x00000e00,

        /// <summary>
        /// Specifies that just-in-time (JIT) compiler optimization is disabled for the assembly.
        /// </summary>
        DisableJitCompileOptimizer = 0x4000,

        /// <summary>
        /// Specifies that just-in-time (JIT) compiler tracking is enabled for the assembly.
        /// </summary>
        EnableJitCompileTracking = 0x8000,
    }
}