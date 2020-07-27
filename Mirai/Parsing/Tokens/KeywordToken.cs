using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Keyword: {" + nameof(Keyword) + "}")]
    public class KeywordToken : Token
    {
        public KeywordToken(
            Keywords keyword,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            Keyword = keyword;
        }

        public override string ToString() => Keyword.ToString();

        public Keywords Keyword { get; }
    }
}