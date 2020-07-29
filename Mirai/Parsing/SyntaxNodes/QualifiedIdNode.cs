using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class QualifiedIdNode : SyntaxNode
    {
        public QualifiedIdNode(ImmutableArray<INode> children)
            : base(children)
        {
        }
    }
}