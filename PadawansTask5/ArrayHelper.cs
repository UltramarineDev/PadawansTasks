using System;

namespace PadawansTask5
{
    public static class ArrayHelper
    {
        public static string CheckIfSymmetric(int[] source)
        {
            // put your code here
            //throw new NotImplementedException();

            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (source.Length == 0)
            {
                throw new ArgumentException();
            }
            foreach (int s in source)
            {
                if (s != 0 && s != 1)
                {
                    throw new ArgumentException();
                }
            }

            bool flag = true;
            for (int i = 0; i < source.Length / 2; i++)
            {
                if (source[i] != source[source.Length - i - 1])
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                return "Yes";
            }
            else
                return "No";
        }
    }
}
