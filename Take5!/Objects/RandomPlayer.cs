using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Take5_.Objects
{
    public class RandomPlayer : Player
    {
        private List<Card> Hand;
        private List<Card> PenaltyCards;
        private Random rnd;

        public RandomPlayer(List<Card> dealtCards, int Id)
        {
            this.Id = Id;
            Hand = dealtCards;
            this.rnd = new Random();
            PenaltyCards = new List<Card>();
        }

        public override void GainPenaltyCards(List<Card> penaltyCards)
        {
            PenaltyCards.AddRange(penaltyCards);
        }

        public override long GetTotalPenaltyPoints()
        {
            return PenaltyCards.Select(x => x.CowHeads).Sum();
        }

        public override bool HasCards()
        {
            return Hand.Count > 0;
        }

        public override Card PlayCard(PlayField field)
        {
            int cardNumber = rnd.Next(0, Hand.Count - 1);
            Card playedCard = Hand[cardNumber];
            Hand.Remove(playedCard);
            return playedCard;
        }

        public override int SelectRowToRemove(PlayField field)
        {
            var rows = field.GetRows();
            int rowNumber = rnd.Next(0, rows.Count() - 1);
            return rows[rowNumber].Id;
        }
    }
}
