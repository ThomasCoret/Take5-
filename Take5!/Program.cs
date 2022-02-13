using Take5_.Objects;

namespace Take5_
{
    class Program
    {
        static readonly int nMaxPoints = 66;
        static readonly bool drawStuff = false;
        static readonly int nTotalGames = 10000;
        static readonly int nRandomPlayers = 4;
        static readonly int nHumanPlayers = 0;
        static readonly int nSCDPlayers = 2;

        static void Main()
        {
            Game game = new Game(nMaxPoints, drawStuff, nTotalGames, nRandomPlayers, nHumanPlayers, nSCDPlayers);
            game.GameLoop();
        }
    }
}
