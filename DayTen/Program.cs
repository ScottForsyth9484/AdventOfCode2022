namespace DayEleven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText("./input.txt");
            Challenge challenge = new Challenge();
            Console.WriteLine($"Part One Result = {challenge.PartOne(data)}");
            try
            {
                Console.WriteLine($"Part Two Result = ");
                Console.WriteLine(challenge.PartTwo(data));
            }
            catch { }
        }
    }
}