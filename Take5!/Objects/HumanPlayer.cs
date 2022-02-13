using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(List<Card> dealtCards, int Id) : base(dealtCards, Id)
        {
            Hand.Sort();
        }

        public override Card PlayCard(PlayField field)
        {
            Console.WriteLine("Please pick a card (type the number of the card)\n");
            DrawCards();
            Card playedCard = null;
            do
            {
                string selectedCardInput = Console.ReadLine();
                int selectedCard = int.Parse(selectedCardInput);
                playedCard = Hand.SingleOrDefault(x => x.Number == selectedCard);
                if(playedCard == null)
                {
                    Console.WriteLine("Card not found please try again");
                }
            }
            while (playedCard == null);
            
            Hand.Remove(playedCard);
            return playedCard;
        }

        public override int SelectRowToRemove(PlayField field)
        {
            field.DrawField();
            Console.WriteLine("Please pick a row to remove (Type the number showing in front of the row)");
            string selectedRowInput = Console.ReadLine();
            return int.Parse(selectedRowInput);
        }

        public override void DrawScore()
        {
            Console.WriteLine($"Human Player {Id}: {GetTotalPenaltyPoints()}");
        }

        private void DrawCards()
        {
            foreach (Card card in Hand)
            {
                card.DrawCard();
            }
        }
    }
}
