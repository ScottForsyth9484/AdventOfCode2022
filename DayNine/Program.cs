namespace DayNine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText("./input.txt");
            Challenge challenge = new Challenge();
            Console.WriteLine($"Part One Result = {challenge.PartOne(data)}");

            Console.WriteLine($"Part Two Result = {challenge.PartTwo(data)}");
        }
    }
}