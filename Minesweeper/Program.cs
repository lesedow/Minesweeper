using MinesweeperGame;

namespace MinesweeperConsole
{
    class Program
    {
        static void Main(String[] args)
        {
            Minesweeper minesweeper = new Minesweeper();

            minesweeper.GameRun();
        }
    }
}