using System.Collections.Immutable;
using System.Text;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class QualifiedIdNode : SyntaxNode
    {
        private QualifiedIdNode(ImmutableArray<INode> children, string @namespace)
            : base(children)
        {
            Namespace = @namespace;
        }

        public string Namespace { get; } // TODO:

        public struct Builder
        {
            private ImmutableArray<INode> children;

            private StringBuilder sb;

            public Builder(ImmutableArray<INode> children)
            {
                this.children = children;
                this.sb = new StringBuilder();
            }

            public QualifiedIdNode Build()
            {
                return new QualifiedIdNode(children, sb.ToString());
            }

            public Builder AddId(IdNode id)
            {
                sb.Append(id.Name);
                children = children.Add(id);

                return this;
            }

            public Builder AddDot(SymbolToken dot)
            {
                sb.Append('.'); // TODO:
                children = children.Add(dot);

                return this;
            }

            public static Builder Default = new Builder(ImmutableArray<INode>.Empty);
        }
    }
}