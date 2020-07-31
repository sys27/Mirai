namespace Mirai.Parsing.Tokens
{
    public interface IToken : INode
    {
        SourceReference SourceReference { get; }
    }
}