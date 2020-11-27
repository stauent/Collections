using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class SimpleMath
    {
        public List<int> Numbers = new List<int>();

        public SimpleMath(params int[] Numbers)
        {
            foreach (int n in Numbers)
                this.Numbers.Add(n);
        }

        public SimpleMath(List<int> Numbers)
        {
            foreach (int n in Numbers)
                this.Numbers.Add(n);
        }

        public IEnumerable<int> EvenNumbers()
        {
            // Yield even numbers in the range.
            foreach (int number in Numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        public IEnumerable<int> OddNumbers()
        {
            // Yield odd numbers in the range.
            foreach (int number in Numbers)
            {
                if (number % 2 != 0)
                {
                    yield return number;
                }
            }
        }
    }


}
