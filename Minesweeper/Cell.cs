namespace MinesweeperGame
{
    internal class Cell
    {
        private Board _boardRef;
        public int x { get; private set; }
        public int y { get; private set; }
        public int BombNeighbours { get; set; } = 0;
        public bool Revealed { get; set; } = false;
        public bool Bomb { get; set; } = false;

        public Cell(int x, int y, Board boardRef)
        {
            this.x = x;
            this.y = y;
            _boardRef = boardRef;
        }

        private void ForEachNeighbour(Action<int, int> doAction)
        {
            int minX = Math.Max(0, x - 1);
            int maxX = Math.Min(_boardRef.GridSizeX - 1, x + 1);
            int minY = Math.Max(0, y - 1);
            int maxY = Math.Min(_boardRef.GridSizeY - 1, y + 1);

            for (int cellY = minY; cellY <= maxY; cellY++)
            {
                for (int cellX = minX; cellX <= maxX; cellX++)
                {
                    doAction(cellX, cellY);
                }
            }
        }
        public void Reveal()
        {
            Revealed = true;

            if (Bomb || BombNeighbours > 0) return;

            ForEachNeighbour((cellX, cellY) =>
            {
                Cell cellAtPos = _boardRef.GetCellAt(cellX, cellY);
                if (!cellAtPos.Bomb && !cellAtPos.Revealed) cellAtPos.Reveal();
            });

        }

        public void CountBombNeighbours()
        {
            ForEachNeighbour((cellX, cellY) => {
                Cell cellAtPos = _boardRef.GetCellAt(cellX, cellY);
                if (!cellAtPos.Bomb) cellAtPos.BombNeighbours++;
            });
        }
    }
}
