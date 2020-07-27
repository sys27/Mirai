using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Parsing.Nodes
{
    public class Class : IComposedNode
    {
        public IEnumerator<INode> GetEnumerator()
        {
            yield return Name;

            foreach (var method in Methods)
                yield return method;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public AccessModifier AccessModifier { get; }

        public bool IsSealed { get; }

        public bool IsPartial { get; }

        public bool IsAbstract { get; }

        public Id Name { get; }

        public ImmutableArray<Method> Methods { get; }
    }
}