using System;

namespace Mirai.Parsing.Tokens
{
    public enum PreprocessorDirectives
    {
        If,
        Else,
        Elif,
        Endif,
        Define,
        Undef,
        Warning,
        Error,
        Line,
        Region,
        Endregion,
        Pragma,
        Nullable,
    }

    public static class PreprocessorDirectivesExtensions
    {
        public static PreprocessorDirectiveToken AsToken(
            this PreprocessorDirectives directive,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            => new PreprocessorDirectiveToken(directive, sourcePosition, sourceCode);
    }
}