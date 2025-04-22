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
        private int maxValue = 100; // Default max value for operands
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public int CorrectResult { get; set; }
        public Operators Operator { get; set; }
        public int UserInput { get; set; }

        // Generate random two operands
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
                    Operand1 = Operand2 * (_random.Next(1, maxValue / Operand2 + 1)); // Ensure Operand1 is divisible by Operand2
                }
            }

            this.Compute(op);
        }

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
