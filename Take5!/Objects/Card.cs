using System;
using System.Collections.Generic;
using System.Text;

namespace Take5_.Objects
{
    public class Card
    {
        public Card(int n)
        {
            Number = n;
            CowHeads = GetCowHeads(n);
        }

        private long GetCowHeads(long n)
        {
            if (n == 55)
            {
                return 7;
            }
            if (n % 11 == 0)
            {
                return 5;
            }
            if (n % 10 == 0)
            {
                return 3;
            }
            if (n % 5 == 0)
            {
                return 2;
            }
            return 1;
        }

        public long Number { get;  }

        public long CowHeads { get; }
    }
}
