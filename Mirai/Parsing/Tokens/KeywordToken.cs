using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Keyword: {" + nameof(keyword) + "}")]
    public class KeywordToken : Token
    {
        private readonly Keyword keyword;

        public KeywordToken(
            Keyword keyword,
            SourcePosition sourcePosition,
            ReadOnlyMemory<char> sourceCode)
            : base(sourcePosition, sourceCode)
        {
            this.keyword = keyword;
        }

        public override string ToString() => keyword.ToString();
    }
}