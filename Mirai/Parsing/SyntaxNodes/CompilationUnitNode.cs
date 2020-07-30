using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class CompilationUnitNode : SyntaxNode
    {
        private CompilationUnitNode(
            ImmutableArray<INode> children,
            ImmutableArray<UsingNode> usings)
            : base(children)
        {
            Usings = usings;
        }

        public ImmutableArray<UsingNode> Usings { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;
            private ImmutableArray<UsingNode>.Builder usings;

            public CompilationUnitNode Build()
                => new CompilationUnitNode(children.ToImmutableArray(), usings.ToImmutableArray());

            public Builder AddUsing(UsingNode usingNode)
            {
                children.Add(usingNode);
                usings.Add(usingNode);

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
                };
        }
    }
}