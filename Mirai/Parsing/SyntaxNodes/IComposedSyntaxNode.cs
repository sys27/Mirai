using System.Collections.Generic;

namespace Mirai.Parsing.SyntaxNodes
{
    public interface IComposedSyntaxNode : ISyntaxNode, IEnumerable<ISyntaxNode>
    {
    }
}