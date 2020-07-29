using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class UsingNode : SyntaxNode
    {
        public UsingNode(ImmutableArray<INode> children)
            : base(children)
        {
        }

        public bool IsStatic { get; }

        public IdNode? Alias { get; }

        public QualifiedIdNode Namespace { get; }
    }
}