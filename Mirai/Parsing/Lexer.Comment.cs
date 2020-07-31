using System;
using Mirai.Parsing.Tokens;
using static Mirai.Parsing.Tokens.CommentType;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateComment(ref SourceReference reference)
        {
            var span = reference.Span;

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

                var token = XmlDoc.AsToken(reference.ForToken(index));

                // TODO: handle new line
                reference = reference.AdvanceColumnTo(index);

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

                var token = SingleLine.AsToken(reference.ForToken(index));

                reference = reference.AdvanceColumnTo(index);

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

                var token = MultiLine.AsToken(reference.ForToken(index));

                // TODO: handle new line
                reference = reference.AdvanceColumnTo(index);

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