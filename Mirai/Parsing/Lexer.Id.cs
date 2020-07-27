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

            Keywords? keyword = null;

            if (Compare(id, "case"))
                keyword = Keywords.Case;
            else if (Compare(id, "class"))
                keyword = Keywords.Class;
            else if (Compare(id, "else"))
                keyword = Keywords.Else;
            else if (Compare(id, "enum"))
                keyword = Keywords.Enum;
            else if (Compare(id, "if"))
                keyword = Keywords.If;
            else if (Compare(id, "internal"))
                keyword = Keywords.Internal;
            else if (Compare(id, "namespace"))
                keyword = Keywords.Namespace;
            else if (Compare(id, "private"))
                keyword = Keywords.Private;
            else if (Compare(id, "protected"))
                keyword = Keywords.Protected;
            else if (Compare(id, "public"))
                keyword = Keywords.Public;
            else if (Compare(id, "static"))
                keyword = Keywords.Static;
            else if (Compare(id, "struct"))
                keyword = Keywords.Struct;
            else if (Compare(id, "switch"))
                keyword = Keywords.Switch;
            else if (Compare(id, "using"))
                keyword = Keywords.Using;
            else if (Compare(id, "var"))
                keyword = Keywords.Var;
            else if (Compare(id, "void"))
                keyword = Keywords.Void;

            var result = keyword?.AsToken(position.AddColumn(endIndex), sourceCode[..endIndex]) ??
                         (IToken) new IdToken(sourceCode[..endIndex], position.AddColumn(endIndex));

            sourceCode = sourceCode[endIndex..];

            return result;
        }
    }
}