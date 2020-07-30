using System;
using System.Linq;
using Mirai.Parsing;
using Mirai.Parsing.Tokens;
using Shouldly;
using Xunit;

namespace Mirai.Tests
{
    public class LexerTests
    {
        [Fact]
        public void Test()
        {
            var sourceCode =
                @"using System;

namespace Test
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(""Hello, World!!!"");
        }
    }
}".AsMemory();

            var expected = new IToken[]
            {
                Keywords.Using.AsToken(new SourcePosition(1, 1), sourceCode[..5]),
                Symbols.Whitespace.AsToken(new SourcePosition(1, 6), sourceCode[5..6]),
                new IdToken(new SourcePosition(1, 7), sourceCode[6..12]),
            };

            var lexer = new Lexer();
            var tokens = lexer.Tokenize(sourceCode).ToList();

            tokens.ShouldNotBeEmpty();
            tokens.ShouldBe(expected);
        }
    }
}