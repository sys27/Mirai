using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Nodes
{
    public class QualifiedId : IComposedNode
    {
        public QualifiedId(ImmutableArray<Id> parts)
        {
            if (parts == null)
                throw new ArgumentNullException(nameof(parts));
            if (parts.IsEmpty)
                throw new ArgumentException();

            Parts = parts;
        }

        public IEnumerator<INode> GetEnumerator()
        {
            foreach (var id in Parts)
                yield return id;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ImmutableArray<Id> Parts { get; }
    }
}