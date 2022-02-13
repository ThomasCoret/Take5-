using System;
using System.Collections.Generic;
using System.Text;

namespace Take5_.Objects
{
    public abstract class Player
    {
        public long Id;
        public abstract Card PlayCard();
        public abstract void GainPenaltyCards(List<Card> penaltyCards);
        public abstract long GetTotalPenaltyPoints();
        public abstract bool HasCards();
    }
}
