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
        public static string GetSymbol(this Options op)
        {
            return op switch
            {
                Options.Plus => "+",
                Options.Minus => "-",
                Options.Multiply => "*",
                Options.Divide => "/",
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }
    }
}
