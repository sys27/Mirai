using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

            var tokenEnumerator = new TokenEnumerator(tokens);
            var compilationUnitNode = CompilationUnit(tokenEnumerator);
            if (compilationUnitNode == null || !tokenEnumerator.IsEnd)
                throw new Exception(); // TODO:

            return compilationUnitNode;
        }

        private CompilationUnitNode CompilationUnit(TokenEnumerator tokenEnumerator)
        {
            var builder = CompilationUnitNode.Builder.Create();

            while (true)
            {
                var separators = Separators(tokenEnumerator);
                if (!separators.IsEmpty)
                    builder.AddSeparators(separators);

                var usingNode = Using(tokenEnumerator);
                if (usingNode != null)
                {
                    builder.AddUsing(usingNode);
                    continue;
                }

                var @namespace = Namespace(tokenEnumerator);
                if (@namespace != null)
                {
                    builder.AddNamespace(@namespace);
                    continue;
                }

                var classNode = Class(tokenEnumerator);
                if (classNode != null)
                {
                    builder.AddClass(classNode);
                    continue;
                }

                break;
            }

            return builder.Build();
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

            var builder = UsingNode.Builder.Create()
                .AddUsing(usingKeyword)
                .AddSeparators(separators)
                .AddNamespace(qualifiedId)
                .AddSemiColon(semiColon);

            return builder.Build();
        }

        private NamespaceNode? Namespace(TokenEnumerator tokenEnumerator)
        {
            var builder = NamespaceNode.Builder.Create();

            var keyword = tokenEnumerator.Keyword(Keywords.Namespace);
            if (keyword == null)
                return null;

            builder.AddNamespaceKeyword(keyword);

            var separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception(); // TODO:

            builder.AddSeparators(separators);

            var qualifiedId = QualifiedId(tokenEnumerator);
            if (qualifiedId == null)
                throw new Exception(); // TODO:

            builder.AddName(qualifiedId);

            separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception(); // TODO:

            builder.AddSeparators(separators);

            var openBrace = tokenEnumerator.Symbol(Symbols.OpenBrace);
            if (openBrace == null)
                throw new Exception(); // TODO:

            builder.AddSymbol(openBrace);

            // TODO: body
            while (true)
            {
                separators = Separators(tokenEnumerator);
                if (!separators.IsEmpty)
                    builder.AddSeparators(separators);

                var @namespace = Namespace(tokenEnumerator);
                if (@namespace != null)
                {
                    builder.AddNamespace(@namespace);
                    continue;
                }

                var classNode = Class(tokenEnumerator);
                if (classNode != null)
                {
                    builder.AddClass(classNode);
                    continue;
                }

                break;
            }

            var closeBrace = tokenEnumerator.Symbol(Symbols.CloseBrace);
            if (closeBrace == null)
                throw new Exception(); // TODO:

            builder.AddSymbol(closeBrace);

            return builder.Build();
        }

        private ClassNode? Class(TokenEnumerator tokenEnumerator)
        {
            // TODO: !!!
            var builder = ClassNode.Builder.Create();

            var publicKeyword = tokenEnumerator.Keyword(Keywords.Public);
            if (publicKeyword == null)
                return null;

            builder.AddAccessModifier(publicKeyword);

            var separators = Separators(tokenEnumerator);
            if (!separators.IsEmpty)
                builder.AddSeparators(separators);

            var classKeyword = tokenEnumerator.Keyword(Keywords.Class);
            if (classKeyword != null)
                builder.AddClassKeyword(classKeyword);

            separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception();

            builder.AddSeparators(separators);

            var name = Id(tokenEnumerator);
            if (name == null)
                throw new Exception();

            separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception();

            builder.AddSeparators(separators);

            // TODO: body
            var openBrace = tokenEnumerator.Symbol(Symbols.OpenBrace);
            if (openBrace == null)
                throw new Exception(); // TODO:

            // TODO: body
            while (true)
            {
                separators = Separators(tokenEnumerator);
                if (!separators.IsEmpty)
                {
                    builder.AddSeparators(separators);
                    continue;
                }

                var methodNode = Method(tokenEnumerator);
                if (methodNode != null)
                {
                    builder.AddMethod(methodNode);
                    continue;
                }

                break;
            }

            var closeBrace = tokenEnumerator.Symbol(Symbols.CloseBrace);
            if (closeBrace == null)
                throw new Exception(); // TODO:

            return builder.Build();
        }

        private MethodNode? Method(TokenEnumerator tokenEnumerator)
        {
            var builder = MethodNode.Builder.Create();

            // TODO:
            var publicKeyword = tokenEnumerator.Keyword(Keywords.Public);
            if (publicKeyword == null)
                return null;

            builder.AddAccessModifier(publicKeyword);

            var separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception();

            builder.AddSeparators(separators);

            var staticKeyword = tokenEnumerator.Keyword(Keywords.Static);
            if (staticKeyword != null)
                builder.AddStatic(staticKeyword);

            separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception();

            builder.AddSeparators(separators);

            var returnType = Id(tokenEnumerator) ??
                             (INode) tokenEnumerator.Keyword(Keywords.Void);
            if (returnType == null)
                throw new Exception(); // TODO:

            builder.AddReturnType(returnType);

            separators = Separators(tokenEnumerator);
            if (separators.IsEmpty)
                throw new Exception();

            builder.AddSeparators(separators);

            var name = Id(tokenEnumerator);
            if (name == null)
                throw new Exception();

            builder.AddName(name);

            separators = Separators(tokenEnumerator);
            if (!separators.IsEmpty)
                builder.AddSeparators(separators);

            var openParen = tokenEnumerator.Symbol(Symbols.OpenParenthesis);
            if (openParen == null)
                throw new Exception();

            // TODO: argument list

            var closeParen = tokenEnumerator.Symbol(Symbols.CloseParenthesis);
            if (closeParen == null)
                throw new Exception();

            separators = Separators(tokenEnumerator);
            if (!separators.IsEmpty)
                builder.AddSeparators(separators);

            // TODO: separate method
            var openBrace = tokenEnumerator.Symbol(Symbols.OpenBrace);
            if (openBrace == null)
                throw new Exception(); // TODO:

            while (true)
            {
                separators = Separators(tokenEnumerator);
                if (!separators.IsEmpty)
                {
                    builder.AddSeparators(separators);
                    continue;
                }

                var invocation = Invocation(tokenEnumerator);
                if (invocation != null)
                {
                    builder.AddBodyItem(invocation);
                    continue;
                }

                break;
            }

            var closeBrace = tokenEnumerator.Symbol(Symbols.CloseBrace);
            if (closeBrace == null)
                throw new Exception(); // TODO:

            return builder.Build();
        }

        private InvocationExpression? Invocation(TokenEnumerator tokenEnumerator)
        {
            var id = QualifiedId(tokenEnumerator);
            if (id == null)
                return null;

            var openParen = tokenEnumerator.Symbol(Symbols.OpenParenthesis);
            if (openParen == null)
                throw new Exception();

            // TODO:
            var stringLiteral = StringLiteral(tokenEnumerator);

            var closeParen = tokenEnumerator.Symbol(Symbols.CloseParenthesis);
            if (closeParen == null)
                throw new Exception();

            var semiColon = tokenEnumerator.Symbol(Symbols.SemiColon);
            if (semiColon == null)
                throw new Exception();

            var builder = InvocationExpression.Builder.Create()
                .AddId(id)
                .AddSymbol(openParen)
                .AddParameter(stringLiteral)
                .AddSymbol(closeParen)
                .AddSymbol(semiColon);

            return builder.Build();
        }

        private StringLiteralNode? StringLiteral(TokenEnumerator tokenEnumerator)
        {
            var literal = tokenEnumerator.Literal(LiteralType.String);
            if (literal == null)
                return null;

            // TODO: move to ctor
            return new StringLiteralNode(
                ImmutableArray.Create<INode>(literal),
                literal.SourceReference.SourceCode[1..^1]);
        }

        private QualifiedIdNode? QualifiedId(TokenEnumerator tokenEnumerator)
        {
            var id = Id(tokenEnumerator);
            if (id == null)
                return null;

            var builder = QualifiedIdNode.Builder.Create()
                .AddId(id);

            SymbolToken? dot;
            while ((dot = tokenEnumerator.Symbol(Symbols.Dot)) != null)
            {
                id = Id(tokenEnumerator);
                if (id == null)
                    throw new Exception(); // TODO:

                builder.AddDot(dot).AddId(id);
            }

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
            var builder = ImmutableArray.CreateBuilder<IToken>();

            IToken? separator;
            while ((separator = Separator(tokenEnumerator)) != null)
                builder.Add(separator);

            return builder.ToImmutableArray();
        }

        private IToken? Separator(TokenEnumerator tokenEnumerator)
            => tokenEnumerator.Symbol(Symbols.Whitespace) ??
               tokenEnumerator.Symbol(Symbols.NewLine);
    }
}