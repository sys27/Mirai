using System;

namespace Mirai.Parsing.Tokens
{
    public interface IToken : INode
    {
        SourcePosition SourcePosition { get; }
        ReadOnlyMemory<char> SourceCode { get; }
    }
}