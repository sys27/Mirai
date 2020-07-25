using System;

namespace Mirai.Tokens
{
    public static class TokenExtensions
    {
        public static TokenWrapper<TToken> Wrap<TToken>(
            this TToken token,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode) where TToken : IToken
        {
            return new TokenWrapper<TToken>(token, sourcePosition, sourceCode);
        }
    }
}