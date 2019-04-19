using System;
using System.Collections.Generic;
using System.Linq;

namespace PadawansTask15
{
    public class EnumerableTask
    {
        /// <summary> Transforms all strings to upper case.</summary>
        /// <param name="data">Source string sequence.</param>
        /// <returns>
        ///   Returns sequence of source strings in uppercase.
        /// </returns>
        /// <example>
        ///    {"a", "b", "c"} => { "A", "B", "C" }
        ///    { "A", "B", "C" } => { "A", "B", "C" }
        ///    { "a", "A", "", null } => { "A", "A", "", null }
        /// </example>
        public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
        {
            // TODO : Implement GetUppercaseStrings
            // throw new NotImplementedException();
            List<string> result = new List<string>();
            foreach (var d in data)
            {
                if (d == "" || d == null)
                {
                    result.Add(d);
                    continue;
                }
                result.Add(d.ToUpper());
            }
            return (IEnumerable<string>)result;

        }

        /// <summary> Transforms an each string from sequence to its length.</summary>
        /// <param name="data">Source strings sequence.</param>
        /// <returns>
        ///   Returns sequence of strings length.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   {"a", "aa", "aaa" } => { 1, 2, 3 }
        ///   {"aa", "bb", "cc", "", "  ", null } => { 2, 2, 2, 0, 2, 0 }
        /// </example>
        public IEnumerable<int> GetStringsLength(IEnumerable<string> data)
        {
            // TODO : Implement GetStringsLength
            //throw new NotImplementedException();
            List<int> result = new List<int>();
            foreach (var e in data)
            {
                if (e == "" || e == null)
                {
                    result.Add(0);
                    continue;
                }
                result.Add(e.Length);
            }
            return (IEnumerable<int>)result;
        }

        /// <summary>Transforms integer sequence to its square sequence, f(x) = x * x. </summary>
        /// <param name="data">Source int sequence.</param>
        /// <returns>
        ///   Returns sequence of squared items.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2, 3, 4, 5 } => { 1, 4, 9, 16, 25 }
        ///   { -1, -2, -3, -4, -5 } => { 1, 4, 9, 16, 25 }
        /// </example>
        public IEnumerable<long> GetSquareSequence(IEnumerable<int> data)
        {
            // TODO : Implement GetSquareSequence
            //throw new NotImplementedException();
            List<long> result = new List<long>();
            foreach (var e in data)
            {
                result.Add((long)(e) * (long)(e));
            }
            return (IEnumerable<long>)result;
        }

        /// <summary> Filters a string sequence by a prefix value (case insensitive).</summary>
        /// <param name="data">Source string sequence.</param>
        /// <param name="prefix">Prefix value to filter.</param>
        /// <returns>
        ///  Returns items from data that started with required prefix (case insensitive).
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when prefix is null.</exception>
        /// <example>
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "b"  =>  { "bbbb" }
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "B"  =>  { "bbbb" }
        ///  { "a","b","c" }, prefix = "D"  => { }
        ///  { "a","b","c" }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c", null }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c" }, prefix = null => ArgumentNullException
        /// </example>
        public IEnumerable<string> GetPrefixItems(IEnumerable<string> data, string prefix)
        {
            // TODO : Implement GetPrefixItems
            //throw new NotImplementedException();
            if (prefix == null)
                throw new ArgumentNullException();
            List<string> result = new List<string>();
            if (prefix == "")
            {
                foreach (var e in data)
                {
                    if (e != null)
                        result.Add(e);
                }
                return (IEnumerable<string>)result;
            }
            foreach (var e in data)
            {
                if (e == null)
                {
                    continue;
                }
                if (e.StartsWith(prefix.ToUpper()) || e.StartsWith(prefix.ToLower()))
                {
                    result.Add(e);
                }
            }
            return (IEnumerable<string>)result;
        }

        /// <summary> Finds the 3 largest numbers from a sequence.</summary>
        /// <param name="data">Source sequence.</param>
        /// <returns>
        ///   Returns the 3 largest numbers from a sequence.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2 } => { 2, 1 }
        ///   { 1, 2, 3 } => { 3, 2, 1 }
        ///   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } => { 10, 9, 8 }
        ///   { 10, 10, 10, 10 } => { 10, 10, 10 }
        /// </example>
        public IEnumerable<int> Get3LargestItems(IEnumerable<int> data)
        {
            // TODO : Implement Get3LargestItems
            //throw new NotImplementedException();
            List<int> list = new List<int>();
            foreach (var e in data)
            {
                list.Add(e);
            }
            list.Sort();
            list.Reverse();
            foreach (var e in list)
            {
                Console.WriteLine("list: {0}", e);
            }
            List<int> result = new List<int>();
            foreach (var e in list)
            {
                if (result.Count < 3)
                    result.Add(e);
            }
            return (IEnumerable<int>)result;
        }

        /// <summary> Calculates sum of all integers from object array.</summary>
        /// <param name="data">Source array.</param>
        /// <returns>
        ///    Returns the sum of all integers from object array.
        /// </returns>
        /// <example>
        ///    { 1, true, "a", "b", false, 1 } => 2
        ///    { true, false } => 0
        ///    { 10, "ten", 10 } => 20 
        ///    { } => 0
        /// </example>
        public int GetSumOfAllIntegers(object[] data)
        {
            // TODO : Implement GetSumOfAllIntegers
            //throw new NotImplementedException();
            List<int> result = new List<int>();
            foreach (var e in data)
            {
                if (e == null)
                    continue;
                Type t = e.GetType();
                if (t.Equals(typeof(int)))
                    result.Add((int)e);
            }
            return result.Sum();
        }
    }
}