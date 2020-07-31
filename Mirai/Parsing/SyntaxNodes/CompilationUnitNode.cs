using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class CompilationUnitNode : SyntaxNode
    {
        private CompilationUnitNode(
            ImmutableArray<INode> children,
            ImmutableArray<UsingNode> usings,
            ImmutableArray<NamespaceNode> namespaces,
            ImmutableArray<ClassNode> classes)
            : base(children)
        {
            Usings = usings;
            Namespaces = namespaces;
            Classes = classes;
        }

        public ImmutableArray<UsingNode> Usings { get; }
        public ImmutableArray<NamespaceNode> Namespaces { get; }
        public ImmutableArray<ClassNode> Classes { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;
            private ImmutableArray<UsingNode>.Builder usings;
            private ImmutableArray<NamespaceNode>.Builder namespaces;
            private ImmutableArray<ClassNode>.Builder classes;

            public CompilationUnitNode Build()
                => new CompilationUnitNode(
                    children.ToImmutableArray(),
                    usings.ToImmutableArray(),
                    namespaces.ToImmutableArray(),
                    classes.ToImmutableArray());

            public Builder AddUsing(UsingNode usingNode)
            {
                children.Add(usingNode);
                usings.Add(usingNode);

                return this;
            }

            public Builder AddNamespace(NamespaceNode namespaceNode)
            {
                children.Add(namespaceNode);
                namespaces.Add(namespaceNode);

                return this;
            }

            public Builder AddClass(ClassNode classNode)
            {
                children.Add(classNode);
                classes.Add(classNode);

                return this;
            }

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                children.AddRange(separators);

                return this;
            }

            public static Builder Create() =>
                new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    usings = ImmutableArray.CreateBuilder<UsingNode>(),
                    namespaces = ImmutableArray.CreateBuilder<NamespaceNode>(),
                    classes = ImmutableArray.CreateBuilder<ClassNode>(),
                };
        }
    }
}