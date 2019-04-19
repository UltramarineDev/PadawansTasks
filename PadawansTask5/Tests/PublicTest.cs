using NUnit.Framework;

namespace PadawansTask5.Tests
{
    [TestFixture]
    public class PublicTest
    { 
        [TestCase(arg: new[] { 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1 }, ExpectedResult = "Yes")]
        [TestCase(arg: new[] { 1, 1, 0, 0, 0, 0, 1, 1, 0 }, ExpectedResult = "No")]

        public string CheckIfSymmetricTests(int[] source) => ArrayHelper.CheckIfSymmetric(source);
    }
}
