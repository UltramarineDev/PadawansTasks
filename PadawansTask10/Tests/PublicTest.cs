using NUnit.Framework;

namespace PadawansTask10.Tests
{
    [TestFixture]
    public class PublicTest
    {
        [TestCase("Kathy", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = true)]
        public bool IsNullTests(object variable) => variable.IsNull();
    }
}