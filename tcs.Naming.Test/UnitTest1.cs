using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tcs.Naming.Test
{
    public class Tests
    {
        [Test]
        public void Test()
        {
            var example0 = "Hello World";
            var example1 = "GitHub Examples";
            var example2 = "Österreich ist ein schönes Land";
            var example3 = "WhatIsYourName?";
            var example4 = "EverythingOK?";

            var examples = new[] { example0, example1, example2, example3, example4 };

            foreach (var example in examples)
            {
                var str = example.ConvertNamingCase<SnakeCase>(new NamingOptions()
                {
                    AsciiOnly = true,
                    KeepPunctuations = false,
                    KeepSymbols = false,
                    IgnoreIfInvalidCharacters = true,
                    SeparateIfUpperCase = true,
                    KeepUpperCaseWord = true
                });

                Console.WriteLine(str);
            }

            // Output:

            // hello_world
            // git_hub_examples
            // sterreich_ist_ein_schnes_land
            // what_is_your_name
            // everything_ok
        }

        private readonly string[] names = [
                "HelloWorldItIsOK",
                "Hello World $3%.-FFF_ZZZ,:#äöü ♀!y█î©q ЖЉЙй \n\t Test Я тебя люблю",
                "Januar Februar März April Mai Juni",
                "MontagDIENSTAG_Mittwoch.Donnerstag/FREITAG",
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
                    IgnoreIfInvalidCharacters = true,
                    SeparateIfUpperCase = true
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
    }
}
