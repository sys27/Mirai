using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class UsingNode : SyntaxNode
    {
        private UsingNode(
            ImmutableArray<INode> children,
            bool isStatic,
            IdNode? alias,
            QualifiedIdNode @namespace)
            : base(children)
        {
            IsStatic = isStatic;
            Alias = alias;
            Namespace = @namespace;
        }

        public bool IsStatic { get; }

        public IdNode? Alias { get; }

        public QualifiedIdNode Namespace { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;

            private bool isStatic;
            private IdNode? alias;
            private QualifiedIdNode? @namespace;

            public UsingNode Build()
                => new UsingNode(children.ToImmutableArray(), isStatic, alias, @namespace);

            public Builder AddUsing(KeywordToken keyword)
            {
                children.Add(keyword);

                return this;
            }

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                children.AddRange(separators);

                return this;
            }

            public Builder AddNamespace(QualifiedIdNode @namespace)
            {
                this.@namespace = @namespace;
                children.Add(@namespace);

                return this;
            }

            public Builder AddSemiColon(SymbolToken semiColon)
            {
                children.Add(semiColon);

                return this;
            }

            public static Builder Create() =>
                new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                };
        }
    }
}