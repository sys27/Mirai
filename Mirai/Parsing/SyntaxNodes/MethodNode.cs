using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class MethodNode : SyntaxNode
    {
        public MethodNode(ImmutableArray<INode> children) : base(children)
        {
        }

        public AccessModifier AccessModifier { get; }

        public bool IsAbstract { get; }

        public bool IsVirtual { get; }

        public bool IsOverride { get; }

        public bool IsSealed { get; }

        public bool IsStatic { get; }

        public IdNode Name { get; }
    }
}