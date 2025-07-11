namespace MinesweeperGame
{
    internal class Board
    {
        private (bool isBomb, bool isRevealed)[,] _cells;
        private (int x, int y)[] _positionsList;
        
        private int _numberOfBombs;
        private int _gridSizeX, _gridSizeY;

        public Board(int gridSizeX, int gridSizeY, int numberOfBombs)
        {
            _cells = new (bool isBomb, bool isRevealed)[gridSizeY, gridSizeX];
           _numberOfBombs = numberOfBombs;

            _gridSizeX = gridSizeX;
            _gridSizeY = gridSizeY;

            _positionsList = InitializePositionsList(); // Store each cells position in another array for shuffling
        }

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

        private void SetBomb((int x, int y) position)
        {
            _cells[position.y, position.x].isBomb = true;
        }

        private void RevealCell((int x, int y) position)
        {
            _cells[position.y, position.x].isRevealed = true;
        }

        public void InitBoard(Random rng)
        {
            // An implementation of the Fisher-Yates algorithm
            for (int currentPos = 0; currentPos < _numberOfBombs; currentPos++)
            {
                int randomPos = rng.Next(currentPos, _positionsList.Length);
                (int x, int y) temp = _positionsList[currentPos];
                _positionsList[currentPos] = _positionsList[randomPos];
                _positionsList[randomPos] = temp;

                SetBomb(_positionsList[currentPos]);

            }
        }   

        public void ShowBombsPositions()
        {
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    if (!_cells[y, x].isBomb) Console.Write("- ");
                    else Console.Write("# ");
                }
                Console.WriteLine();

            }
        }
    }
}
