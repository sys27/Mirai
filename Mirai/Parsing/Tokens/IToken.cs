using System;

namespace Mirai.Parsing.Tokens
{
    public interface IToken
    {
        SourcePosition SourcePosition { get; }
        ReadOnlyMemory<char> SourceCode { get; }
    }
}