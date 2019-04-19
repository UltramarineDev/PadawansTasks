using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FancyCalc
{
    public class FancyCalcEnguine
    {

        public double Add(int a, int b)
        {
            //throw new NotImplementedException();
            return a + b;
        }


        public double Subtract(int a, int b)
        {
            //throw new NotImplementedException();
            return a - b;
        }


        public double Multiply(int a, int b)
        {
            return a * b;
        }

        //generic calc method. usage: "10 + 20"  => result 30
        public double Culculate(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException();
            }
            if (expression.IndexOf("+") != -1)
            {
                string[] numbers = expression.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                var numbersArray = DivideByNumbers(numbers);

                return numbersArray[0] + numbersArray[1];
            }
            else

            if (expression.IndexOf("-") != -1)
            {
                string[] numbers = expression.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                var numbersArray = DivideByNumbers(numbers);
                return numbersArray[0] - numbersArray[1];

            }
            else
            if (expression.IndexOf("*") != -1)
            {
                string[] numbers = expression.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                var numbersArray = DivideByNumbers(numbers);
                return numbersArray[0] * numbersArray[1];
            }
            else
            if (expression.IndexOf("/") != -1)
            {
                string[] numbers = expression.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                int[] numbersArray = new int[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    bool isNum = int.TryParse(numbers[i], out numbersArray[i]);
                    if (isNum == false)
                    {
                        throw new ArgumentException();
                    }
                }
                if (numbersArray[1] == 0)
                {
                    throw new DivideByZeroException();
                }
                else { return numbersArray[0] / numbersArray[1]; }
            }
            else
                throw new ArgumentException();
            //throw new NotImplementedException();

        }
        double[] DivideByNumbers(string[] numbers)
        {
            double[] numbersArray = new double[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isNum = double.TryParse(numbers[i], out numbersArray[i]);
                if (isNum == false)
                {
                    throw new ArgumentException();
                }
            }
            return numbersArray;
        }
    }
}
