using System;

namespace Take5_.Objects
{
    public class Card : IComparable
    {
        public Card(int n)
        {
            Number = n;
            CowHeads = GetCowHeads(n);
        }

        public void DrawCard()
        {
            Console.Write($"|{Number} ({CowHeads})| ");
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

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Card otherCard)
                return this.Number.CompareTo(otherCard.Number);
            else
                throw new ArgumentException("Object is not a Card");
        }

        public long Number { get; }

        public long CowHeads { get; }
    }
}
