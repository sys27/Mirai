using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Token: {" + nameof(Token) + "}, Count: {" + nameof(Length) + "}")]
    public class TokenWrapper<TToken> : ITokenWithPosition where TToken : IToken
    {
        public TokenWrapper(
            TToken token,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
        {
            Token = token;
            SourcePosition = sourcePosition;
            SourceCode = sourceCode;
        }

        public TToken Token { get; }
        public SourcePosition SourcePosition { get; }
        public ReadOnlyMemory<char> SourceCode { get; }
        public int Length => SourceCode.Length;
    }
}