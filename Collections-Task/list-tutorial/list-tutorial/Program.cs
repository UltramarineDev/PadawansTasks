using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithStrings();
            // Fibonacci Sequence
            var fibonacciNumbers = new List<int> { 1, 1 };
            var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
            var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

            fibonacciNumbers.Add(previous + previous2);

            foreach (var item in fibonacciNumbers)
                Console.WriteLine(item);

            while (fibonacciNumbers.Count < 20)
            {
                previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(previous + previous2);
            }
            Console.WriteLine();
            Console.WriteLine("First 20 numbers in the sequence:");
            foreach (var item in fibonacciNumbers)
                Console.WriteLine(item);
        }
        public static void WorkingWithStrings()
        {
            var names = new List<string> { "Marina", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            Console.WriteLine();
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Ana");
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            Console.WriteLine($"My name is {names[0]}");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");
            Console.WriteLine($"The list has {names.Count} people in it");

            var index = names.IndexOf("Felipe");
            if (index == -1)
            {
                Console.WriteLine($"When an item is not found, IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }

            index = names.IndexOf("Not Found");
            if (index == -1)
            {
                Console.WriteLine($"When an item is not found, IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");

            }

            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
        }
    }
}
