using System;
using Take5_.Objects;

namespace Take5_
{
    class Program
    {
        static readonly int nPlayers = 4;
        static readonly int nMaxPoints = 100;

        static void Main(string[] args)
        {
            Game game = new Game(nPlayers, nMaxPoints);
            game.GameLoop();
        }
    }
}
