namespace MinesweeperGame
{
    internal class Cell
    {
        private Board _boardRef;
        public int x { get; private set; }
        public int y { get; private set; }
        public int BombNeighbours { get; private set; } = 0;
        private bool Revealed { get; set; } = false;
        private bool Bomb { get; set; } = false;

        public Cell(int x, int y, Board boardRef)
        {
            this.x = x;
            this.x = y;
            _boardRef = boardRef;
        }

        public void Reveal()
        {
            Revealed = true;

            if (!Bomb || BombNeighbours > 0) return;
            
            int minX = Math.Max(0, x - 1);
            int maxX = Math.Min(_boardRef.GetColSize() - 1, x + 1);
            int minY = Math.Max(0, y - 1);
            int maxY = Math.Min(_boardRef.GetRowSize() - 1, y + 1);

            for (int cellY = minY; cellY <= maxY; cellY++)
            {
                for (int cellX = minX; cellX <= maxX; cellX++)
                {
                    Cell cellAtPos = _boardRef.GetCellAt(cellX, cellY);

                    if (cellAtPos.Bomb ||  
                        cellAtPos.Revealed
                    ) continue;

                    cellAtPos.Reveal();
                }
            }

        }

        public void CountBombNeighbours()
        {
            int minX = Math.Max(0, x - 1);
            int maxX = Math.Min(_boardRef.GetColSize() - 1, x + 1);
            int minY = Math.Max(0, y - 1);
            int maxY = Math.Min(_boardRef.GetRowSize() - 1, y + 1);

            for (int cellY = minY; cellY <= maxY; cellY++)
            {
                for (int cellX = minX; cellX <= maxX; cellX++)
                {
                    Cell cellAtPos = _boardRef.GetCellAt(cellX, cellY);
                    if (cellAtPos.Bomb) continue;
                    cellAtPos.BombNeighbours++;
                }
            }
        }
    }
}
