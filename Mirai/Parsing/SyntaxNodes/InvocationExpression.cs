using System.Collections.Immutable;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class InvocationExpression : SyntaxNode
    {
        public InvocationExpression(
            ImmutableArray<INode> children,
            QualifiedIdNode id,
            ImmutableArray<ISyntaxNode> parameters)
            : base(children)
        {
            Id = id;
            Parameters = parameters;
        }

        public QualifiedIdNode Id { get; }
        public ImmutableArray<ISyntaxNode> Parameters { get; }

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;
            private QualifiedIdNode? id;
            private ImmutableArray<ISyntaxNode>.Builder parameters;

            public InvocationExpression Build()
                => new InvocationExpression(
                    children.ToImmutableArray(),
                    id,
                    parameters.ToImmutableArray());

            public Builder AddSeparators(ImmutableArray<IToken> separators)
            {
                children.AddRange(separators);

                return this;
            }

            public Builder AddId(QualifiedIdNode id)
            {
                children.Add(id);
                this.id = id;

                return this;
            }

            public Builder AddParameter(ISyntaxNode syntaxNode)
            {
                children.Add(syntaxNode);
                parameters.Add(syntaxNode);

                return this;
            }

            public Builder AddSymbol(SymbolToken symbolToken)
            {
                children.Add(symbolToken);

                return this;
            }

            public static Builder Create() =>
                new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    id = null,
                    parameters = ImmutableArray.CreateBuilder<ISyntaxNode>(),
                };
        }
    }
}