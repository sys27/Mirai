using System;

namespace Mirai.Nodes
{
    public class Id : INode
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