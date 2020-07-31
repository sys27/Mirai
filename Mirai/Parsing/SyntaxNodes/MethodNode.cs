using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class MethodNode : SyntaxNode
    {
        private MethodNode(
            ImmutableArray<INode> children,
            AccessModifier accessModifier,
            bool isStatic,
            INode returnType,
            IdNode name,
            ImmutableArray<ISyntaxNode> body)
            : base(children)
        {
            AccessModifier = accessModifier;
            IsStatic = isStatic;
            ReturnType = returnType;
            Name = name;
            Body = body;
        }

        public AccessModifier AccessModifier { get; }

        public bool IsAbstract { get; }

        public bool IsVirtual { get; }

        public bool IsOverride { get; }

        public bool IsSealed { get; }

        public bool IsStatic { get; }

        public INode ReturnType { get; }

        public IdNode Name { get; }
        public ImmutableArray<ISyntaxNode> Body { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;

            private AccessModifier accessModifier;
            private bool isStatic;
            private INode? returnType;
            private IdNode? name;
            private ImmutableArray<ISyntaxNode>.Builder body;

            public MethodNode Build()
                => new MethodNode(
                    children.ToImmutableArray(),
                    accessModifier,
                    isStatic,
                    returnType,
                    name,
                    body.ToImmutableArray());

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

            public Builder AddStatic(KeywordToken keywordToken)
            {
                // TODO: debug assert?
                children.Add(keywordToken);
                isStatic = true;

                return this;
            }

            public Builder AddReturnType(INode idNode)
            {
                children.Add(idNode);
                returnType = idNode;

                return this;
            }

            public Builder AddName(IdNode id)
            {
                children.Add(id);
                name = id;

                return this;
            }

            public Builder AddBodyItem(ISyntaxNode syntaxNode)
            {
                children.Add(syntaxNode);
                body.Add(syntaxNode);

                return this;
            }

            public static Builder Create()
                => new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    accessModifier = AccessModifier.Private, // TODO:
                    isStatic = false,
                    returnType = null,
                    name = null,
                    body = ImmutableArray.CreateBuilder<ISyntaxNode>(),
                };
        }
    }
}