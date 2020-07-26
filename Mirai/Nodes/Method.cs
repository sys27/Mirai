using System.Collections;
using System.Collections.Generic;

namespace Mirai.Nodes
{
    public class Method : IComposedNode
    {
        public IEnumerator<INode> GetEnumerator()
        {
            yield return Name;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public AccessModifier AccessModifier { get; }

        public bool IsAbstract { get; }

        public bool IsVirtual { get; }

        public bool IsOverride { get; }

        public bool IsSealed { get; }

        public bool IsStatic { get; }

        public Id Name { get; }
    }
}