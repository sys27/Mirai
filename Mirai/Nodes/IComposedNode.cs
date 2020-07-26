using System.Collections.Generic;

namespace Mirai.Nodes
{
    public interface IComposedNode : INode, IEnumerable<INode>
    {
    }
}