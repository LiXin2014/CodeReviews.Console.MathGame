namespace MathGame.LiXin2014
{
    public static class Helper
    {
        /// <summary>
        /// Get the symbol of the operator based on the enum value.
        /// </summary>
        /// <param name="op">The Options enum</param>
        /// <returns>The symbol of the operator</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string GetSymbol(this Operators op)
        {
            return op switch
            {
                Operators.Plus => "+",
                Operators.Minus => "-",
                Operators.Multiply => "*",
                Operators.Divide => "/",
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }
    }
}
