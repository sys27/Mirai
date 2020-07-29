using System;
using System.Collections;
using System.Collections.Generic;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing.SyntaxNodes
{
    public class IdNode : ISyntaxNode // TODO:
    {
        public IdNode(IdToken idToken)
        {
            IdToken = idToken;
        }

        public IEnumerator<INode> GetEnumerator()
        {
            yield return IdToken;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IdToken IdToken { get; }
        public ReadOnlyMemory<char> Name => IdToken.Id;
    }
}