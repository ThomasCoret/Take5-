using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects.Players
{
    public class RandomPlayerSmartRowsReplace : Player
    {
        private readonly Random rnd;

        public RandomPlayerSmartRowsReplace(List<Card> dealtCards, int Id) : base(dealtCards, Id)
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
            // Random high number
            long lowestPenaltyPoints = 1000;
            long lowestPenaltyPointsRowId = 1000;
            foreach (var row in field.GetRows())
            {
                if (row.GetPenaltyPointsInRow() < lowestPenaltyPoints)
                {
                    lowestPenaltyPoints = row.GetPenaltyPointsInRow();
                    lowestPenaltyPointsRowId = row.Id;
                }
            }
            return (int)lowestPenaltyPointsRowId;
        }

        public override void DrawScore()
        {
            Console.WriteLine($"Random Player {Id}: {GetPenaltyPointsThisRound()}");
        }

        public override void DrawTotalScore()
        {
            Console.WriteLine($"Random Player {Id}: {GetTotalPenaltyPoints()}");
        }

        public override void DrawLosses()
        {
            Console.WriteLine($"Random Player {Id}: {losses}");
        }
    }
}
