using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.LiXin2014
{
    class Computation
    {
        private Random _random = new Random();
        private int maxValue = 20; // max value for operands
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public int CorrectResult { get; set; }
        public Operators Operator { get; set; }
        public int UserInput { get; set; }
        public Difficulty difficulty { get; set; }

        public Computation(Difficulty difficulty)
        {
            this.difficulty = difficulty;
            switch(difficulty)
            {
                case Difficulty.Easy:
                    maxValue = 20;
                    break;
                case Difficulty.Medium:
                    maxValue = 50;
                    break;
                case Difficulty.Hard:
                    maxValue = 100;
                    break;
                default:
                    maxValue = 20; // Default value
                    break;
            }
        }

        /// <summary>
        /// Generate random two operands and compute the correct result
        /// </summary>
        /// <param name="op">The Options enum</param>
        public void GenerateOperands(Operators op)
        {
            Operand1 = _random.Next(0, maxValue + 1);
            Operand2 = _random.Next(0, maxValue + 1);
            Operator = op;

            if (op == Operators.Divide)
            {
                if (Operand2 == 0)
                {
                    Operand2 = _random.Next(1, maxValue + 1); // Ensure Operand2 is not zero for division
                }

                if (Operand1 % Operand2 != 0)
                {
                    Operand1 = Operand2 * (_random.Next(1, maxValue)); // Ensure Operand1 is divisible by Operand2
                }
            }

            this.Compute(op);
        }

        /// <summary>
        /// Display the result of the game to the console.
        /// </summary>
        public void GameFeedbackToConsole()
        {
            if (UserInput == CorrectResult)
            {
                Console.WriteLine("It's correct, congratulations!");
            }
            else
            {
                Console.WriteLine($"Keep practicing! The right answer is {CorrectResult}");
            }
        }

        /// <summary>
        /// Override the ToString method to display the computation details.
        /// For example: 1 + 2 = 3  Correct Result is: 3
        /// </summary>
        /// <returns>computation details</returns>
        public override string ToString()
        {
            return $"{Operand1} {Operator.GetSymbol()} {Operand2} = {UserInput} \t Correct Result is: {CorrectResult}";
        }

        private void Compute(Operators op)
        {
            switch(op)
            {
                case Operators.Plus:
                    CorrectResult = Operand1 + Operand2;
                    break;
                case Operators.Minus:
                    CorrectResult = Operand1 - Operand2;
                    break;
                case Operators.Multiply:
                    CorrectResult = Operand1 * Operand2;
                    break;
                case Operators.Divide:
                    if (Operand2 != 0)
                        CorrectResult = Operand1 / Operand2;
                    else
                        throw new DivideByZeroException("Cannot divide by zero.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(op), op, null);
            }
        }
    }
}
