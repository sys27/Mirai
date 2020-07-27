using System.Diagnostics;

namespace Mirai.Parsing.Tokens
{
    [DebuggerDisplay("Keyword: {" + nameof(keyword) + "}")]
    public class KeywordToken : IToken
    {
        private readonly Keywords keyword;

        private KeywordToken(Keywords keyword)
        {
            this.keyword = keyword;
        }

        public override string ToString() => keyword.ToString();

        // TODO: generate
        public static KeywordToken Case { get; } = new KeywordToken(Keywords.Case);

        public static KeywordToken Class { get; } = new KeywordToken(Keywords.Class);

        public static KeywordToken Else { get; } = new KeywordToken(Keywords.Else);

        public static KeywordToken Enum { get; } = new KeywordToken(Keywords.Enum);

        public static KeywordToken If { get; } = new KeywordToken(Keywords.If);

        public static KeywordToken Internal { get; } = new KeywordToken(Keywords.Internal);

        public static KeywordToken Namespace { get; } = new KeywordToken(Keywords.Namespace);

        public static KeywordToken Private { get; } = new KeywordToken(Keywords.Private);

        public static KeywordToken Protected { get; } = new KeywordToken(Keywords.Protected);

        public static KeywordToken Public { get; } = new KeywordToken(Keywords.Public);

        public static KeywordToken Static { get; } = new KeywordToken(Keywords.Static);

        public static KeywordToken Struct { get; } = new KeywordToken(Keywords.Struct);

        public static KeywordToken Switch { get; } = new KeywordToken(Keywords.Switch);

        public static KeywordToken Using { get; } = new KeywordToken(Keywords.Using);

        public static KeywordToken Var { get; } = new KeywordToken(Keywords.Var);

        public static KeywordToken Void { get; } = new KeywordToken(Keywords.Void);
    }
}