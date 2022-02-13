using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects
{
    public abstract class Player
    {
        public long Id;
        protected List<Card> Hand;
        protected List<Card> PenaltyCards;

        public Player(List<Card> dealtCards, int Id)
        {
            this.Id = Id;
            Hand = dealtCards;
            PenaltyCards = new List<Card>();
        }

        public abstract Card PlayCard(PlayField field);
        public abstract int SelectRowToRemove(PlayField field);
        public abstract void DrawScore();
        public void GainPenaltyCards(List<Card> penaltyCards)
        {
            PenaltyCards.AddRange(penaltyCards);
        }

        public long GetTotalPenaltyPoints()
        {
            return PenaltyCards.Select(x => x.CowHeads).Sum();
        }

        public bool HasCards()
        {
            return Hand.Count > 0;
        }
    }
}
