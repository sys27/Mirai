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
            var reference = new SourceReference(sourceCode);

            while (!reference.IsEmpty)
            {
                // TODO: return tuple?
                var result = CreateWhitespace(ref reference) ??
                             CreateNewLine(ref reference) ??
                             CreateComment(ref reference) ??
                             CreateSymbol(ref reference) ??
                             CreateId(ref reference) ??
                             // CreateNumber(ref reference) ??
                             CreateString(ref reference) ??
                             CreateCharacter(ref reference) ??
                             CreatePreprocessorDirective(ref reference);

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