namespace Mirai.Emitting.Metadata
{
    public enum AssemblyHashAlgorithm : uint
    {
        None = 0,
        MD5 = 0x8003,
        SHA1 = 0x8004,
        SHA256 = 0x800c,
        SHA384 = 0x800d,
        SHA512 = 0x800e,
    }
}