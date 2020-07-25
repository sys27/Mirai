using System.Linq;
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

namespace xxx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }
    }
}";

            var lexer = new Lexer();
            var tokens = lexer.Tokenize(sourceCode).ToList();

            tokens.ShouldNotBeEmpty();
        }
    }
}