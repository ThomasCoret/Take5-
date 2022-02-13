using System;
using System.Collections.Generic;
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
            // Only check first player since all players have equal amount of cards (at least they should have)
            while (players[0].HasCards())
            {
                List<(Card card, long playerId)> playedCards = new List<(Card card, long playerId)>();
                // Each player plays a card
                foreach(Player player in players)
                {
                    playedCards.Add((player.PlayCard(), player.Id));
                }


            }
        }
    }
}
