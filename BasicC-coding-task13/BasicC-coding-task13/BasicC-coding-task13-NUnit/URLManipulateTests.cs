using BasicC_coding_task13;
using NUnit.Framework;

namespace BasicC_coding_task13_NUnit
{
    public class URLManipulateTests
    {
        [TestCase("http://example.com/", "ID=1234", ExpectedResult = "http://example.com/?ID=1234")]
        [TestCase("http://example.com?ID=666", "ID=1234", ExpectedResult = "http://example.com?ID=1234")]
        [TestCase("www.example.com?key1=Value1", "key2=value2", ExpectedResult = "www.example.com?key1=Value1&key2=value2")]
        public string URLManipulationsTests(string url, string param)
        {
            var manipulator = new URLManipulate();
            var result = manipulator.AddOrChangeUrlParameter(url, param);
            return result;
        }
    }
}
