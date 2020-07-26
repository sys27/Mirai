using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Nodes
{
    public class CompilationUnit : IComposedNode
    {
        public IEnumerator<INode> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ImmutableArray<Using> Usings { get; }
    }
}