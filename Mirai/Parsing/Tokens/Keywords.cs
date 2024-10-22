namespace Mirai.Parsing.Tokens
{
    public enum Keywords
    {
        Abstract,
        As,
        Base,
        Bool,
        Break,
        Byte,
        Case,
        Catch,
        Char,
        Checked,
        Class,
        Const,
        Continue,
        Decimal,
        Default,
        Delegate,
        Do,
        Double,
        Else,
        Enum,
        Event,
        Explicit,
        Extern,
        False,
        Finally,
        Fixed,
        Float,
        For,
        Foreach,
        Goto,
        If,
        Implicit,
        In,
        Int,
        Interface,
        Internal,
        Is,
        Lock,
        Long,
        Namespace,
        New,
        Null,
        Object,
        Operator,
        Out,
        Override,
        Params,
        Private,
        Protected,
        Public,
        Readonly,
        Ref,
        Return,
        Sbyte,
        Sealed,
        Short,
        Sizeof,
        Stackalloc,
        Static,
        String,
        Struct,
        Switch,
        This,
        Throw,
        True,
        Try,
        Typeof,
        Uint,
        Ulong,
        Unchecked,
        Unsafe,
        Ushort,
        Using,
        Virtual,
        Void,
        Volatile,
        While,

        // contextual keywords
        Add,
        Alias,
        Ascending,
        Async,
        Await,
        By,
        Descending,
        Dynamic,
        Equals,
        From,
        Get,
        Global,
        Group,
        Into,
        Join,
        Let,
        OrderBy,
        Partial,
        Remove,
        Select,
        Set,
        Value,
        Var,
        Where,
        Yield
    }

    public static class KeywordsExtensions
    {
        public static KeywordToken AsToken(this Keywords keyword, SourceReference sourceReference)
            => new KeywordToken(keyword, sourceReference);
    }
}