using System;
using System.Collections.Generic;
using Mirai.Tokens;

namespace Mirai
{
    public class Lexer
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
                var result = Whitespace(ref sourceCode, position) ??
                             NewLine(ref sourceCode, position) ??
                             Symbol(ref sourceCode, position) ??
                             Id(ref sourceCode, position) ??
                             String(ref sourceCode, position);

                if (result == null)
                    throw new Exception(); // TODO:

                position = result.SourcePosition;

                yield return result;
            }
        }

        private ITokenWithPosition Whitespace(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            var index = 0;
            while (char.IsWhiteSpace(span[index]))
                index++;

            if (index <= 0)
                return null;

            var token = SymbolToken.Whitespace.Wrap(position.AddColumn(index), sourceCode[..index]);

            sourceCode = sourceCode[index..];

            return token;
        }

        private ITokenWithPosition NewLine(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            if (span[0] == '\n' ||
                span[0] == '\r' ||
                (span.Length > 1 && span[0] == '\r' && span[1] == '\n'))
            {
                var token = SymbolToken.NewLine.Wrap(position.AddLine(1), sourceCode[..1]);

                sourceCode = sourceCode[1..];

                return token;
            }

            return null;
        }

        private ITokenWithPosition Symbol(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            // TODO: generate?
            var symbol = sourceCode.Span[0] switch
            {
                '(' => SymbolToken.OpenParenthesis,
                ')' => SymbolToken.CloseParenthesis,
                '{' => SymbolToken.OpenBrace,
                '}' => SymbolToken.CloseBrace,
                '.' => SymbolToken.Dot,
                ',' => SymbolToken.Comma,
                ';' => SymbolToken.SemiColon,
                '[' => SymbolToken.OpenSquare,
                ']' => SymbolToken.CloseSquare,
                '+' => SymbolToken.Plus,
                '-' => SymbolToken.Minus,
                '=' => SymbolToken.Assign,
                _ => null,
            };

            if (symbol == null)
                return null;

            var result = symbol.Wrap(position.AddColumn(1), sourceCode[..1]);

            sourceCode = sourceCode[1..];

            return result;
        }

        private ITokenWithPosition Id(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            if (!char.IsLetter(span[0]) && span[0] != '_')
                return null;

            var endIndex = 1;
            while (endIndex < span.Length &&
                   (char.IsLetterOrDigit(span[endIndex]) || span[endIndex] == '_'))
                endIndex++;

            var id = span[..endIndex];

            IToken token = null;

            if (Compare(id, "case"))
                token = KeywordToken.Case;
            else if (Compare(id, "class"))
                token = KeywordToken.Class;
            else if (Compare(id, "else"))
                token = KeywordToken.Else;
            else if (Compare(id, "enum"))
                token = KeywordToken.Enum;
            else if (Compare(id, "if"))
                token = KeywordToken.If;
            else if (Compare(id, "internal"))
                token = KeywordToken.Internal;
            else if (Compare(id, "namespace"))
                token = KeywordToken.Namespace;
            else if (Compare(id, "private"))
                token = KeywordToken.Private;
            else if (Compare(id, "protected"))
                token = KeywordToken.Protected;
            else if (Compare(id, "public"))
                token = KeywordToken.Public;
            else if (Compare(id, "static"))
                token = KeywordToken.Static;
            else if (Compare(id, "struct"))
                token = KeywordToken.Struct;
            else if (Compare(id, "switch"))
                token = KeywordToken.Switch;
            else if (Compare(id, "using"))
                token = KeywordToken.Using;
            else if (Compare(id, "var"))
                token = KeywordToken.Var;
            else if (Compare(id, "void"))
                token = KeywordToken.Void;

            ITokenWithPosition result;

            if (token != null)
            {
                result = token.Wrap(position.AddColumn(endIndex), sourceCode[..endIndex]);

                sourceCode = sourceCode[endIndex..];

                return result;
            }

            result = new IdToken(sourceCode[..endIndex], position.AddColumn(endIndex)); // TODO:

            sourceCode = sourceCode[endIndex..];

            return result;
        }

        private ITokenWithPosition String(
            ref ReadOnlyMemory<char> sourceCode,
            SourcePosition position)
        {
            var span = sourceCode.Span;

            if (span[0] != '"')
                return null;

            var endIndex = 1;
            while (endIndex < span.Length && span[endIndex] != '"')
                endIndex++;

            endIndex++;

            var value = sourceCode[1..(endIndex - 1)];
            // TODO: string?
            // TODO: handle position
            var token = new ValueToken<ReadOnlyMemory<char>>(value, position, sourceCode[..endIndex]);

            sourceCode = sourceCode[endIndex..];

            return token;
        }

        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool Compare(ReadOnlySpan<char> span, string str) =>
            span.Equals(str, StringComparison.Ordinal);
    }
}