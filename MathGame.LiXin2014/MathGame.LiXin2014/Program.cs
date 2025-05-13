using MathGame.LiXin2014;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        while (true)
        {
            Options? selectedOption = DisplayMenu();
            if (selectedOption is null)
            {
                return; // exit
            }

            if (selectedOption == Options.History)
            {
                GameHistory.DisplayHistory();
            }
            else
            {
                Options options = selectedOption.Value;
                PlayGame(options);
            }
            ContinueOrQuit();
        }
    }

    private static void PlayGame(Options selectedOption)
    {
        Computation computation = new Computation();
        computation.GenerateOperands(selectedOption);

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

    private static Options? DisplayMenu()
    {
        Console.WriteLine("Choose from below options. Please enter the number of the chosen option");
        Console.WriteLine("1. +");
        Console.WriteLine("2. -");
        Console.WriteLine("3. *");
        Console.WriteLine("4. /");
        Console.WriteLine("5. View game history");

        Options? op = null;
        //bool tryAgain = true;
        while(op is null)
        {
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                case "+":
                    op = Options.Plus;
                    break;
                case "2":
                case "-":
                    op = Options.Minus;
                    break;
                case "3":
                case "*":
                    op = Options.Multiply;
                    break;
                case "4":
                case "/":
                    op = Options.Divide;
                    break;
                case "5":
                    op = Options.History;
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