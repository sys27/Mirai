using System;
using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.LiteralType;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateCharacter(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;
            var index = 0;
            if (span[index] != '\'')
                return null;

            index++;

            while (span[index] != '\'')
                index++;

            index++;

            var token = Character.AsToken(position.AddColumn(index), sourceCode[..index]);

            sourceCode = sourceCode[index..];

            return token;
        }
    }
}