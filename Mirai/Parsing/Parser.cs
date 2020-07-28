using System;
using System.Collections.Generic;
using System.Linq;
using Mirai.Parsing.SyntaxNodes;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Parser
    {
        public ISyntaxNode Parse(IEnumerable<IToken> tokens)
        {
            if (tokens == null)
                throw new ArgumentNullException(nameof(tokens));

            // TODO: !!!
            var tokensArray = tokens as IToken[] ?? tokens.ToArray();
            if (!tokensArray.Any())
                throw new ArgumentNullException(nameof(tokens));

            var tokenEnumerator = new TokenEnumerator(tokensArray);
            var exp = CompilationUnit(tokenEnumerator);
            if (exp == null || !tokenEnumerator.IsEnd)
                throw new Exception(); // TODO:

            return exp;
        }

        private CompilationUnit? CompilationUnit(TokenEnumerator tokenEnumerator)
        {
            var usings = Usings(tokenEnumerator);

            throw new NotImplementedException();
        }

        private IEnumerable<Using>? Usings(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private Using? Using(TokenEnumerator tokenEnumerator)
        {
            var usingKeyword = tokenEnumerator.Keyword(Keywords.Using);
            if (usingKeyword == null)
                return null;

            var whitespace = tokenEnumerator.Symbol(Symbols.Whitespace);
            if (whitespace == null)
                throw new Exception(); // TODO:

            var qualifiedId = QualifiedId(tokenEnumerator);
            if (qualifiedId == null)
                throw new Exception(); // TODO:

            throw new NotImplementedException();
        }

        private Namespace? Namespace(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private Class? Class(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private QualifiedId QualifiedId(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private Id Id(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }
    }
}