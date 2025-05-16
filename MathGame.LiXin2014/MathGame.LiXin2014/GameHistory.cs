namespace MathGame.LiXin2014
{
    static class GameHistory
    {
        private static List<Computation> gameRecords { get; set; } = new List<Computation>();

        public static void AddRecord(Computation record)
        {
            gameRecords.Add(record);
        }

        public static void DisplayHistory()
        {
            if (gameRecords.Count == 0)
            {
                Console.WriteLine("No game history available.");
                return;
            }

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
