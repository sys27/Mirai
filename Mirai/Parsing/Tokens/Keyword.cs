using System;
using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Keyword: {" + nameof(keyword) + "}")]
    public sealed class Keyword
    {
        private readonly Keywords keyword;

        private Keyword(Keywords keyword)
        {
            this.keyword = keyword;
        }

        public override string ToString() => keyword.ToString();

        public KeywordToken AsToken(SourcePosition sourcePosition, ReadOnlyMemory<char> sourceCode)
            => new KeywordToken(this, sourcePosition, sourceCode);

        // TODO: generate
        public static Keyword Case { get; } = new Keyword(Keywords.Case);

        public static Keyword Class { get; } = new Keyword(Keywords.Class);

        public static Keyword Else { get; } = new Keyword(Keywords.Else);

        public static Keyword Enum { get; } = new Keyword(Keywords.Enum);

        public static Keyword If { get; } = new Keyword(Keywords.If);

        public static Keyword Internal { get; } = new Keyword(Keywords.Internal);

        public static Keyword Namespace { get; } = new Keyword(Keywords.Namespace);

        public static Keyword Private { get; } = new Keyword(Keywords.Private);

        public static Keyword Protected { get; } = new Keyword(Keywords.Protected);

        public static Keyword Public { get; } = new Keyword(Keywords.Public);

        public static Keyword Static { get; } = new Keyword(Keywords.Static);

        public static Keyword Struct { get; } = new Keyword(Keywords.Struct);

        public static Keyword Switch { get; } = new Keyword(Keywords.Switch);

        public static Keyword Using { get; } = new Keyword(Keywords.Using);

        public static Keyword Var { get; } = new Keyword(Keywords.Var);

        public static Keyword Void { get; } = new Keyword(Keywords.Void);
    }
}