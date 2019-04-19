using NUnit.Framework;

namespace PadawansTask8.Tests
{
    [TestFixture]
    public class PublicTest
    {
        [Test]
        public void RemoveDuplicateWordsTest()
        {
            string actual = "alpha beta beta gamma gamma gamma delta alpha beta beta gamma gamma gamma delta";

            string expected = "alpha beta  gamma   delta       ";

            WordsManipulation.RemoveDuplicateWords(ref actual);

            Assert.AreEqual(expected, actual);
        }
    }
}