using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Parser
    {
        private class TokenEnumerator
        {
            private readonly IToken[] list;
            private int index;

            public TokenEnumerator(IToken[] list)
            {
                this.list = list;
            }

            private bool MoveNext()
            {
                if (index >= list.Length)
                {
                    index = list.Length;

                    return false;
                }

                ++index;

                return true;
            }

            private TToken? Peek<TToken>() where TToken : class, IToken
            {
                if (index >= list.Length)
                    return null;

                return list[index] as TToken;
            }

            public TToken? GetCurrent<TToken>() where TToken : class, IToken
            {
                var token = Peek<TToken>();
                if (token != null)
                    MoveNext();

                return token;
            }

            public SymbolToken? Symbol(Symbols symbol)
            {
                var token = Peek<SymbolToken>();
                if (token?.Symbol == symbol)
                {
                    MoveNext();

                    return token;
                }

                return null;
            }

            public KeywordToken? Keyword(Keywords keyword)
            {
                var token = Peek<KeywordToken>();
                if (token?.Keyword == keyword)
                {
                    MoveNext();

                    return token;
                }

                return null;
            }

            public Scope CreateScope() => new Scope(this);

            public void Rollback(Scope scope) => scope.Rollback(this);

            public bool IsEnd => index >= list.Length;

            public readonly struct Scope
            {
                private readonly int position;

                public Scope(TokenEnumerator tokenEnumerator)
                {
                    position = tokenEnumerator.index;
                }

                public void Rollback(TokenEnumerator tokenEnumerator)
                {
                    tokenEnumerator.index = position;
                }
            }
        }
    }
}