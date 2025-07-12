namespace MinesweeperGame
{
    internal class Cell
    {
        private int _bombNeighbours;
        private bool _isBomb;
        private bool _isRevealed;
        private Board _boardRef;

        private int _x, _y;

        public Cell(int x, int y, Board boardRef)
        {
            _x = x;
            _y = y;
            _bombNeighbours = 0;
            _isBomb = false;
            _isRevealed = false;
            _boardRef = boardRef;
        }
        public bool IsRevealed() => _isRevealed;
        public bool IsBomb() => _isBomb;
        public int GetBombNeighbours() => _bombNeighbours;
        public void IncreaseNumberOfNeighbours() => _bombNeighbours++;
        public void SetToBomb(Board board)
        {
            _isBomb = true;
            CountBombNeighbours();
        }

        public void Reveal()
        {
            _isRevealed = true;

            if (IsBomb() || GetBombNeighbours() > 0) return;
            
            int minX = Math.Max(0, _x - 1);
            int maxX = Math.Min(_boardRef.GetColSize() - 1, _x + 1);
            int minY = Math.Max(0, _y - 1);
            int maxY = Math.Min(_boardRef.GetRowSize() - 1, _y + 1);

            for (int cellY = minY; cellY <= maxY; cellY++)
            {
                for (int cellX = minX; cellX <= maxX; cellX++)
                {
                    Cell cellAtPos = _boardRef.GetCellAt(cellX, cellY);

                    if (cellAtPos.IsBomb() ||  
                        cellAtPos.IsRevealed()
                    ) continue;

                    cellAtPos.Reveal();
                }
            }

        }

        private void CountBombNeighbours()
        {
            int minX = Math.Max(0, _x - 1);
            int maxX = Math.Min(_boardRef.GetColSize() - 1, _x + 1);
            int minY = Math.Max(0, _y - 1);
            int maxY = Math.Min(_boardRef.GetRowSize() - 1, _y + 1);

            for (int cellY = minY; cellY <= maxY; cellY++)
            {
                for (int cellX = minX; cellX <= maxX; cellX++)
                {
                    Cell cellAtPos = _boardRef.GetCellAt(cellX, cellY);
                    if (cellAtPos.IsBomb()) continue;
                    cellAtPos.IncreaseNumberOfNeighbours();
                }
            }
        }
    }
}
