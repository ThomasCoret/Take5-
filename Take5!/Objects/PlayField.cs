using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Take5_.Objects
{
    public class PlayField
    {
        private readonly List<CardRow> CardRows;

        public PlayField(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                CardRows.Add(new CardRow(card));
            }
        }

        public void CardPlayed(Card playedCard)
        {
            //random big number
            int smallesDiff = 10000;
            for(List<Card>)
        }

        public bool CardFitsOnBoard(Card card)
        {
            return CardRows.Any(x => x.CardFitsInRow(card));
        }
    }
}
