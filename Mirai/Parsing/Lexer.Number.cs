using System;
using Mirai.Parsing.Tokens;

namespace Mirai.Parsing
{
    public partial class Lexer
    {
        private IToken? CreateNumber(ref SourceReference reference)
        {
            throw new NotImplementedException();
        }

        private bool IsTypeSuffix(char symbol)
            => symbol == 'u' ||
               symbol == 'U' ||
               symbol == 'l' ||
               symbol == 'L' ||
               symbol == 'f' ||
               symbol == 'F' ||
               symbol == 'd' ||
               symbol == 'D' ||
               symbol == 'm' ||
               symbol == 'M';

        private static bool IsHexNumber(char symbol)
            => IsInRange(symbol, '0', '9') ||
               IsInRange(symbol, 'a', 'f') ||
               IsInRange(symbol, 'A', 'F');
    }
}