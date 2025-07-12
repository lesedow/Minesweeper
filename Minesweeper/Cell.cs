namespace MinesweeperGame
{
    internal class Cell
    {
        private int _bombNeighbours;
        private bool isBomb;
        private bool isRevealed;

        private int _x, _y;

        public Cell(int x, int y)
        {
            _x = x;
            _y = y;
            _bombNeighbours = 0;
            isBomb = false;
            isRevealed = false;
        }
        
        public void SetToBomb() => isBomb = true;
        public void Reveal() => isRevealed = true;

        public void CountBombNeighbours(Board board)
        {
            if (isBomb) return;

            Cell[,] grid = board.GetGrid();

            int minX = Math.Min(0, _x - 1);
            int maxX = Math.Max(grid.GetLength(1), _x + 1);
            int minY = Math.Min(0, _y - 1);
            int maxY = Math.Max(grid.GetLength(0), _y + 1);

            for (int cellY = minY; cellY < maxY; cellY++)
            {
                for (int cellX = minX; cellX < maxX; cellX++)
                {
                    if (!board.GetCellAt(cellX, cellY).isBomb) continue;
                    _bombNeighbours++;
                }
            }
        }
    }
}
