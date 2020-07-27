using System;

namespace Mirai.Parsing.Tokens
{
    public interface ITokenWithPosition : IToken
    {
        SourcePosition SourcePosition { get; }
        ReadOnlyMemory<char> SourceCode { get; }
    }
}