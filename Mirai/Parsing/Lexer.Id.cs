using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateId(
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

            Keyword keyword = null;

            if (Compare(id, "case"))
                keyword = Keyword.Case;
            else if (Compare(id, "class"))
                keyword = Keyword.Class;
            else if (Compare(id, "else"))
                keyword = Keyword.Else;
            else if (Compare(id, "enum"))
                keyword = Keyword.Enum;
            else if (Compare(id, "if"))
                keyword = Keyword.If;
            else if (Compare(id, "internal"))
                keyword = Keyword.Internal;
            else if (Compare(id, "namespace"))
                keyword = Keyword.Namespace;
            else if (Compare(id, "private"))
                keyword = Keyword.Private;
            else if (Compare(id, "protected"))
                keyword = Keyword.Protected;
            else if (Compare(id, "public"))
                keyword = Keyword.Public;
            else if (Compare(id, "static"))
                keyword = Keyword.Static;
            else if (Compare(id, "struct"))
                keyword = Keyword.Struct;
            else if (Compare(id, "switch"))
                keyword = Keyword.Switch;
            else if (Compare(id, "using"))
                keyword = Keyword.Using;
            else if (Compare(id, "var"))
                keyword = Keyword.Var;
            else if (Compare(id, "void"))
                keyword = Keyword.Void;

            IToken result;

            if (keyword != null)
            {
                result = keyword.AsToken(position.AddColumn(endIndex), sourceCode[..endIndex]);

                sourceCode = sourceCode[endIndex..];

                return result;
            }

            result = new IdToken(sourceCode[..endIndex], position.AddColumn(endIndex)); // TODO:

            sourceCode = sourceCode[endIndex..];

            return result;
        }
    }
}