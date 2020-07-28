using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class CompilationUnit : IComposedSyntaxNode
    {
        public IEnumerator<ISyntaxNode> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ImmutableArray<Using> Usings { get; }
    }
}