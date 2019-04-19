using System.Collections.Generic;
using NUnit.Framework;

namespace PadawansTask7.Tests
{
    [TestFixture]
    public class PublicTest
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new string[] { "Beg", "Life", "I", "To" }, arg2: new string[] { "I", "To", "Beg", "Life" }); 
                yield return new TestCaseData(arg1: new string[] { "", "Moderately", "Brains", "Pizza" }, arg2: new string[] { "", "Pizza", "Brains", "Moderately" });
                yield return new TestCaseData(arg1: new string[] { "Longer", "Longest", "Short" }, arg2: new string[] { "Short", "Longer", "Longest" });
            }
        }

        [TestCaseSource(nameof(DataCases))]
        public void OrderStringsByLengthTests(string[] actual, string[] expected)
        {           
            StringExtension.OrderStringsByLength(actual);

            Assert.AreEqual(expected, actual);
        }

    }
}
