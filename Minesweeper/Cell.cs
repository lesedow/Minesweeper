namespace MinesweeperGame
{
    internal class Cell
    {
        private int _bombNeighbours;
        private bool _isBomb;
        private bool _isRevealed;

        private int _x, _y;

        public Cell(int x, int y)
        {
            _x = x;
            _y = y;
            _bombNeighbours = 0;
            _isBomb = false;
            _isRevealed = false;
        }
        public void Reveal() => _isRevealed = true;
        public bool IsReavealed() => _isRevealed;
        public bool IsBomb() => _isBomb;
        public int GetBombNeighbours() => _bombNeighbours;
        public void IncreaseNumberOfNeighbours() => _bombNeighbours++;
        
        public void SetToBomb(Board board)
        {
            _isBomb = true;
            CountBombNeighbours(board);
        }

        private void CountBombNeighbours(Board board)
        {
            Cell[,] grid = board.GetGrid();

            int minX = Math.Max(0, _x - 1);
            int maxX = Math.Min(grid.GetLength(1) - 1, _x + 1);
            int minY = Math.Max(0, _y - 1);
            int maxY = Math.Min(grid.GetLength(0) - 1, _y + 1);

            for (int cellY = minY; cellY <= maxY; cellY++)
            {
                for (int cellX = minX; cellX <= maxX; cellX++)
                {
                    Cell cellAtPos = board.GetCellAt(cellX, cellY);
                    if (cellAtPos.IsBomb()) continue;
                    cellAtPos.IncreaseNumberOfNeighbours();
                }
            }
        }
    }
}
