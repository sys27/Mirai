using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class ClassNode : SyntaxNode
    {
        private ClassNode(
            ImmutableArray<INode> children,
            AccessModifier accessModifier,
            IdNode name,
            ImmutableArray<MethodNode> methods)
            : base(children)
        {
            AccessModifier = accessModifier;
            Name = name;
            Methods = methods;
        }

        public AccessModifier AccessModifier { get; }

        public bool IsSealed { get; }

        public bool IsPartial { get; }

        public bool IsAbstract { get; }

        public IdNode Name { get; }

        public ImmutableArray<MethodNode> Methods { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;

            private AccessModifier accessModifier;
            private IdNode? name;
            private ImmutableArray<MethodNode>.Builder methods;

            public ClassNode Build()
                => new ClassNode(
                    children.ToImmutableArray(),
                    accessModifier,
                    name,
                    methods.ToImmutableArray());

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                children.AddRange(separators);

                return this;
            }

            public Builder AddAccessModifier(KeywordToken keywordToken)
            {
                children.Add(keywordToken);
                accessModifier = AccessModifier.Public; // TODO:

                return this;
            }

            public Builder AddClassKeyword(KeywordToken keywordToken)
            {
                children.Add(keywordToken);

                return this;
            }

            public Builder AddName(IdNode name)
            {
                children.Add(name);
                this.name = name;

                return this;
            }

            public Builder AddMethod(MethodNode methodNode)
            {
                children.Add(methodNode);
                methods.Add(methodNode);

                return this;
            }

            public static Builder Create()
                => new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    accessModifier = AccessModifier.Internal,
                    methods = ImmutableArray.CreateBuilder<MethodNode>(),
                };
        }
    }
}