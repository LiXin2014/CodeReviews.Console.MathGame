using MathGame.LiXin2014;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        while (true)
        {
            PlayGame();
            ContinueOrQuit();
        }
    }

    private static void PlayGame()
    {
        Operators op = DisplayMenu();
        Computation computation = new Computation();
        computation.GenerateOperands((Operators)op);

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

    private static Operators DisplayMenu()
    {
        Console.WriteLine("Choose from below options. Please enter the number of the chosen option");
        Console.WriteLine("1. +");
        Console.WriteLine("2. -");
        Console.WriteLine("3. *");
        Console.WriteLine("4. /");
        Console.WriteLine("5. View game history");

        Operators? op = null;
        //bool tryAgain = true;
        while(op is null)
        {
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                case "+":
                    op = Operators.Plus;
                    break;
                case "2":
                case "-":
                    op = Operators.Minus;
                    break;
                case "3":
                case "*":
                    op = Operators.Multiply;
                    break;
                case "4":
                case "/":
                    op = Operators.Divide;
                    break;
                case "5":
                    GameHistory.DisplayHistory();
                    ContinueOrQuit();
                    PlayGame();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        return (Operators)op;
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