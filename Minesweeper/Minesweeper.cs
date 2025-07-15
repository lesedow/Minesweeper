namespace MinesweeperGame
{
    public class Minesweeper
    {
        private Random _rng = new Random();
        private Board _minesweeperBoard;

        private Dictionary<string, (int gridX, int gridY, int bombs)> _valuesPerDifficulty = new()
        {
            ["easy"] = (9, 9, 19),
            ["intermediate"] = (16, 16, 40),
            ["expert"] = (30, 16, 99)
        };

        public Minesweeper() {
            string difficulty = GetDifficultyFromUser();
            var selectedDifficultyValues = _valuesPerDifficulty[difficulty];

            _minesweeperBoard = new Board(
                gridSizeX: selectedDifficultyValues.gridX,
                gridSizeY: selectedDifficultyValues.gridY,
                numberOfBombs: selectedDifficultyValues.bombs
             );
        }
        public void GameRun()
        {
            _minesweeperBoard.InitBoard(_rng);
            _minesweeperBoard.DisplayBoard();
        }

        private string GetDifficultyFromUser()
        {
            Console.WriteLine("Select game difficulty: Easy, Intermediate, Expert");
            Console.Write("> ");

            string? userInput = Console.ReadLine()?.ToLower();
            if (userInput != null)
            {
                if (_valuesPerDifficulty.ContainsKey(userInput))
                {
                    return userInput;
                }
            }

            return "easy";
        }
    }

}
