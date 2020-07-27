using System.Collections.Generic;

namespace Mirai.Parsing.Nodes
{
    public interface IComposedNode : INode, IEnumerable<INode>
    {
    }
}