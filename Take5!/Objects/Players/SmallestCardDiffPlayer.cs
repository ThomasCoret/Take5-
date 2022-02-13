using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects.Players
{
    // This player choses the card that has the closest gap to one of the rows. He also chooses smart rows to remove (lowest penalty points (obviously))
    // He chooses the highest possible card if no card fits on the board (so that other players might also play a low card and he doens't have to take a row
    public class SmallestCardDiffPlayer : Player
    {
        public SmallestCardDiffPlayer(List<Card> dealtCards, int Id) : base(dealtCards, Id){ }

        public override Card PlayCard(PlayField field)
        {
            long smallestCardDiff = 100000;
            long smallestCardNumber = -1;

            foreach (Card card in Hand)
            {
                long smallestDiffThisCard = 100000;
                foreach (var row in field.GetRows())
                {
                    var diff = card.Number - row.GetHighestCard().Number;
                    if(diff > 0 && diff < smallestDiffThisCard)
                    {
                        smallestDiffThisCard = diff;
                    }
                }
                if (smallestDiffThisCard < smallestCardDiff)
                {
                    smallestCardDiff = smallestDiffThisCard;
                    smallestCardNumber = card.Number;
                }
                // In case of tie choose the lower card
                if (smallestDiffThisCard == smallestCardDiff)
                {
                    // No need to update diff (obviously)
                    smallestCardNumber = Math.Min(card.Number, smallestCardNumber);
                }
            }
            Card playedCard;
            if (smallestCardNumber == -1)
            {
                playedCard = Hand.Single(x => x.Number == Hand.Max(x => x.Number));
                Hand.Remove(playedCard);
                return playedCard;
            }
            playedCard = Hand.Single(x => x.Number == smallestCardNumber);
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
                if(row.GetPenaltyPointsInRow() < lowestPenaltyPoints)
                {
                    lowestPenaltyPoints = row.GetPenaltyPointsInRow();
                    lowestPenaltyPointsRowId = row.Id;
                }
            }
            return (int)lowestPenaltyPointsRowId;
        }

        public override void DrawScore()
        {
            Console.WriteLine($"SCD Player {Id}: {GetPenaltyPointsThisRound()}");
        }

        public override void DrawTotalScore()
        {
            Console.WriteLine($"SCD Player {Id}: {GetTotalPenaltyPoints()}");
        }

        public override void DrawLosses()
        {
            Console.WriteLine($"SCD Player {Id}: {losses}");
        }
    }
}
