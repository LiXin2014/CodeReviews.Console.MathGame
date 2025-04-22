namespace MathGame.LiXin2014
{
    public static class Helper
    {
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
