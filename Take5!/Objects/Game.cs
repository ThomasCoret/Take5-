using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Take5_.Objects
{
    public class Game
    {
        private readonly int nPlayers;
        private readonly int nMaxPoints;
        private Deck deck;
        private List<Player> players;
        private PlayField playField;

        public Game(int nPlayers, int nMaxPoints)
        {
            this.nPlayers = nPlayers;
            this.nMaxPoints = nMaxPoints;
            deck = new Deck();
            deck.Shuffle();
            players = new List<Player>();
            for(int i = 0; i < nPlayers; i++)
            {
                players.Add(new RandomPlayer(deck.DealPlayerCards(), i));
            }
            playField = new PlayField(deck.DealOpenCards());
        }

        public void GameLoop()
        {
            playField.DrawField();
            // Only check first player since all players have equal amount of cards (at least they should have)
            while (players[0].HasCards())
            {
                List<(Card card, long playerId)> playedCards = new List<(Card card, long playerId)>();
                // Each player plays a card
                foreach(Player player in players)
                {
                    playedCards.Add((player.PlayCard(playField), player.Id));
                }

                Console.WriteLine("Cards played:");
                foreach((Card card, long playerId) playedCard in playedCards)
                {
                    Console.WriteLine($"Player {playedCard.playerId} played {playedCard.card.Number} ({playedCard.card.CowHeads})");
                }

                // Add cards to the board from lowest to highest
                for(int i = 0; i < nPlayers; i++)
                {
                    // Get the lowest card left (surely there is a better way to do this)
                    var currentCard = playedCards.Single(x => x.card.Number == playedCards.Min(x => x.card.Number));

                    List<Card> penaltyCards = null;

                    if (playField.CardFitsOnBoard(currentCard.card))
                    {
                        // Card fits normally on the board
                        penaltyCards = playField.CardPlayed(currentCard.card);
                    }
                    else
                    {
                        //player needs to select a row to empty and replace with his played card
                        var rowToRemove = players.Single(x => x.Id == currentCard.playerId).SelectRowToRemove(playField);
                        penaltyCards = playField.RemoveRow(currentCard.card, rowToRemove);
                    }
                    playedCards.Remove(currentCard);
                    // Add possible penalty cards to the player who played the card
                    if (penaltyCards.Count > 0)
                    {
                        players.Single(x => x.Id == currentCard.playerId).GainPenaltyCards(penaltyCards);
                    }
                }
                playField.DrawField();
                DrawPlayerScores();
            }
        }

        private void DrawPlayerScores()
        {
            Console.WriteLine("Player Scores: ");
            foreach (Player player in players)
            {
                Console.WriteLine($"Player {player.Id}: {player.GetTotalPenaltyPoints()}");
            }
        }
    }
}
