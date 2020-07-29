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
            private ImmutableArray<INode> children;

            private bool isStatic;
            private IdNode? alias;
            private QualifiedIdNode? @namespace;

            private Builder(ImmutableArray<INode> children)
            {
                this.children = children;
                this.isStatic = false;
                this.alias = null;
                this.@namespace = null;
            }

            public UsingNode Build()
                => new UsingNode(children, isStatic, alias, @namespace);

            public Builder AddUsing(KeywordToken keyword)
            {
                children = children.Add(keyword);

                return this;
            }

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                children = children.AddRange(separators);

                return this;
            }

            public Builder AddNamespace(QualifiedIdNode @namespace)
            {
                this.@namespace = @namespace;
                children = children.Add(@namespace);

                return this;
            }

            public Builder AddSemiColon(SymbolToken semiColon)
            {
                children = children.Add(semiColon);

                return this;
            }

            public static Builder Default = new Builder(ImmutableArray<INode>.Empty);
        }
    }
}