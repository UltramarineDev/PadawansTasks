using System;

namespace PadawansTask7
{
    public class StringExtension
    {
        public static void OrderStringsByLength(string[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var s in array)
            {
                if (s == null)
                {
                    throw new ArgumentNullException();
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {

                    if (array[j].Length > array[j + 1].Length)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            // put your code here
            //throw new NotImplementedException();
        }
    }
}
