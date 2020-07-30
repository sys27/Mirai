using Mirai.Parsing;
using Shouldly;
using Xunit;

namespace Mirai.Tests
{
    public class ParserTest
    {
        [Fact]
        public void TestTree()
        {
            var lexer = new Lexer();
            var parser = new Parser();

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
}";
            var tokens = lexer.Tokenize(sourceCode);
            var tree = parser.Parse(tokens);

            tree.ShouldNotBeNull();
        }
    }
}