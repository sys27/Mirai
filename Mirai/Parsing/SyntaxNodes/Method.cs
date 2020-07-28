using System.Collections;
using System.Collections.Generic;

namespace Mirai.Parsing.SyntaxNodes
{
    public class Method : IComposedSyntaxNode
    {
        public IEnumerator<ISyntaxNode> GetEnumerator()
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