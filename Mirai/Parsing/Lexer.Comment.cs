using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateComment(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            throw new NotImplementedException();
        }
    }
}