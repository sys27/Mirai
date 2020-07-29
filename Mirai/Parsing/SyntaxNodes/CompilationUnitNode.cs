using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class CompilationUnitNode : SyntaxNode
    {
        public CompilationUnitNode(ImmutableArray<INode> children) : base(children)
        {
        }

        public ImmutableArray<UsingNode> Usings { get; }
    }
}