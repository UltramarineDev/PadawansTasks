using System;
using System.Collections.Generic;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }
            List<int> resultArray = new List<int>();
            List<int> listinitial = new List<int>();
            var num = number;
            while (num > 0)
            {
                listinitial.Add(num % 10);
                num = num / 10;
            }

            List<int> list = new List<int>();

            //change order
            for (int i = listinitial.Count - 1; i >= 0; i--)
            {
                list.Add(listinitial[i]);
            }

            //add first permutation to final list of permutations
            int res = 0;
            for (int k = list.Count - 1, q = 1; k >= 0; k--, q = q * 10)
            {
                res += list[k] * q;
            }
            resultArray.Add(res);

            //permutation algorithm
            int n = list.Count;

            while (NextSet(list, n))
            {
                int result = 0;
                for (int k = list.Count - 1, q = 1; k >= 0; k--, q = q * 10)
                {
                    result += list[k] * q;
                }
                resultArray.Add(result);
            }

            //sort ascending ResultArray
            resultArray.Sort();
            foreach (var a in resultArray)
            {
                if (a > number)
                {
                    return a;
                }
            }

            return null;
        }

        public static bool NextSet(List<int> list, int n)
        {
            int j = n - 2;
            while (j != -1 && list[j] >= list[j + 1])
                j--;
            if (j == -1)
                return false;
            int k = n - 1;
            while (list[j] >= list[k]) k--;
            Swap(list, j, k);
            int l = j + 1, r = n - 1;
            while (l < r)
                Swap(list, l++, r--);
            return true;
        }
        public static void Swap(List<int> list, int i, int j)
        {
            int s = list[i];
            list[i] = list[j];
            list[j] = s;
        }
    }
}
