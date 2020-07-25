using System;

namespace Mirai.Tokens
{
    public interface ITokenWithPosition : IToken
    {
        SourcePosition SourcePosition { get; }
        ReadOnlyMemory<char> SourceCode { get; }
    }
}