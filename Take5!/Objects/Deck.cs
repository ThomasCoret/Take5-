using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects
{
    public class Deck
    {
        private static readonly int HandSize = 10;
        private static readonly int OpenCards = 4;

        private List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();
            for (int i = 1; i < 106; i++) {
                Cards.Add(new Card(i));
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            Cards = Cards.OrderBy((item) => rnd.Next()).ToList();
        }

        public void PrintDeck()
        {
            foreach(Card card in Cards)
            {
                Console.WriteLine($"{card.Number} : {card.CowHeads}");
            }
        }

        public List<Card> DealPlayerCards()
        {
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < HandSize; i++)
            {
                Card currentCard = Cards[0];
                Cards.RemoveAt(0);
                dealtCards.Add(currentCard);
            }
            return dealtCards;
        }
        public List<Card> DealOpenCards()
        {
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < OpenCards; i++)
            {
                Card currentCard = Cards[0];
                Cards.RemoveAt(0);
                dealtCards.Add(currentCard);
            }
            return dealtCards;
        }

        
    }
}
