using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class NamespaceNode : SyntaxNode
    {
        private NamespaceNode(
            ImmutableArray<INode> children,
            QualifiedIdNode @namespace,
            ImmutableArray<ISyntaxNode> body)
            : base(children)
        {
            this.Namespace = @namespace;
        }

        public QualifiedIdNode Namespace { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;

            private KeywordToken? keyword;
            private ImmutableArray<IToken> separators;
            private QualifiedIdNode? @namespace;
            private ImmutableArray<ISyntaxNode>.Builder body;

            public NamespaceNode Build()
                => new NamespaceNode(children.ToImmutableArray(), @namespace, body.ToImmutableArray());

            public Builder AddNamespaceKeyword(KeywordToken keyword)
            {
                this.keyword = keyword;
                children.Add(keyword);

                return this;
            }

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                this.separators = separators;
                children.AddRange(separators);

                return this;
            }

            public Builder AddNamespace(QualifiedIdNode @namespace)
            {
                this.@namespace = @namespace;
                children.Add(@namespace);

                return this;
            }

            public Builder AddBodyItem(ISyntaxNode item)
            {
                body.Add(item);
                children.Add(item);

                return this;
            }

            public static Builder Create()
                => new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    body = ImmutableArray.CreateBuilder<ISyntaxNode>(),
                };
        }
    }
}