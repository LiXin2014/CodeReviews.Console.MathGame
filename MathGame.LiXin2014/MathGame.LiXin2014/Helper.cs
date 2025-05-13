namespace MathGame.LiXin2014
{
    public static class Helper
    {
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
