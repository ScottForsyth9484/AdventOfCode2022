using System.ComponentModel.DataAnnotations;

namespace DayOne
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string data = File.ReadAllText("input.txt");
            Challenge challenge = new Challenge();
            Console.WriteLine($"new max is {challenge.PartOne(data)}");
            Console.WriteLine($"new top 3 total is {challenge.PartTwo(data)}");

        }
    }
}