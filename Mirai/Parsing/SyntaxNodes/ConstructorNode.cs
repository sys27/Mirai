using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class ConstructorNode : SyntaxNode
    {
        public ConstructorNode(ImmutableArray<INode> children)
            : base(children)
        {
        }
    }
}