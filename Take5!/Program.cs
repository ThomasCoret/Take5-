using Take5_.Objects;

namespace Take5_
{
    class Program
    {
        static readonly int nRandomPlayers = 4;
        static readonly int nMaxPoints = 66;
        static readonly int nHumanPlayers = 0;

        static void Main()
        {
            Game game = new Game(nMaxPoints, nRandomPlayers, nHumanPlayers);
            game.GameLoop();
        }
    }
}
