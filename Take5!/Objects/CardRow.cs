using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects
{
    public class CardRow
    {
        public int Id;
        private Card[] CardsInRow;
        private int NCardsInRow;

        public CardRow(Card firstCard, int Id)
        {
            this.Id = Id;
            CardsInRow = new Card[5];
            CardsInRow[0] = firstCard;
            NCardsInRow++;
        }

        public void DrawRow()
        {
            Console.Write($"{Id}: ");
            for(int i = 0; i<NCardsInRow; i++)
            {
                CardsInRow[i].DrawCard();
            }
            Console.WriteLine("");
        }

        public List<Card> AddCardToRow(Card playedCard)
        {
            // Row full || Card does not fit in row
            // Because == 5 might fail if the pc gets struck by lightning
            if(NCardsInRow > 4 || !CardFitsInRow(playedCard))
            {
                var cardsToRetrun = CardsInRow.Where(x => x != null).ToList();
                CardsInRow = new Card[5];
                CardsInRow[0] = playedCard;
                NCardsInRow = 1;
                return cardsToRetrun;
            }

            CardsInRow[NCardsInRow] = playedCard;
            NCardsInRow++;
            return new List<Card>();
        } 

        public long GetPenaltyPointsInRow()
        {
            long total = 0;
            for (int i = 0; i < NCardsInRow; i++)
            {
                total += CardsInRow[i].CowHeads;
            }
            return total;
        }

        public Card GetHighestCard()
        {
            return CardsInRow[NCardsInRow - 1];
        }

        public bool CardFitsInRow(Card card)
        {
            return card.Number > GetHighestCard().Number;
        }
    }
}
