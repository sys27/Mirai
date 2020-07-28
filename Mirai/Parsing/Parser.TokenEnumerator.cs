using System.Collections.Generic;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Parser
    {
        private class TokenEnumerator
        {
            private readonly IEnumerator<IToken> enumerator;
            // TODO: add array buffer?

            public TokenEnumerator(IEnumerable<IToken> tokens)
            {
                enumerator = tokens.GetEnumerator(); // TODO: change collection?
                enumerator.MoveNext();
            }

            private bool MoveNext()
            {
                return IsEnd = enumerator.MoveNext();
            }

            private TToken? Peek<TToken>() where TToken : class, IToken
            {
                return enumerator.Current as TToken;
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

            public bool IsEnd { get; private set; }

            // public Scope CreateScope() => new Scope(this);

            // public void Rollback(Scope scope) => scope.Rollback(this);

            // public readonly struct Scope
            // {
            //     private readonly int position;

            //     public Scope(TokenEnumerator tokenEnumerator)
            //     {
            //         position = tokenEnumerator.index;
            //     }

            //     public void Rollback(TokenEnumerator tokenEnumerator)
            //     {
            //         tokenEnumerator.index = position;
            //     }
            // }
        }
    }
}