namespace MinesweeperGame
{
    internal class Board
    {
        private Cell[,] _cells;
        private (int x, int y)[] _positionsList;
        
        private int _numberOfBombs;
        private int _gridSizeX, _gridSizeY;

        public Board(int gridSizeX, int gridSizeY, int numberOfBombs)
        {
            _cells = new Cell[gridSizeY, gridSizeX];
           _numberOfBombs = numberOfBombs;

            _gridSizeX = gridSizeX;
            _gridSizeY = gridSizeY;

            // Store each cells position in another array for shuffling
            _positionsList = InitializePositionsList(); 
        }

        public int GetRowSize() => _gridSizeY;
        public int GetColSize() => _gridSizeX;

        private (int x, int y)[] InitializePositionsList()
        {
            _positionsList = new (int x, int y)[_gridSizeX * _gridSizeY];

            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    _positionsList[y * _gridSizeX + x] = (x, y);
                }

            }

            return _positionsList;
        }

        public Cell[,] GetGrid() => _cells;
        public Cell GetCellAt(int x, int y) => _cells[y, x];

        public void InitBoard(Random rng)
        {
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    _cells[y, x] = new Cell(x, y, this);
                }

            }

            PlaceBombs(rng);
            GetCellAt(_gridSizeX / 2, _gridSizeY / 2).Reveal();
        }
        private void PlaceBombs(Random rng)
        {
            // An implementation of the Fisher-Yates algorithm
            for (int currentPos = 0; currentPos < _numberOfBombs; currentPos++)
            {
                int randomPos = rng.Next(currentPos, _positionsList.Length);
                (int x, int y) temp = _positionsList[currentPos];
                _positionsList[currentPos] = _positionsList[randomPos];
                _positionsList[randomPos] = temp;

                GetCellAt(_positionsList[currentPos].x, _positionsList[currentPos].y)
                    .SetToBomb(this);

            }
        }   

        public void DisplayBoard()
        {
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    Cell cell = GetCellAt(x, y);
                    if (cell.IsRevealed())
                    {
                        if (cell.IsBomb()) Console.Write("* ");
                        else Console.Write(cell.GetBombNeighbours() + " ");
                        continue;
                    }
                    Console.Write("# ");
                }

                Console.WriteLine();
            }
        }
    }
}
