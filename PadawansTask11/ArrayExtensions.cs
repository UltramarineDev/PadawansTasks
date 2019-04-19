using System;

namespace PadawansTask11
{
    public static class ArrayExtensions
    {
        public static int? FindIndex(double[] array, double accuracy)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Length == 0)
            {
                throw new ArgumentException();
            }
            if (accuracy >= 1 || accuracy <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            double sumLeft = 0;
            double sumRight = 0;

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sumLeft += array[j];
                }
                for (int j = i + 1; j < array.Length; j++)
                {
                    sumRight += array[j];
                }
                if(Math.Abs(sumLeft - sumRight) <= accuracy)
                {
                    return i;
                }
                sumLeft = 0;
                sumRight = 0;
            }
            return null;

        }
    }
}
