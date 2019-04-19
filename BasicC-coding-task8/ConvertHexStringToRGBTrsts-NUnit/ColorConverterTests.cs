using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertHexStringToRGB;
using NUnit.Framework;

namespace ConvertHexStringToRGBTests_NUnit
{
    public class Class1
    {
        [TestCase("#FF9933", ExpectedResult = new int[] { 255, 153, 51 })]
        [TestCase("#FFFFFF", ExpectedResult = new int[] { 255, 255, 255 })]
        public int[] ColorConverTests(string str)
        {
            var temp = ColorConverter.HexStringToRGB(str);
            return new int[] { temp.R, temp.G, temp.B};
        } 
    }
}

