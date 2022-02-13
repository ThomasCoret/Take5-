using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects
{
    public class PlayField
    {
        private List<CardRow> cardRows;

        public PlayField(List<Card> cards)
        {
            ResetField(cards);
        }

        public void DrawField()
        {
            foreach(CardRow row in cardRows)
            {
                Console.WriteLine("===================================================");
                row.DrawRow();
            }
            Console.WriteLine("===================================================");
        }

        public void ResetField(List<Card> cards)
        {
            int i = 0;
            cardRows = new List<CardRow>();
            foreach (Card card in cards)
            {
                cardRows.Add(new CardRow(card, i));
                i++;
            }
        }

        public List<Card> CardPlayed(Card playedCard)
        {
            //random big number
            long smallestDiff = 10000;
            long smallestDiffId = -1;

            foreach(CardRow row in cardRows)
            {
                long diff = playedCard.Number - row.GetHighestCard().Number;
                if (diff > 0 && diff < smallestDiff)
                {
                    smallestDiff = diff;
                    smallestDiffId = row.Id;
                }
            }

            return cardRows.Single(x => x.Id == smallestDiffId).AddCardToRow(playedCard);
        }

        public List<Card> RemoveRow(Card playedCard, long rowId)
        {
            return cardRows.Single(x => x.Id == rowId).AddCardToRow(playedCard);
        }

        public List<CardRow> GetRows()
        {
            return cardRows;
        }

        public bool CardFitsOnBoard(Card card)
        {
            return cardRows.Any(x => x.CardFitsInRow(card));
        }
    }
}
