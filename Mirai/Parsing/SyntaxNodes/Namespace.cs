using System.Collections;
using System.Collections.Generic;

namespace Mirai.Parsing.SyntaxNodes
{
    public class Namespace : IComposedSyntaxNode
    {
        public IEnumerator<ISyntaxNode> GetEnumerator()
        {
            yield return Name;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public QualifiedId Name { get; set; }
    }
}