using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public abstract class SyntaxNode : ISyntaxNode
    {
        private ImmutableArray<INode> children;

        protected SyntaxNode(ImmutableArray<INode> children)
        {
            this.children = children;
        }

        public IEnumerator<INode> GetEnumerator()
        {
            foreach (var child in children)
                yield return child;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}