using System;
using System.Collections.Generic;

namespace PadawansTask12
{
    public static class StringExtension
    {
        public static bool AllCharactersAreUnique(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if(source.Length == 0)
            {
                throw new ArgumentException();
            }
            var dictionary = new Dictionary<char, int>();

            foreach (var a in source)
            {
                if (!dictionary.ContainsKey(a))
                {
                    dictionary[a] = 0;
                }
                dictionary[a]++;
            }

            foreach (var a in dictionary)
            {
                if (a.Value != 1)
                { 
                    return false;
                }
            }
            return true;
        }
        
    }
}