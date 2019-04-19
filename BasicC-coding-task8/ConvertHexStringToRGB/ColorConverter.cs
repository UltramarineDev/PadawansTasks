using System;

namespace ConvertHexStringToRGB
{
    public class ColorConverter
    {
        public static RGBColor HexStringToRGB(string hexColor)
        {
            int r = Convert.ToInt32(hexColor.Substring(1, 2), 16);
            int g = Convert.ToInt32(hexColor.Substring(3, 2), 16);
            int b = Convert.ToInt32(hexColor.Substring(5, 2), 16);
            RGBColor rGB = new RGBColor();
            rGB.R = r;
            rGB.G = g;
            rGB.B = b;
            return rGB;
        }
    }
}
