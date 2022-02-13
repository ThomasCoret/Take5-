using System;
using System.Collections.Generic;
using System.Text;

namespace Take5_.Objects
{
    public abstract class Player
    {
        public long Id;
        public abstract Card PlayCard(PlayField field);
        public abstract int SelectRowToRemove(PlayField field);
        public abstract void GainPenaltyCards(List<Card> penaltyCards);
        public abstract long GetTotalPenaltyPoints();
        public abstract bool HasCards();
    }
}
