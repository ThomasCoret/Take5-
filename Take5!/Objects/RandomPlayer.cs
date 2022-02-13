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

        public RandomPlayer(List<Card> dealtCards, int Id)
        {
            this.Id = Id;
            Hand = dealtCards;
        }

        public override void GainPenaltyCards(List<Card> penaltyCards)
        {
            penaltyCards.AddRange(penaltyCards);
        }

        public override long GetTotalPenaltyPoints()
        {
            return PenaltyCards.Select(x => x.CowHeads).Sum();
        }

        public override bool HasCards()
        {
            return Hand.Count > 0;
        }

        public override Card PlayCard()
        {
            Random rnd = new Random();
            int cardNumber = rnd.Next(0, Hand.Count - 1);
            Card playedCard = Hand[cardNumber];
            Hand.Remove(playedCard);
            return playedCard;
        }
    }
}
