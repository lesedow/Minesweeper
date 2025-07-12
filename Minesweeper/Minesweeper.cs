namespace MinesweeperGame
{
    public class Minesweeper
    {
        private Board _minesweeperBoard;
        private Random _rng;
        public Minesweeper(int gridSizeX, int gridSizeY, int numberOfBombs) 
        {
            _minesweeperBoard = new Board(
                gridSizeX: gridSizeX,
                gridSizeY: gridSizeY,
                numberOfBombs: numberOfBombs
            );

            _rng = new Random();
        }
        public void GameRun()
        {
            _minesweeperBoard.InitBoard(_rng);
            _minesweeperBoard.DisplayBoard();
        }
    }

}
