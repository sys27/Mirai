using System.Collections.Generic;

namespace Mirai.Parsing.SyntaxNodes
{
    public interface ISyntaxNode : INode, IEnumerable<INode>
    {
    }
}