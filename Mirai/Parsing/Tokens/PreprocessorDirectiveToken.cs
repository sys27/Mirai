using System;

namespace Mirai.Parsing.Tokens
{
    public class PreprocessorDirectiveToken : Token
    {
        public PreprocessorDirectiveToken(
            PreprocessorDirectives directive,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            Directive = directive;
        }

        public PreprocessorDirectives Directive { get; }
    }
}