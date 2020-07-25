using System;
using System.Diagnostics;

namespace Mirai.Tokens
{
    [DebuggerDisplay("Keyword: {" + nameof(keyword) + "}")]
    public class KeywordToken : IToken
    {
        private readonly ReadOnlyMemory<char> keyword;

        private KeywordToken(string keyword)
        {
            this.keyword = keyword.AsMemory();
        }

        public static KeywordToken Class { get; } = new KeywordToken("class");

        public static KeywordToken Namespace { get; } = new KeywordToken("namespace");

        public static KeywordToken Public { get; } = new KeywordToken("public");

        public static KeywordToken Static { get; } = new KeywordToken("static");

        public static KeywordToken Using { get; } = new KeywordToken("using");

        public static KeywordToken Void { get; } = new KeywordToken("void");
    }
}