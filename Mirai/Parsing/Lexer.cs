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
                var result = CreateWhitespace(ref sourceCode, position) ??
                             CreateNewLine(ref sourceCode, position) ??
                             CreateSymbol(ref sourceCode, position) ??
                             CreateId(ref sourceCode, position) ??
                             CreateString(ref sourceCode, position);

                if (result == null)
                    throw new Exception(); // TODO:

                position = result.SourcePosition;

                yield return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool Compare(ReadOnlySpan<char> span, string str) =>
            span.Equals(str, StringComparison.Ordinal);
    }
}