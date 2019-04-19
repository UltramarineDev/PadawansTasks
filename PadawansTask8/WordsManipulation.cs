using System.Text;
using System;
using System.Collections.Generic;

namespace PadawansTask8
{
    public static class WordsManipulation
    {
        public static void RemoveDuplicateWords(ref string text)
        {
            // put your code here
            // throw new NotImplementedException();
            if (text == null)
            {
                throw new ArgumentNullException();
            }

            if (text == "")
            {
                throw new ArgumentException();
            }
            char[] arr;
            arr = text.ToCharArray();

            List<string> list = new List<string>();

            int i = 0;
            while (i != arr.Length)
            {
                string stringTemp = "";

                while (arr[i] != ' ' && arr[i] != '.' && arr[i] != ',' && arr[i] != '!' && arr[i] != '?' && arr[i] != '-' && arr[i] != ':' && arr[i] != ';')
                {

                    stringTemp += arr[i];
                    i++;
                    if (i == arr.Length)
                    {
                        break;
                    }
                }

                list.Add(stringTemp);
                if (i != arr.Length)
                {
                    list.Add(arr[i].ToString());
                    i++;
                }
            }

            for (int k = 0; k < list.Count - 1; k++)
            {
                for (int j = k + 1; j < list.Count; j++)
                {

                    if (list[k].CompareTo(list[j]) == 0 && list[k] != " " && list[k] != "." && list[k] != "," && list[k] != "!" && list[k] != "?" && list[k] != "-" && list[k] != ":" && list[k] != ";")
                    {
                        list[j] = "";
                    }
                }
            }

            string result = String.Join("", list);
            text = result;
        }
    }
}
