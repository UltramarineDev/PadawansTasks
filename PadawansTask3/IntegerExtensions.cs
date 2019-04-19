using System;

namespace PadawansTask3
{
    public static class IntegerExtensions
    {
        public static int Gcd(int a, int b)
        {
            // put your code here
            //throw new NotImplementedException();
            // Binary GCD algorithm
            if (a == 0 && b == 0)
            {
                throw new ArgumentException();
            }
            if (a < 0)
            {
                a = -a;
            }
            if (b < 0)
            {
                b = -b;
            }
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            if (a == b)
            {
                return a;
            }
            if (a == 1 || b == 1)
            {
                return 1;
            }
            if (a%2 == 0 && b%2 == 0)
            {
                return 2 * Gcd(a/2,b/2);
            }
            if (a%2 == 0 && b%2 != 0)
            {
                return Gcd(a / 2, b);
            }
            if (a%2 != 0 && b%2 == 0)
            {
                return Gcd(a, b/2);
            }
            if (a % 2 != 0 && b % 2 != 0 && b > a)
            {
                return Gcd((b - a) / 2, a);
            }
            if (a % 2 != 0 && b % 2 != 0 && b < a)
            {
                return Gcd((b - a) / 2, b);
            }
            throw new ArgumentException();
        }
       
    }
}
