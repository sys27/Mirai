using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class NamespaceNode : SyntaxNode
    {
        private NamespaceNode(ImmutableArray<INode> children, QualifiedIdNode @namespace)
            : base(children)
        {
            this.Namespace = @namespace;
        }

        public QualifiedIdNode Namespace { get; }

        public struct Builder
        {
            private ImmutableArray<INode> children;

            private KeywordToken keyword;
            private ImmutableArray<IToken> separators;
            private QualifiedIdNode @namespace;

            public NamespaceNode Build()
                => new NamespaceNode(children, @namespace);

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
        }
    }
}