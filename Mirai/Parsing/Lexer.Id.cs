using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private ITokenWithPosition? Id(
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
    }
}