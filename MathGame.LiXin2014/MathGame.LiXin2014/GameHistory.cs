namespace MathGame.LiXin2014
{
    static class GameHistory
    {
        public static List<Computation> gameRecords { get; set; } = new List<Computation>();

        public static void AddRecord(Computation record)
        {
            gameRecords.Add(record);
        }

        public static void DisplayHistory()
        {
            Console.WriteLine("Game History:");
            var index = 1;
            foreach (var record in gameRecords)
            {
                Console.WriteLine($"{index}. {record.ToString()}");
                index++;
            }
        }
    }
}
