using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        public IEnumerable<IToken> Tokenize(string sourceCode)
        {
            if (sourceCode == null)
                throw new ArgumentNullException(nameof(sourceCode));

            return Tokenize(sourceCode.AsMemory());
        }

        public IEnumerable<IToken> Tokenize(ReadOnlyMemory<char> sourceCode)
        {
            var position = SourcePosition.Default;

            while (sourceCode.Length > 0)
            {
                var result = CreateWhitespace(ref sourceCode, ref position) ??
                             CreateNewLine(ref sourceCode, ref position) ??
                             CreateComment(ref sourceCode, ref position) ??
                             CreateSymbol(ref sourceCode, ref position) ??
                             CreateId(ref sourceCode, ref position) ??
                             // CreateNumber(ref sourceCode, ref position) ??
                             CreateString(ref sourceCode, ref position) ??
                             CreateCharacter(ref sourceCode, ref position) ??
                             CreatePreprocessorDirective(ref sourceCode, ref position);

                if (result == null)
                    throw new Exception(); // TODO:

                yield return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool Compare(ReadOnlySpan<char> span, string str) =>
            span.Equals(str, StringComparison.Ordinal);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsInRange(char symbol, char min, char max)
            => (uint) (symbol - min) <= (uint) (max - min);
    }
}