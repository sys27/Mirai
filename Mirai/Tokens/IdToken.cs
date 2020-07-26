using System;
using System.Diagnostics;

namespace Mirai.Tokens
{
    [DebuggerDisplay("Id: {" + nameof(Id) + "}")]
    public class IdToken : ITokenWithPosition
    {
        public IdToken(ReadOnlyMemory<char> id, SourcePosition sourcePosition)
        {
            Id = id;
            SourcePosition = sourcePosition;
        }

        public override string ToString() => Id.ToString();

        public ReadOnlyMemory<char> Id { get; }
        public SourcePosition SourcePosition { get; }
        public ReadOnlyMemory<char> SourceCode => Id;
    }
}