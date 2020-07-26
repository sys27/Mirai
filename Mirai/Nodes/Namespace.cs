using System.Collections;
using System.Collections.Generic;

namespace Mirai.Nodes
{
    public class Namespace : IComposedNode
    {
        public IEnumerator<INode> GetEnumerator()
        {
            yield return Name;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public QualifiedId Name { get; set; }
    }
}