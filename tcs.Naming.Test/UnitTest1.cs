using System.Diagnostics;

namespace tcs.Naming.Test
{
    public class Tests
    {
        private readonly string[] names = [
                "Hello World $3%.-FFF_ZZZ,:#äöü ♀!y█î©q ЖЉЙй \n\t Test Я тебя люблю",
                "Januar Februar März April Mai Juni",
                "Hello World 12345 /FA/ <S> !!!",
                "Hello-World-123-Pass",
                "Hello0-World0-#*+",
                "Hello#World#+_:",
                "Meine Straße in Österreich!!",
                "A",
                "012_-#12"
            ];

        [SetUp]
        public void Setup()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [TearDown]
        public void EndTest()
        {
            Trace.Flush();
        }

        private void TestCase<TCase>() where TCase : class, INamingCase, new()
        {
            Console.WriteLine($"{typeof(TCase)}");
            Console.WriteLine("-------------------------------------------");

            foreach (var name in names)
            {
                var str = name.ConvertNamingCase<TCase>(new NamingOptions()
                {
                    AsciiOnly = true,
                    KeepPunctuations = false,
                    KeepSymbols = false,
                    IgnoreIfInvalidCharacters = true
                });

                Console.WriteLine("'{0}'", str);
            }
        }

        [Test]
        public void TestPascalCase()
        {
            TestCase<PascalCase>();
            Assert.Pass();
        }

        [Test]
        public void TestSnakeCase()
        {
            TestCase<SnakeCase>();
            Assert.Pass();
        }

        [Test]
        public void TestKebabCase()
        {
            TestCase<KebabCase>();
            Assert.Pass();
        }

        [Test]
        public void TestFlatCase()
        {
            TestCase<FlatCase>();
            Assert.Pass();
        }

        [Test]
        public void TestTrainCase()
        {
            TestCase<TrainCase>();
            Assert.Pass();
        }

        [Test]
        public void TestCamelCase()
        {
            TestCase<CamelCase>();
            Assert.Pass();
        }

        [Test]
        public void TestTitleCase()
        {
            TestCase<TitleCase>();
            Assert.Pass();
        }

        [Test]
        public void TestSentenceCase()
        {
            TestCase<SentenceCase>();
            Assert.Pass();
        }

        [Test]
        public void TestConstantCase()
        {
            TestCase<ConstantCase>();
            Assert.Pass();
        }

        [Test]
        public void TestDotCase()
        {
            TestCase<DotCase>();
            Assert.Pass();
        }

        [Test]
        public void TestPathCase()
        {
            TestCase<PathCase>();
            Assert.Pass();
        }

        private void DumpChar(char c)
        {
            Console.Write(c);
            Console.Write(" [");
            Console.Write("Ascii: {0}, ", char.IsAscii(c));
            Console.Write("Letter/Digit: {0}, ", char.IsLetterOrDigit(c));
            Console.Write("Separator: {0}, ", char.IsSeparator(c));
            Console.Write("Punctuation: {0}, ", char.IsPunctuation(c));
            Console.Write("White Space: {0}, ", char.IsWhiteSpace(c));
            Console.Write("Surrogate: {0}, ", char.IsSurrogate(c));
            Console.Write("Control: {0}, ", char.IsControl(c));
            Console.Write("Symbol: {0}", char.IsSymbol(c));
            Console.WriteLine(" ]");
        }
    }
}