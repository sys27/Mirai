using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class ClassNode : SyntaxNode
    {
        public ClassNode(ImmutableArray<INode> children) : base(children)
        {
        }

        public AccessModifier AccessModifier { get; }

        public bool IsSealed { get; }

        public bool IsPartial { get; }

        public bool IsAbstract { get; }

        public IdNode Name { get; }

        public ImmutableArray<MethodNode> Methods { get; }
    }
}