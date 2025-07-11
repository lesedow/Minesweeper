using MinesweeperGame;

namespace MinesweeperConsole
{
    class Program
    {
        static void Main(String[] args)
        {
            Minesweeper minesweeper = new Minesweeper(
                gridSizeX: 9,
                gridSizeY: 9,
                numberOfBombs: 10
            );

            minesweeper.GameRun();
        }
    }
}