using System.Collections.Immutable;
using System.Text;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class QualifiedIdNode : SyntaxNode
    {
        private QualifiedIdNode(ImmutableArray<INode> children, string id)
            : base(children)
        {
            Id = id;
        }

        public string Id { get; } // TODO:

        public struct Builder
        {
            private ImmutableArray<INode>.Builder children;

            private StringBuilder sb;

            public QualifiedIdNode Build()
            {
                return new QualifiedIdNode(children.ToImmutableArray(), sb.ToString());
            }

            public Builder AddId(IdNode id)
            {
                sb.Append(id.Name);
                children.Add(id);

                return this;
            }

            public Builder AddDot(SymbolToken dot)
            {
                sb.Append('.'); // TODO:
                children.Add(dot);

                return this;
            }

            public static Builder Create()
                => new Builder
                {
                    children = ImmutableArray.CreateBuilder<INode>(),
                    sb = new StringBuilder(),
                };
        }
    }
}