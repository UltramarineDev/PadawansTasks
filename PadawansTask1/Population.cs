using System;

namespace PadawansTask1
{
    public class Population
    {
        public static int GetYears(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            int years = 0;
            // put your code here
            // throw new NotImplementedException();
            if (initialPopulation > currentPopulation || initialPopulation <= 0 || currentPopulation <= 0 || visitors < 0 || percent < 0)
            {
                throw new ArgumentException();
            }
           double ninitialPopulation = initialPopulation;

           while (ninitialPopulation <= currentPopulation)
            {
                try
                {
                     ninitialPopulation = ninitialPopulation + ninitialPopulation * (percent / 100) + visitors;
                     years++;
                }
               catch(OverflowException)
                {
                    throw new OverflowException();
                }
            }
            return years;
        }
    }
}