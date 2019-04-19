using NUnit.Framework;

namespace PadawansTask6.Tests
{
    [TestFixture]
    public class PublicTest
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        public int? NextBiggerThanTests(int number) => NumberFinder.NextBiggerThan(number);
    }
}
