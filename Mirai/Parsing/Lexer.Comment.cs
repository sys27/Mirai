using System;
using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.CommentType;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateComment(
            ref ReadOnlyMemory<char> sourceCode,
            ref SourcePosition position)
        {
            var span = sourceCode.Span;

            if (span.StartsWith(XmlDocSpan))
            {
                var index = XmlDocSpan.Length;
                while (index < span.Length)
                {
                    var (found, length) = IsNewLine(span);
                    if (found && span[index..].StartsWith(XmlDocSpan))
                        break;

                    index += length;
                }

                var token = XmlDoc.AsToken(position, sourceCode[..index]);

                // TODO: handle new line
                position = position.AdvanceColumnTo(index);
                sourceCode = sourceCode[index..];

                return token;
            }

            if (span.StartsWith(SingleLineSpan))
            {
                var index = SingleLineSpan.Length;
                while (index < span.Length)
                {
                    var (found, length) = IsNewLine(span);
                    if (found)
                        break;

                    index += length;
                }

                var token = SingleLine.AsToken(position, sourceCode[..index]);

                position = position.AdvanceColumnTo(index);
                sourceCode = sourceCode[index..];

                return token;
            }

            if (span.StartsWith(MultiLineOpenSpan))
            {
                var index = MultiLineOpenSpan.Length;
                while (index < span.Length)
                {
                    if (span[index..].StartsWith(MultiLineCloseSpan))
                    {
                        index += MultiLineCloseSpan.Length;
                        break;
                    }

                    index++;
                }

                var token = MultiLine.AsToken(position, sourceCode[..index]);

                // TODO: handle new line
                position = position.AdvanceColumnTo(index);
                sourceCode = sourceCode[index..];

                return token;
            }

            return null;
        }

        // TODO: single property span?
        private ReadOnlySpan<char> SingleLineSpan => new[] { '/', '/' };
        private ReadOnlySpan<char> MultiLineOpenSpan => new[] { '/', '*' };
        private ReadOnlySpan<char> MultiLineCloseSpan => new[] { '*', '/' };
        private ReadOnlySpan<char> XmlDocSpan => new[] { '/', '/', '/' };
    }
}