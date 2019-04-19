using NUnit.Framework;

namespace PadawansTask12.Tests
{
    [TestFixture]
    public class PublicTest
    {
        [TestCase("abcde   fghijklmnopqrstuvwxyz abcdefghijklm  nopqrstuvwxyz abcdefghijklmnopqrstuvwxyz", false)]
        [TestCase("abcdefghijklmnopqrstuvwxyz", true)]
        public void AllCharactersAreUniqueTests(string source, bool result)
        {
            Assert.That(StringExtension.AllCharactersAreUnique(source) == result);
        }
    }
}