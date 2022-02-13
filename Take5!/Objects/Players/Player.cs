using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects.Players
{
    public abstract class Player : IComparable
    {
        public long Id;
        public long losses;
        protected List<Card> Hand;
        protected List<Card> PenaltyCards;
        protected long TotalPenaltyPoints;

        public Player(List<Card> dealtCards, int Id)
        {
            this.Id = Id;
            TotalPenaltyPoints = 0;
            Hand = dealtCards;
            PenaltyCards = new List<Card>();
        }

        public abstract Card PlayCard(PlayField field);
        public abstract int SelectRowToRemove(PlayField field);
        public abstract void DrawScore();
        public abstract void DrawTotalScore();
        public abstract void DrawLosses();

        public void ResetHand()
        {
            // Why is there no remove all that does not need any input?
            Hand = new List<Card>();
            PenaltyCards = new List<Card>();
        }

        public void ResetScore()
        {
            TotalPenaltyPoints = 0;
        }

        public void NewHand(List<Card> newCards)
        {
            TotalPenaltyPoints += GetPenaltyPointsThisRound();
            ResetHand();
            Hand.AddRange(newCards);
        }
        
        public void GainPenaltyCards(List<Card> penaltyCards)
        {
            PenaltyCards.AddRange(penaltyCards);
        }

        public long GetPenaltyPointsThisRound()
        {
            // Not sure if the sum will break if it gets 0 input
            if(PenaltyCards.Count == 0)
            {
                return 0;
            }
            return PenaltyCards.Select(x => x.CowHeads).Sum();
        }

        public long GetTotalPenaltyPoints()
        {
            return TotalPenaltyPoints;
        }

        public bool HasCards()
        {
            return Hand.Count > 0;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Player otherCard)
                return this.GetTotalPenaltyPoints().CompareTo(otherCard.GetTotalPenaltyPoints());
            else
                throw new ArgumentException("Object is not a Player");
        }
    }
}
