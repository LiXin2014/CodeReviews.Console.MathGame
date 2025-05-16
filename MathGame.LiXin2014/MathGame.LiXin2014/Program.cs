using MathGame.LiXin2014;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        Difficulty difficulty = Difficulty.Easy;
        while (true)
        {
            GameOptions? selectedOption = DisplayGameMenu();
            if (selectedOption is null)
            {
                return; // exit
            }

            if (selectedOption == GameOptions.History)
            {
                GameHistory.DisplayHistory();
            }
            else if (selectedOption == GameOptions.Exit)
            {
                Environment.Exit(0);
            }
            else if (selectedOption == GameOptions.SetDifficultyLevel)
            {
                Console.Clear();
                difficulty = ChooseGameDifficulty() ?? difficulty;
                Console.Clear();
                continue;
            }
            else if (selectedOption == GameOptions.ViewDifficultyLevel)
            {
                Console.WriteLine($"Current difficulty level is: {difficulty}");
            }
            else
            {
                Operators op = (Operators)(int)selectedOption.Value;
                PlayGame(op, difficulty);
            }
            ContinueOrQuit();
        }
    }

    private static void PlayGame(Operators op, Difficulty difficulty)
    {
        Computation computation = new Computation(difficulty);
        computation.GenerateOperands(op);

        Console.WriteLine($"What is {computation.Operand1} {computation.Operator} {computation.Operand2} = ?");

        while (true)
        {
            var result = Console.ReadLine();
            if (int.TryParse(result, out int userInput))
            {
                computation.UserInput = userInput;
                computation.GameFeedbackToConsole();
                GameHistory.AddRecord(computation);
                break;
            }
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static Difficulty? ChooseGameDifficulty()
    {
        Console.WriteLine("Choose the difficulty level. Please enter the number of the chosen option");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Difficulty? difficulty = null;
        while (difficulty is null)
        {
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                case "Easy":
                    difficulty = Difficulty.Easy;
                    break;
                case "2":
                case "Medium":
                    difficulty = Difficulty.Medium;
                    break;
                case "3":
                case "Hard":
                    difficulty = Difficulty.Hard;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        return difficulty;
    }

    private static GameOptions? DisplayGameMenu()
    {
        Console.WriteLine("Choose from below options. Please enter the number of the chosen option");
        Console.WriteLine("1. +");
        Console.WriteLine("2. -");
        Console.WriteLine("3. *");
        Console.WriteLine("4. /");
        Console.WriteLine("5. Set Difficulty Level");
        Console.WriteLine("6. View Difficulty Level");
        Console.WriteLine("7. View Game History");
        Console.WriteLine("8. Exit");

        GameOptions? op = null;
        while(op is null)
        {
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                case "+":
                    op = GameOptions.Plus;
                    break;
                case "2":
                case "-":
                    op = GameOptions.Minus;
                    break;
                case "3":
                case "*":
                    op = GameOptions.Multiply;
                    break;
                case "4":
                case "/":
                    op = GameOptions.Divide;
                    break;
                case "5":
                    op = GameOptions.SetDifficultyLevel;
                    break;
                case "6":
                    op = GameOptions.ViewDifficultyLevel;
                    break;
                case "7":
                    op = GameOptions.History;
                    break;
                case "8":
                    op = GameOptions.Exit;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        return op;
    }

    private static void ContinueOrQuit()
    {
        Console.WriteLine("Press Esc to quit the game, press any key to continue");
        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
        {
            Environment.Exit(0);
        }

        Console.Clear();
    }
}