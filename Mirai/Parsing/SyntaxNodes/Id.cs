using System;

namespace Mirai.Parsing.SyntaxNodes
{
    public class Id : ISyntaxNode
    {
        public Id(ReadOnlyMemory<char> name)
        {
            if (name.IsEmpty)
                throw new ArgumentException();

            Name = name;
        }

        public ReadOnlyMemory<char> Name { get; }
    }
}