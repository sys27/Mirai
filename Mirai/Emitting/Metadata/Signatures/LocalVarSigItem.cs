namespace Mirai.Emitting.Metadata.Signatures
{
    public class LocalVarSigItem
    {
        public LocalVarSigItem(CustomMod? customMod, Type type)
        {
            CustomMod = customMod;
            Type = type;
        }

        public CustomMod? CustomMod { get; }
        public Type Type { get; }
    }
}