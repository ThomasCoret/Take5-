using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects
{
    public class RandomPlayer : Player
    {
        private readonly Random rnd;

        public RandomPlayer(List<Card> dealtCards, int Id) : base(dealtCards, Id)
        {
            this.rnd = new Random();
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

        public override void DrawScore()
        {
            Console.WriteLine($"Computer Player {Id}: {GetPenaltyPointsThisRound()}");
        }

        public override void DrawTotalScore()
        {
            Console.WriteLine($"Computer Player {Id}: {GetTotalPenaltyPoints()}");
        }
    }
}
