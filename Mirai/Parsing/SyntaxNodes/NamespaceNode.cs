using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class NamespaceNode : SyntaxNode
    {
        private NamespaceNode(
            ImmutableArray<INode> children,
            QualifiedIdNode name,
            ImmutableArray<NamespaceNode> namespaces,
            ImmutableArray<ClassNode> classes)
            : base(children)
        {
            Name = name;
            Namespaces = namespaces;
            Classes = classes;
        }

        public QualifiedIdNode Name { get; }
        public ImmutableArray<NamespaceNode> Namespaces { get; }
        public ImmutableArray<ClassNode> Classes { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;

            private KeywordToken? keyword;
            private QualifiedIdNode? name;
            private ImmutableArray<NamespaceNode>.Builder namespaces;
            private ImmutableArray<ClassNode>.Builder classes;

            public NamespaceNode Build()
                => new NamespaceNode(
                    children.ToImmutableArray(),
                    name,
                    namespaces.ToImmutableArray(),
                    classes.ToImmutableArray());

            public Builder AddNamespaceKeyword(KeywordToken keyword)
            {
                this.keyword = keyword;
                children.Add(keyword);

                return this;
            }

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                children.AddRange(separators);

                return this;
            }

            public Builder AddName(QualifiedIdNode name)
            {
                this.name = name;
                children.Add(name);

                return this;
            }

            public Builder AddNamespace(NamespaceNode namespaceNode)
            {
                namespaces.Add(namespaceNode);
                children.Add(namespaceNode);

                return this;
            }

            public Builder AddClass(ClassNode classNode)
            {
                classes.Add(classNode);
                children.Add(classNode);

                return this;
            }

            public Builder AddSymbol(SymbolToken symbolToken)
            {
                children.Add(symbolToken);

                return this;
            }

            public static Builder Create()
                => new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    namespaces = ImmutableArray.CreateBuilder<NamespaceNode>(),
                    classes = ImmutableArray.CreateBuilder<ClassNode>(),
                };
        }
    }
}