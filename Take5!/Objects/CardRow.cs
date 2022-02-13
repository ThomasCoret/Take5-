using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Take5_.Objects
{
    public class CardRow
    {
        private Card[] CardsInRow;
        private int NCardsInRow;
        public CardRow(Card firstCard)
        {
            CardsInRow = new Card[5];
            CardsInRow[0] = firstCard;
            NCardsInRow++;
        }

        public List<Card> AddCardToRow(Card playedCard)
        {
            // Row full || Card does not fit in row
            // Because == 5 might fail if the pc gets struck by lightning
            if(NCardsInRow > 4 || !CardFitsInRow(playedCard))
            {
                var cardsToRetrun = CardsInRow.ToList();
                CardsInRow = new Card[5];
                CardsInRow[0] = playedCard;
                NCardsInRow = 1;
                return cardsToRetrun;
            }

            CardsInRow[NCardsInRow] = playedCard;
            NCardsInRow++;
            return new List<Card>();
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
