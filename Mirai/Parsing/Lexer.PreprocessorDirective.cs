using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreatePreprocessorDirective(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            var index = 0;
            if (span[index++] == '#')
                return null;

            while (index < span.Length && char.IsLetter(span[index]))
                index++;

            var directiveSpan = span[..index];

            PreprocessorDirectives? directive = null;

            // TODO: to keywords?
            // TODO: dictionary, string, switch??
            if (Compare(directiveSpan, "if"))
                directive = PreprocessorDirectives.If;
            else if (Compare(directiveSpan, "else"))
                directive = PreprocessorDirectives.Else;
            else if (Compare(directiveSpan, "elif"))
                directive = PreprocessorDirectives.Elif;
            else if (Compare(directiveSpan, "endif"))
                directive = PreprocessorDirectives.Endif;
            else if (Compare(directiveSpan, "define"))
                directive = PreprocessorDirectives.Define;
            else if (Compare(directiveSpan, "undef"))
                directive = PreprocessorDirectives.Undef;
            else if (Compare(directiveSpan, "warning"))
                directive = PreprocessorDirectives.Warning;
            else if (Compare(directiveSpan, "error"))
                directive = PreprocessorDirectives.Error;
            else if (Compare(directiveSpan, "line"))
                directive = PreprocessorDirectives.Line;
            else if (Compare(directiveSpan, "region"))
                directive = PreprocessorDirectives.Region;
            else if (Compare(directiveSpan, "endregion"))
                directive = PreprocessorDirectives.Endregion;
            else if (Compare(directiveSpan, "pragma"))
                directive = PreprocessorDirectives.Pragma;
            else if (Compare(directiveSpan, "nullable"))
                directive = PreprocessorDirectives.Nullable;

            if (directive == null)
                return null;

            var token = directive.Value.AsToken(position.AddColumn(index), sourceCode[..index]);

            sourceCode = sourceCode[index..];

            return token;
        }
    }
}