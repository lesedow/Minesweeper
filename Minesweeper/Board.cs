namespace MinesweeperGame
{
    internal class Board
    {
        private Cell[,] _cells;

        private (int x, int y)[] _positionsList;
        private int _numberOfBombs;

        public int GridSizeX { get; private set; }
        public int GridSizeY { get; private set; }
        public Cell GetCellAt(int x, int y) => _cells[y, x];

        public Board(int gridSizeX, int gridSizeY, int numberOfBombs)
        {
            _cells = new Cell[gridSizeY, gridSizeX];
           _numberOfBombs = numberOfBombs;

            GridSizeX = gridSizeX;
            GridSizeY = gridSizeY;

            // Store each cells position in another array for shuffling
            _positionsList = InitializePositionsList(); 
        }

        private (int x, int y)[] InitializePositionsList()
        {
            _positionsList = new (int x, int y)[GridSizeX * GridSizeY];

            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    _positionsList[y * GridSizeX + x] = (x, y);
                }

            }

            return _positionsList;
        }

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
            GetCellAt(GridSizeX / 2, GridSizeY / 2).Reveal();
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

                Cell cellAtPos = GetCellAt(_positionsList[currentPos].x, _positionsList[currentPos].y);
                cellAtPos.Bomb = true;
                cellAtPos.CountBombNeighbours();
            }
        }   

        public void DisplayBoard()
        {
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    Cell cellAtPos = GetCellAt(x, y);
                    if (cellAtPos.Revealed)
                    {
                        if (cellAtPos.Bomb) Console.Write("* ");
                        else Console.Write(cellAtPos.BombNeighbours + " ");
                        continue;
                    }
                    Console.Write("# ");
                }

                Console.WriteLine();
            }
        }
    }
}
