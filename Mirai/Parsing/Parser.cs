using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        private CompilationUnitNode? CompilationUnit(TokenEnumerator tokenEnumerator)
        {
            var usings = Usings(tokenEnumerator);

            throw new NotImplementedException();
        }

        private IEnumerable<UsingNode>? Usings(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private UsingNode? Using(TokenEnumerator tokenEnumerator)
        {
            var usingKeyword = tokenEnumerator.Keyword(Keywords.Using);
            if (usingKeyword == null)
                return null;

            var separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception(); // TODO:

            var qualifiedId = QualifiedId(tokenEnumerator);
            if (qualifiedId == null)
                throw new Exception(); // TODO:

            var semiColon = tokenEnumerator.Symbol(Symbols.SemiColon);
            if (semiColon == null)
                throw new Exception(); // TODO:

            var builder = UsingNode.Builder.Default
                .AddUsing(usingKeyword)
                .AddSeparators(separators)
                .AddNamespace(qualifiedId)
                .AddSemiColon(semiColon);

            return builder.Build();
        }

        private NamespaceNode? Namespace(TokenEnumerator tokenEnumerator)
        {
            var keyword = tokenEnumerator.Keyword(Keywords.Namespace);
            if (keyword == null)
                return null;

            var separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception(); // TODO:

            var qualifiedId = QualifiedId(tokenEnumerator);
            if (qualifiedId == null)
                throw new Exception(); // TODO:

            var builder = NamespaceNode.Builder.Default
                .AddNamespaceKeyword(keyword)
                .AddSeparators(separators)
                .AddNamespace(qualifiedId);

            // TODO: body

            return builder.Build();
        }

        private ISyntaxNode TypeDeclarations(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private ISyntaxNode TypeDeclaration(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private ClassNode? Class(TokenEnumerator tokenEnumerator)
        {
            throw new NotImplementedException();
        }

        private QualifiedIdNode? QualifiedId(TokenEnumerator tokenEnumerator)
        {
            var id = Id(tokenEnumerator);
            if (id == null)
                return null;

            var builder = QualifiedIdNode.Builder.Default
                .AddId(id);

            SymbolToken? dot;
            while ((dot = tokenEnumerator.Symbol(Symbols.Dot)) != null)
            {
                id = Id(tokenEnumerator);
                if (id == null)
                    throw new Exception(); // TODO:

                builder.AddDot(dot).AddId(id);
            }

            var semiColon = tokenEnumerator.Symbol(Symbols.SemiColon);
            if (semiColon == null)
                throw new Exception(); // TODO:

            return builder.Build();
        }

        private IdNode? Id(TokenEnumerator tokenEnumerator)
        {
            var idToken = tokenEnumerator.GetCurrent<IdToken>();
            if (idToken == null)
                return null;

            return new IdNode(idToken);
        }

        private ImmutableArray<IToken> Separators(TokenEnumerator tokenEnumerator)
        {
            var separators = ImmutableArray<IToken>.Empty;

            IToken? separator;
            while ((separator = Separator(tokenEnumerator)) != null)
                separators = separators.Add(separator);

            return separators;
        }

        private IToken? Separator(TokenEnumerator tokenEnumerator)
            => tokenEnumerator.Symbol(Symbols.Whitespace) ??
               tokenEnumerator.Symbol(Symbols.NewLine);
    }
}