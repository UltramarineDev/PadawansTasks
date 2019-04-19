using System;

namespace PadawansTask4
{
    public class StringHelper
    {
        public static int GetVowelCount(string str)
        {
            // put your code here
            //throw new NotImplementedException();
            if (str == null)
            {
                throw new ArgumentNullException(); 
            }
            if (str == "")
            {
                throw new ArgumentException();
            }
            char[] array;
            array = str.ToCharArray();
            int count = 0;
            for (int i=0; i< array.Length; i++)
            {
                if (array[i] == 'a' || array[i] == 'e' || array[i] == 'i' || array[i] == 'o' || array[i] == 'u')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
