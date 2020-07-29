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
            private ImmutableArray<INode> children;

            private KeywordToken? keyword;
            private ImmutableArray<IToken> separators;
            private QualifiedIdNode? @namespace;
            private ImmutableArray<ISyntaxNode> body;

            private Builder(ImmutableArray<INode> children)
            {
                this.children = children;
                this.keyword = null;
                this.@namespace = null;
                this.body = ImmutableArray<ISyntaxNode>.Empty;
            }

            public NamespaceNode Build()
                => new NamespaceNode(children, @namespace, body);

            public Builder AddNamespaceKeyword(KeywordToken keyword)
            {
                this.keyword = keyword;
                children = children.Add(keyword);

                return this;
            }

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                this.separators = separators;
                children = children.AddRange(separators);

                return this;
            }

            public Builder AddNamespace(QualifiedIdNode @namespace)
            {
                this.@namespace = @namespace;
                children = children.Add(@namespace);

                return this;
            }

            public Builder AddBodyItem(ISyntaxNode item)
            {
                body.Add(item);
                children = children.Add(item);

                return this;
            }

            public static Builder Default = new Builder(ImmutableArray<INode>.Empty);
        }
    }
}