using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class ClassNode : SyntaxNode
    {
        private ClassNode(
            ImmutableArray<INode> children,
            AccessModifier accessModifier)
            : base(children)
        {
            AccessModifier = accessModifier;
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

            public ClassNode Build()
                => new ClassNode(
                    children.ToImmutableArray(),
                    accessModifier);

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

            public static Builder Create()
                => new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    accessModifier = AccessModifier.Internal,
                };
        }
    }
}