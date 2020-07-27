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

            if (!char.IsLetter(span[0]) && span[0] != '_' && span[0] != '@')
                return null;

            var endIndex = 1;
            while (endIndex < span.Length &&
                   (char.IsLetterOrDigit(span[endIndex]) || span[endIndex] == '_'))
                endIndex++;

            var id = span[..endIndex];

            Keywords? keyword = null;

            // TODO:
            if (Compare(id, "abstract"))
                keyword = Keywords.Abstract;
            else if (Compare(id, "as"))
                keyword = Keywords.As;
            else if (Compare(id, "base"))
                keyword = Keywords.Base;
            else if (Compare(id, "bool"))
                keyword = Keywords.Bool;
            else if (Compare(id, "break"))
                keyword = Keywords.Break;
            else if (Compare(id, "byte"))
                keyword = Keywords.Byte;
            else if (Compare(id, "case"))
                keyword = Keywords.Case;
            else if (Compare(id, "catch"))
                keyword = Keywords.Catch;
            else if (Compare(id, "char"))
                keyword = Keywords.Char;
            else if (Compare(id, "checked"))
                keyword = Keywords.Checked;
            else if (Compare(id, "class"))
                keyword = Keywords.Class;
            else if (Compare(id, "const"))
                keyword = Keywords.Const;
            else if (Compare(id, "continue"))
                keyword = Keywords.Continue;
            else if (Compare(id, "decimal"))
                keyword = Keywords.Decimal;
            else if (Compare(id, "default"))
                keyword = Keywords.Default;
            else if (Compare(id, "delegate"))
                keyword = Keywords.Delegate;
            else if (Compare(id, "do"))
                keyword = Keywords.Do;
            else if (Compare(id, "double"))
                keyword = Keywords.Double;
            else if (Compare(id, "else"))
                keyword = Keywords.Else;
            else if (Compare(id, "enum"))
                keyword = Keywords.Enum;
            else if (Compare(id, "event"))
                keyword = Keywords.Event;
            else if (Compare(id, "explicit"))
                keyword = Keywords.Explicit;
            else if (Compare(id, "extern"))
                keyword = Keywords.Extern;
            else if (Compare(id, "false"))
                keyword = Keywords.False;
            else if (Compare(id, "finally"))
                keyword = Keywords.Finally;
            else if (Compare(id, "fixed"))
                keyword = Keywords.Fixed;
            else if (Compare(id, "float"))
                keyword = Keywords.Float;
            else if (Compare(id, "for"))
                keyword = Keywords.For;
            else if (Compare(id, "foreach"))
                keyword = Keywords.Foreach;
            else if (Compare(id, "goto"))
                keyword = Keywords.Goto;
            else if (Compare(id, "if"))
                keyword = Keywords.If;
            else if (Compare(id, "implicit"))
                keyword = Keywords.Implicit;
            else if (Compare(id, "in"))
                keyword = Keywords.In;
            else if (Compare(id, "int"))
                keyword = Keywords.Int;
            else if (Compare(id, "interface"))
                keyword = Keywords.Interface;
            else if (Compare(id, "internal"))
                keyword = Keywords.Internal;
            else if (Compare(id, "is"))
                keyword = Keywords.Is;
            else if (Compare(id, "lock"))
                keyword = Keywords.Lock;
            else if (Compare(id, "long"))
                keyword = Keywords.Long;
            else if (Compare(id, "namespace"))
                keyword = Keywords.Namespace;
            else if (Compare(id, "new"))
                keyword = Keywords.New;
            else if (Compare(id, "null"))
                keyword = Keywords.Null;
            else if (Compare(id, "object"))
                keyword = Keywords.Object;
            else if (Compare(id, "operator"))
                keyword = Keywords.Operator;
            else if (Compare(id, "out"))
                keyword = Keywords.Out;
            else if (Compare(id, "override"))
                keyword = Keywords.Override;
            else if (Compare(id, "params"))
                keyword = Keywords.Params;
            else if (Compare(id, "private"))
                keyword = Keywords.Private;
            else if (Compare(id, "protected"))
                keyword = Keywords.Protected;
            else if (Compare(id, "public"))
                keyword = Keywords.Public;
            else if (Compare(id, "readonly"))
                keyword = Keywords.Readonly;
            else if (Compare(id, "ref"))
                keyword = Keywords.Ref;
            else if (Compare(id, "return"))
                keyword = Keywords.Return;
            else if (Compare(id, "sbyte"))
                keyword = Keywords.Sbyte;
            else if (Compare(id, "sealed"))
                keyword = Keywords.Sealed;
            else if (Compare(id, "short"))
                keyword = Keywords.Short;
            else if (Compare(id, "sizeof"))
                keyword = Keywords.Sizeof;
            else if (Compare(id, "stackalloc"))
                keyword = Keywords.Stackalloc;
            else if (Compare(id, "static"))
                keyword = Keywords.Static;
            else if (Compare(id, "string"))
                keyword = Keywords.String;
            else if (Compare(id, "struct"))
                keyword = Keywords.Struct;
            else if (Compare(id, "switch"))
                keyword = Keywords.Switch;
            else if (Compare(id, "this"))
                keyword = Keywords.This;
            else if (Compare(id, "throw"))
                keyword = Keywords.Throw;
            else if (Compare(id, "true"))
                keyword = Keywords.True;
            else if (Compare(id, "try"))
                keyword = Keywords.Try;
            else if (Compare(id, "typeof"))
                keyword = Keywords.Typeof;
            else if (Compare(id, "uint"))
                keyword = Keywords.Uint;
            else if (Compare(id, "ulong"))
                keyword = Keywords.Ulong;
            else if (Compare(id, "unchecked"))
                keyword = Keywords.Unchecked;
            else if (Compare(id, "unsafe"))
                keyword = Keywords.Unsafe;
            else if (Compare(id, "ushort"))
                keyword = Keywords.Ushort;
            else if (Compare(id, "using"))
                keyword = Keywords.Using;
            else if (Compare(id, "virtual"))
                keyword = Keywords.Virtual;
            else if (Compare(id, "void"))
                keyword = Keywords.Void;
            else if (Compare(id, "volatile"))
                keyword = Keywords.Volatile;
            else if (Compare(id, "while"))
                keyword = Keywords.While;
            else if (Compare(id, "add"))
                keyword = Keywords.Add;
            else if (Compare(id, "alias"))
                keyword = Keywords.Alias;
            else if (Compare(id, "ascending"))
                keyword = Keywords.Ascending;
            else if (Compare(id, "async"))
                keyword = Keywords.Async;
            else if (Compare(id, "await"))
                keyword = Keywords.Await;
            else if (Compare(id, "by"))
                keyword = Keywords.By;
            else if (Compare(id, "descending"))
                keyword = Keywords.Descending;
            else if (Compare(id, "dynamic"))
                keyword = Keywords.Dynamic;
            else if (Compare(id, "equals"))
                keyword = Keywords.Equals;
            else if (Compare(id, "from"))
                keyword = Keywords.From;
            else if (Compare(id, "get"))
                keyword = Keywords.Get;
            else if (Compare(id, "global"))
                keyword = Keywords.Global;
            else if (Compare(id, "group"))
                keyword = Keywords.Group;
            else if (Compare(id, "into"))
                keyword = Keywords.Into;
            else if (Compare(id, "join"))
                keyword = Keywords.Join;
            else if (Compare(id, "let"))
                keyword = Keywords.Let;
            else if (Compare(id, "orderby"))
                keyword = Keywords.OrderBy;
            else if (Compare(id, "partial"))
                keyword = Keywords.Partial;
            else if (Compare(id, "remove"))
                keyword = Keywords.Remove;
            else if (Compare(id, "select"))
                keyword = Keywords.Select;
            else if (Compare(id, "set"))
                keyword = Keywords.Set;
            else if (Compare(id, "value"))
                keyword = Keywords.Value;
            else if (Compare(id, "var"))
                keyword = Keywords.Var;
            else if (Compare(id, "where"))
                keyword = Keywords.Where;
            else if (Compare(id, "yield"))
                keyword = Keywords.Yield;

            var result = keyword?.AsToken(position.AddColumn(endIndex), sourceCode[..endIndex]) ??
                         (IToken) new IdToken(sourceCode[..endIndex], position.AddColumn(endIndex));

            sourceCode = sourceCode[endIndex..];

            return result;
        }
    }
}