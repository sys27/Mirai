using System;
using System.Collections.Immutable;

namespace Mirai.Parsing.SyntaxNodes
{
    public class StringLiteralNode : SyntaxNode
    {
        public StringLiteralNode(
            ImmutableArray<INode> children,
            ReadOnlyMemory<char> value)
            : base(children)
        {
            Value = value;
        }

        public ReadOnlyMemory<char> Value { get; }
    }
}