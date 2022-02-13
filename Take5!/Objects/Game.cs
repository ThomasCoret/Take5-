using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5_.Objects
{
    public class Game
    {
        private readonly int nPlayers;
        private readonly int nMaxPoints;
        private Deck deck;
        private List<Player> players;
        private PlayField playField;

        public Game(int nMaxPoints, int nRandomPlayers, int nHumanPlayers)
        {
            this.nPlayers = nRandomPlayers + nHumanPlayers;
            this.nMaxPoints = nMaxPoints;
            deck = new Deck();
            players = new List<Player>();
            int currPlayer = 1;
            for(int i = 0; i < nRandomPlayers; i++)
            {
                players.Add(new RandomPlayer(deck.DealPlayerCards(), currPlayer));
                currPlayer++;
            }
            for (int i = 0; i < nHumanPlayers; i++)
            {
                players.Add(new HumanPlayer(deck.DealPlayerCards(), currPlayer));
                currPlayer++;
            }
            playField = new PlayField(deck.DealOpenCards());
        }

        public void GameLoop()
        {
            playField.DrawField();
            while (!GameEnd())
            {
                // Only check first player since all players have equal amount of cards (at least they should have)
                while (players[0].HasCards())
                {
                    List<(Card card, long playerId)> playedCards = new List<(Card card, long playerId)>();
                    // Each player plays a card
                    foreach (Player player in players)
                    {
                        playedCards.Add((player.PlayCard(playField), player.Id));
                    }

                    Console.WriteLine("Cards played:");
                    foreach ((Card card, long playerId) playedCard in playedCards)
                    {
                        Console.WriteLine($"Player {playedCard.playerId} played {playedCard.card.Number} ({playedCard.card.CowHeads})");
                    }

                    // Add cards to the board from lowest to highest
                    for (int i = 0; i < nPlayers; i++)
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

                // End of round, reshuffle deck hand out new cards (Total scores are updated in NewHand so we have to deal cards even if there is no new round)
                deck.ResetDeck();
                foreach (Player player in players)
                {
                    player.NewHand(deck.DealPlayerCards());
                }

                if (GameEnd())
                {
                    Console.WriteLine($"Game over, a player went over {nMaxPoints}. Definite score is:");
                }
                else
                {
                    Console.WriteLine($"Round over, no player went over {nMaxPoints}. Reshuffling the deck and giving players new cards. Current standings:");
                }

                DrawPlayerTotalScores();
            }
        }

        private bool GameEnd()
        {
            foreach (Player player in players)
            {
                if(player.GetTotalPenaltyPoints() >= nMaxPoints)
                {
                    return true;
                }
            }
            return false;
        }

        private void DrawPlayerScores()
        {
            players.Sort();
            Console.WriteLine("Player Scores: ");
            foreach (Player player in players)
            {
                player.DrawScore();
            }
        }

        private void DrawPlayerTotalScores()
        {
            players.Sort();
            Console.WriteLine("Player Total Scores: ");
            foreach (Player player in players)
            {
                player.DrawTotalScore();
            }
        }
    }
}
