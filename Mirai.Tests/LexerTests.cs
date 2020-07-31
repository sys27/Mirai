using System;
using System.Linq;
using Mirai.Parsing;
using Mirai.Parsing.Tokens;
using Shouldly;
using Xunit;
using static Mirai.Parsing.Tokens.Keywords;
using static Mirai.Parsing.Tokens.Symbols;

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

            SourceReference SR(ReadOnlyMemory<char> sourceCode, int line, int column)
                => new SourceReference(sourceCode, line, column);

            var expected = new IToken[]
            {
                Using.AsToken(SR(sourceCode[..5], 1, 1)),
                Whitespace.AsToken(SR(sourceCode[5..6], 1, 6)),
                new IdToken(SR(sourceCode[6..12], 1, 7)),
                SemiColon.AsToken(SR(sourceCode[12..13], 1, 13)),
                NewLine.AsToken(SR(sourceCode[13..14], 1, 14)),
                NewLine.AsToken(SR(sourceCode[14..15], 2, 1)),
                Namespace.AsToken(SR(sourceCode[15..24], 3, 1)),
                Whitespace.AsToken(SR(sourceCode[24..25], 3, 10)),
                new IdToken(SR(sourceCode[25..29], 3, 11)),
                NewLine.AsToken(SR(sourceCode[29..30], 3, 15)),
                OpenBrace.AsToken(SR(sourceCode[30..31], 4, 1)),
                NewLine.AsToken(SR(sourceCode[31..32], 4, 2)),
                Whitespace.AsToken(SR(sourceCode[32..36], 5, 1)),
                Public.AsToken(SR(sourceCode[36..42], 5, 5)),
                Whitespace.AsToken(SR(sourceCode[42..43], 5, 11)),
                Class.AsToken(SR(sourceCode[43..48], 5, 12)),
                Whitespace.AsToken(SR(sourceCode[48..49], 5, 17)),
                new IdToken(SR(sourceCode[49..56], 5, 18)),
                NewLine.AsToken(SR(sourceCode[56..57], 5, 25)),
                Whitespace.AsToken(SR(sourceCode[57..61], 6, 1)),
                OpenBrace.AsToken(SR(sourceCode[61..62], 6, 5)),
                NewLine.AsToken(SR(sourceCode[62..63], 6, 6)),
                Whitespace.AsToken(SR(sourceCode[63..71], 7, 1)),
                Public.AsToken(SR(sourceCode[71..77], 7, 9)),
                Whitespace.AsToken(SR(sourceCode[77..78], 7, 15)),
                Static.AsToken(SR(sourceCode[78..84], 7, 16)),
                Whitespace.AsToken(SR(sourceCode[84..85], 7, 22)),
                Keywords.Void.AsToken(SR(sourceCode[85..89], 7, 23)),
                Whitespace.AsToken(SR(sourceCode[89..90], 7, 27)),
                new IdToken(SR(sourceCode[90..94], 7, 28)),
                OpenParenthesis.AsToken(SR(sourceCode[94..95], 7, 32)),
                CloseParenthesis.AsToken(SR(sourceCode[95..96], 7, 33)),
                NewLine.AsToken(SR(sourceCode[96..97], 7, 34)),
                Whitespace.AsToken(SR(sourceCode[97..105], 8, 1)),
                OpenBrace.AsToken(SR(sourceCode[105..106], 8, 9)),
                NewLine.AsToken(SR(sourceCode[106..107], 8, 10)),
                Whitespace.AsToken(SR(sourceCode[107..119], 9, 1)),
                new IdToken(SR(sourceCode[119..126], 9, 13)),
                Dot.AsToken(SR(sourceCode[126..127], 9, 20)),
                new IdToken(SR(sourceCode[127..136], 9, 21)),
                OpenParenthesis.AsToken(SR(sourceCode[136..137], 9, 30)),
                LiteralType.String.AsToken(SR(sourceCode[137..154], 9, 31)),
                CloseParenthesis.AsToken(SR(sourceCode[154..155], 9, 48)),
                SemiColon.AsToken(SR(sourceCode[155..156], 9, 49)),
                NewLine.AsToken(SR(sourceCode[156..157], 9, 50)),
                Whitespace.AsToken(SR(sourceCode[157..165], 10, 1)),
                CloseBrace.AsToken(SR(sourceCode[165..166], 10, 9)),
                NewLine.AsToken(SR(sourceCode[166..167], 10, 10)),
                Whitespace.AsToken(SR(sourceCode[167..171], 11, 1)),
                CloseBrace.AsToken(SR(sourceCode[171..172], 11, 5)),
                NewLine.AsToken(SR(sourceCode[172..173], 11, 6)),
                CloseBrace.AsToken(SR(sourceCode[173..174], 12, 1)),
            };

            var lexer = new Lexer();
            var tokens = lexer.Tokenize(sourceCode).ToList();

            tokens.ShouldNotBeEmpty();
            tokens.ShouldBe(expected);
        }
    }
}